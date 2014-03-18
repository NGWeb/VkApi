using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using Newtonsoft.Json.Linq;
using Vk.SDK.httpClient;
using Vk.SDK.Util;
using Vk.SDK.Vk;

namespace Vk.SDK
{
    public abstract class AbstractRequest : VKObject
    {
        public event ErrorDelegate Error;
        public event CompleteDelegate Complete;

        protected virtual void OnComplete(VKResponse e)
        {
            var handler = Complete;
            if (handler != null) handler(this, e);
        }

        public void OnError(VKError error)
        {
            error.request = this;
            if (Error != null)
            {
                Error(this, error);
            }

            if (PostRequestsQueue == null || PostRequestsQueue.Count <= 0) return;
            foreach (var postRequest in PostRequestsQueue.Where(postRequest => postRequest.Error != null))
            {
                postRequest.Error(this, error);
            }
        }

        public enum HttpMethod
        {
            GET,
            POST
        }

        /**
     * Selected method name
     */
        public readonly string methodName;
        /**
     * HTTP method for loading
     */
        public readonly HttpMethod httpMethod;
        /**
     * Passed parameters for method
     */
        private readonly VKParameters mMethodParameters;
        /**
     * Method parametes with common parameters
     */
        private VKParameters mPreparedParameters;
        /**
     * HTTP loading operation
     */
        /**
* How much times request was loaded
*/
        private int mAttemptsUsed;

        /**
     * Requests that should be called after current request.
     */
        protected List<AbstractRequest> PostRequestsQueue;

        /**
     * Specify language for API request
     */
        private string mPreferredLang;

        /**
        /**
     * Specify attempts for request loading if caused HTTP-error. 0 for infinite
     */
        public int attempts;
        /**
     * Use HTTPS requests (by default is YES). If http-request is impossible (user denied no https access), SDK will load https version
     */
        public bool secure;
        /**
     * Sets current system language as default for API data
     */
        public bool useSystemLanguage;
        /**
     * Set to false if you don't need automatic model parsing
     */
        public bool parseModel;

        /**
     * @return Returns HTTP-method for current request
     */
        public HttpMethod getHttpMethod()
        {
            return httpMethod;
        }

        /**
     * @return Returns list of method parameters (without common parameters)
     */
        public VKParameters getMethodParameters()
        {
            return mMethodParameters;
        }

        /**
     * Creates new request with parameters. See documentation for methods here https://vk.com/dev/methods
     *
     * @param method API-method name, e.g. audio.get
     */
        public AbstractRequest(string method)
            : this(method, null)
        {
        }

        /**
     * Creates new request with parameters. See documentation for methods here https://vk.com/dev/methods
     *
     * @param method     API-method name, e.g. audio.get
     * @param parameters method parameters
     */
        public AbstractRequest(string method, VKParameters parameters)
            : this(method, parameters, HttpMethod.GET)
        {
        }

        /**
     * Creates new request with parameters. See documentation for methods here https://vk.com/dev/methods
     *
     * @param method     API-method name, e.g. audio.get
     * @param parameters method parameters
     * @param httpMethod HTTP method for execution, e.g. GET, POST
     */
        public AbstractRequest(string method, VKParameters parameters, HttpMethod httpMethod)
        {
            this.methodName = method;
            if (parameters == null)
            {
                parameters = new VKParameters();
            }
            this.mMethodParameters = new VKParameters(parameters);
            if (httpMethod == null)
                httpMethod = HttpMethod.GET;
            this.httpMethod = httpMethod;
            this.mAttemptsUsed = 0;

            this.secure = true;
            //By default there is 1 attempt for loading.
            this.attempts = 1;

            //If system language is not supported, we use english
            this.mPreferredLang = "en";
            //By default we use system language.
            this.useSystemLanguage = true;
        }

        /**
         * Register current request for execute after passed request, if passed request is successful. If it's not, errorBlock will be called.
         *
         * @param request  after which request must be called that request
         * @param listener listener for request events
         */
        public void ExecuteAfterRequest(AbstractRequest request)
        {
            request.AddPostRequest(this);
        }

        public void AddPostRequest(AbstractRequest postRequest)
        {
            if (PostRequestsQueue == null)
            {
                PostRequestsQueue = new List<AbstractRequest>();
            }
            PostRequestsQueue.Add(postRequest);
        }

        public VKParameters GetPreparedParameters()
        {
            if (mPreparedParameters == null)
            {
                mPreparedParameters = new VKParameters(mMethodParameters);

                //Set current access token from SDK object
                VKAccessToken token = VKSdk.getAccessToken();
                if (token != null)
                    mPreparedParameters.Add(VKApiConst.ACCESS_TOKEN, token.accessToken);
                if (!this.secure)
                    if (token != null && (token.secret != null || token.httpsRequired))
                    {
                        this.secure = true;
                    }
                //Set actual version of API
                mPreparedParameters.Add(VKApiConst.VERSION, VKSdkVersion.API_VERSION);
                //Set preferred language for request
                mPreparedParameters.Add(VKApiConst.LANG, GetLang());

                if (this.secure)
                {
                    //If request is secure, we need all urls as https
                    mPreparedParameters.Add(VKApiConst.HTTPS, "1");
                }
                if (token != null && token.secret != null)
                {
                    //If it not, generate signature of request
                    string sig = GenerateSig(token);
                    mPreparedParameters.Add(VKApiConst.SIG, sig);
                }
                //From that moment you cannot modify parameters.
                //Specially for http loading
            }
            return mPreparedParameters;
        }

        /**
     * Prepares request for loading
     *
     * @return Prepared HttpUriRequest for that VKRequest
     */
        public WebRequest GetPreparedRequest()
        {
            var request = RequestFactory.RequestWithVkRequest(this);

            if (request != null)
                return request;

            var error = new VKError(VKError.VK_API_REQUEST_NOT_PREPARED);
            Error(this, error);
            return null;
        }


        public abstract void Cancel();

        public void Repeat()
        {
            mAttemptsUsed = 0;
            mPreparedParameters = null;
            GetResponse();
        }

        public void AddExtraParameter(string key, object value)
        {
            mMethodParameters.Add(key, value);
        }

        private string GetLang()
        {
            string result = mPreferredLang;
            if (useSystemLanguage)
            {
                result = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToLower();

                if (result.Equals("uk"))
                {
                    result = "ua";
                }

                if (new string[] { "ru", "en", "ua", "es", "fi", "de", "it" }.Contains(result))
                {
                    result = mPreferredLang;
                }
            }
            return result;
        }

        private string GenerateSig(VKAccessToken token)
        {
            //Read description here https://vk.com/dev/api_nohttps
            //At first, we need key-value pairs in order of request
            string querystring = VKstringJoiner.joinParams(mPreparedParameters);
            //Then we generate "request string" /method/{METHOD_NAME}?{GET_PARAMS}{POST_PARAMS}
            querystring = string.Format("/method/{0}?{1}", methodName, querystring);
            return VKUtil.md5(querystring + token.secret);

        }


        private void provideResponse(JObject jsonResponse, object parsedModel)
        {
            VKResponse response = new VKResponse();
            response.parsedModel = parsedModel;

            if (PostRequestsQueue != null && PostRequestsQueue.Count > 0)
            {
                foreach (AbstractRequest request in PostRequestsQueue)
                {
                    request.GetResponse();
                }
            }

            OnComplete(response);
        }

        /**
     * Adds additional parameter to that request
     *
     * @param key   parameter name
     * @param value parameter value
     */


        /**
     * Adds additional parameters to that request
     *
     * @param extraParameters parameters supposed to be added
     */
        public void addExtraParameters(VKParameters extraParameters)
        {
            foreach (var extraParameter in extraParameters)
            {
                mMethodParameters.Add(extraParameter.Key, extraParameter.Value);
            }

        }

        public abstract object GetResponse();

        private bool processCommonError(VKError error)
        {
            if (error.errorCode == VKError.VK_API_ERROR)
            {
                if (error.apiError.errorCode == 14)
                {
                    error.apiError.request = this;
                    this.mLoadingOperation = null;
                    VKSdk.instance().sdkListener().onCaptchaError(error.apiError);
                    return true;
                }
                else if (error.apiError.errorCode == 16)
                {
                    VKAccessToken token = VKSdk.getAccessToken();
                    token.httpsRequired = true;
                    return true;
                }
                else if (error.apiError.errorCode == 17)
                {
                    return true;
                }
            }

            return false;
        }



        /**
     * Sets preferred language for api results.
     * @param lang Two letter language code. May be "ru", "en", "ua", "es", "fi", "de", "it"
     */
        public void setPreferredLang(string lang)
        {
            useSystemLanguage = false;
            mPreferredLang = lang;
        }


        public static AbstractRequest getRegisteredRequest(long requestId)
        {
            return (VKRequest)getRegisteredObject(requestId);
        }
    }
}