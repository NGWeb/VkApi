#region usings

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using Newtonsoft.Json.Linq;
using Vk.SDK.Http;
using Vk.SDK.Util;
using Vk.SDK.Vk;

#endregion

namespace Vk.SDK
{
    public abstract class AbstractRequest : VKObject
    {
        public enum HttpMethod
        {
            GET,
            POST
        }

        private readonly IRequestFactory _requestFactory;

        public readonly HttpMethod httpMethod;
        private readonly VKParameters mMethodParameters;
        public readonly string methodName;
        public bool ParseModel;
        protected List<AbstractRequest> PostRequestsQueue = new List<AbstractRequest>();

        public int attempts;
        private int mAttemptsUsed;
        private string mPreferredLang;
        private VKParameters mPreparedParameters;
        public bool secure;
        public bool useSystemLanguage;

        protected AbstractRequest(string method, IRequestFactory requestFactory)
            : this(method, null, requestFactory)
        {

        }

        /**
     * Creates new request with parameters. See documentation for methods here https://vk.com/dev/methods
     *
     * @param method     API-method name, e.g. audio.get
     * @param parameters method parameters
     */

        protected AbstractRequest(string method, VKParameters parameters, IRequestFactory requestFactory)
            : this(method, parameters, HttpMethod.GET, requestFactory)
        {
        }

        /**
     * Creates new request with parameters. See documentation for methods here https://vk.com/dev/methods
     *
     * @param method     API-method name, e.g. audio.get
     * @param parameters method parameters
     * @param httpMethod HTTP method for execution, e.g. GET, POST
     */

        public AbstractRequest(string method, VKParameters parameters, HttpMethod httpMethod, IRequestFactory requestFactory)
        {
            methodName = method;
            if (parameters == null)
            {
                parameters = new VKParameters();
            }
            mMethodParameters = new VKParameters(parameters);
            if (httpMethod == null)
                httpMethod = HttpMethod.GET;
            this.httpMethod = httpMethod;
            this._requestFactory = requestFactory;
            mAttemptsUsed = 0;

            secure = true;
            //By default there is 1 attempt for loading.
            attempts = 1;

            //If system language is not supported, we use english
            mPreferredLang = "en";
            //By default we use system language.
            useSystemLanguage = true;
        }

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

        public HttpMethod GetHttpMethod()
        {
            return httpMethod;
        }
    
        public VKParameters GetMethodParameters()
        {
            return mMethodParameters;
        }

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
                if (!secure)
                    if (token != null && (token.secret != null || token.httpsRequired))
                    {
                        secure = true;
                    }
                //Set actual version of API
                mPreparedParameters.Add(VKApiConst.VERSION, VKSdkVersion.API_VERSION);
                //Set preferred language for request
                mPreparedParameters.Add(VKApiConst.LANG, GetLang());

                if (secure)
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

        public WebRequest GetPreparedRequest()
        {
            var request = _requestFactory.RequestWithVkRequest(this);

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

                if (new[] { "ru", "en", "ua", "es", "fi", "de", "it" }.Contains(result))
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
                    VKSdk.instance().sdkListener().onCaptchaError(error.apiError);
                    return true;
                }
                if (error.apiError.errorCode == 16)
                {
                    VKAccessToken token = VKSdk.getAccessToken();
                    token.httpsRequired = true;
                    return true;
                }
                if (error.apiError.errorCode == 17)
                {
                    return true;
                }
            }

            return false;
        }


        public void setPreferredLang(string lang)
        {
            useSystemLanguage = false;
            mPreferredLang = lang;
        }
    }
}