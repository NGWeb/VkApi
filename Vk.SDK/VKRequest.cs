using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Vk.SDK.httpClient;
using Vk.SDK.model;
using Vk.SDK.Util;
using Vk.SDK.Vk;

namespace Vk.SDK
{
    public class VKRequest<T> : VKObject where T:VKApiModel
    {
        private readonly string _method;

        public event OnError Error;
        public enum VKProgressType {
            Download,
            Upload
        }

        public enum HttpMethod {
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
        private VKAbstractOperation<T> mLoadingOperation;
        /**
     * How much times request was loaded
     */
        private int mAttemptsUsed;

        /**
     * Requests that should be called after current request.
     */
        private List<VKRequest<T>> mPostRequestsQueue;
        /**
     * Class for model parsing
     */
        private System.Type mModelClass;

        /**
     * Response parser
     */
        private VKParser mModelParser;

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
        public HttpMethod getHttpMethod() {
            return httpMethod;
        }

        /**
     * @return Returns list of method parameters (without common parameters)
     */
        public VKParameters getMethodParameters() {
            return mMethodParameters;
        }

        /**
     * Creates new request with parameters. See documentation for methods here https://vk.com/dev/methods
     *
     * @param method API-method name, e.g. audio.get
     */
        public VKRequest(string method): this(method, null) {
        }

        /**
     * Creates new request with parameters. See documentation for methods here https://vk.com/dev/methods
     *
     * @param method     API-method name, e.g. audio.get
     * @param parameters method parameters
     */
        public VKRequest(string method, VKParameters parameters) :this(method, parameters, HttpMethod.GET) {
      }

        /**
     * Creates new request with parameters. See documentation for methods here https://vk.com/dev/methods
     *
     * @param method     API-method name, e.g. audio.get
     * @param parameters method parameters
     * @param httpMethod HTTP method for execution, e.g. GET, POST
     */
        public VKRequest(string method, VKParameters parameters, HttpMethod httpMethod) {
            this.methodName = method;
            if (parameters == null) {
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
        public void executeAfterRequest(VKRequest request) {
            request.addPostRequest(this);
        }

        private void addPostRequest(VKRequest postRequest) {
            if (mPostRequestsQueue == null) {
                mPostRequestsQueue = new List<VKRequest<T>>();
            }
            mPostRequestsQueue.Add(postRequest);
        }

        public VKParameters getPreparedParameters() {
            if (mPreparedParameters == null) {
                mPreparedParameters = new VKParameters(mMethodParameters);

                //Set current access token from SDK object
                VKAccessToken token = VKSdk.getAccessToken();
                if (token != null)
                    mPreparedParameters.Add(VKApiConst.ACCESS_TOKEN, token.accessToken);
                if (!this.secure)
                    if (token != null && (token.secret != null || token.httpsRequired)) {
                        this.secure = true;
                    }
                //Set actual version of API
                mPreparedParameters.Add(VKApiConst.VERSION, VKSdkVersion.API_VERSION);
                //Set preferred language for request
                mPreparedParameters.Add(VKApiConst.LANG, getLang());

                if (this.secure) {
                    //If request is secure, we need all urls as https
                    mPreparedParameters.Add(VKApiConst.HTTPS, "1");
                }
                if (token != null && token.secret != null) {
                    //If it not, generate signature of request
                    string sig = generateSig(token);
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
        public WebRequest getPreparedRequest() {
            var request = VKHttpClient.requestWithVkRequest(this);
            if (request != null) 
                return request;
            var error = new VKError(VKError.VK_API_REQUEST_NOT_PREPARED);
            Error(this,error);
            return null;
        }

         public void start() {
            if ((mLoadingOperation = getOperation()) == null) {
                return;
            }
            VKHttpClient.enqueueOperation(mLoadingOperation);
        }
          public void cancel() {
            if (mLoadingOperation != null)
                mLoadingOperation.cancel();
            else
               Error(this,new VKError(VKError.VK_API_CANCELED));
        }

          public void repeat() {
            this.mAttemptsUsed = 0;
            this.mPreparedParameters = null;
            start();
        }

        public void addExtraParameter(string key, object value) {
            mMethodParameters.Add(key, value);
        }

          private string getLang() {
            string result = mPreferredLang;
            if (useSystemLanguage)
            {
                result = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToLower();

                if (result.Equals("uk")) {
                    result = "ua";
                }

                if (new string[]{"ru", "en", "ua", "es", "fi", "de", "it"}.Contains(result)) {
                        result = mPreferredLang;
                    }
            }
            return result;
        }

           private string generateSig(VKAccessToken token) {
            //Read description here https://vk.com/dev/api_nohttps
            //At first, we need key-value pairs in order of request
            string querystring = VKstringJoiner.joinParams(mPreparedParameters);
            //Then we generate "request string" /method/{METHOD_NAME}?{GET_PARAMS}{POST_PARAMS}
            querystring = string.Format("/method/{0}?{1}", methodName, querystring);
            return VKUtil.md5(querystring + token.secret);

        }

        public VKAbstractOperation<T> getOperation() {
            if (this.parseModel) {
                if (this.mModelClass != null) {
                    mLoadingOperation = new VKModelOperation<T>(getPreparedRequest());
                } else if (this.mModelParser != null){
                    mLoadingOperation = new VKModelOperation<T>(getPreparedRequest(), this.mModelParser);
                }
            }
            if (mLoadingOperation == null)
                mLoadingOperation = new VKJsonOperation(getPreparedRequest());

            mLoadingOperation.
            ((VKJsonOperation) mLoadingOperation).setJsonOperationListener( (operation,response)=> {
  
                if (response.GetValue("error")!=null) {
                         VKError error = JsonConvert.DeserializeObject<VKError>(response.GetValue("error").ToString());
                return;
        }
            provideResponse(response,
                mLoadingOperation instanceof VKModelOperation ?
                    ((VKModelOperation) mLoadingOperation).parsedModel :null);
        }

                    
        public void onError(VKJsonOperation operation, VKError error) {
            if (error.errorCode != VKError.VK_API_ERROR &&
                operation != null && operation.response != null &&
                operation.response.getStatusLine().getStatusCode() == 200) {
                    provideResponse(operation.getResponseJson(), null);
                    return;
                }
            if (attempts == 0 || ++mAttemptsUsed < attempts) {
                if (requestListener != null)
                    requestListener.attemptFailed(VKRequest.this, mAttemptsUsed, attempts);
                VKAbstractOperation.postInMainQueueDelayed(new Runnable() {
                                
                public void run() {
    start();
                }
            });
                return;
            }
            provideError(error);
        }
        });
            return mLoadingOperation;
        }

        /**
     * Starts loading of prepared request. You can use it instead of executeWithResultBlock
     */
       

        /**
     * Repeats this request with initial parameters and blocks.
     * Used attempts will be set to 0.
     */
      

        /**
     * Cancel current request. Result will be not passed. errorBlock will be called with error code
     */
      

        /**
     * Method used for errors processing
     *
     * @param error error caused by this request
     */
        private void provideError(VKError error) {
            error.request = this;
            if (requestListener != null) {
                requestListener.onError(error);
            }
            if (mPostRequestsQueue != null && mPostRequestsQueue.size() > 0) {
                foreach (VKRequest postRequest in mPostRequestsQueue)
                if (postRequest.requestListener != null) 
                postRequest.requestListener.onError(error);
            }
        }

        /**
     * Method used for response processing
     *
     * @param jsonResponse response from API
     * @param parsedModel  model parsed from json
     */
        private void provideResponse(JObject jsonResponse, object parsedModel) {
        VKResponse response = new VKResponse();
            response.request = this;
            response.json = jsonResponse;
            response.parsedModel = parsedModel;

            if (mPostRequestsQueue != null && mPostRequestsQueue.size() > 0) {
                for (VKRequest request : mPostRequestsQueue) {
                    request.start();
                }
            }

            if (requestListener != null) {
                requestListener.onComplete(response);
            }
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
        public void addExtraParameters(VKParameters extraParameters) {
            mMethodParameters.putAll(extraParameters);
        }

     

        private bool processCommonError(VKError error) {
            if (error.errorCode == VKError.VK_API_ERROR) {
                if (error.apiError.errorCode == 14) {
                    error.apiError.request = this;
                    this.mLoadingOperation = null;
                    VKSdk.instance().sdkListener().onCaptchaError(error.apiError);
                    return true;
                } else if (error.apiError.errorCode == 16) {
                    VKAccessToken token = VKSdk.getAccessToken();
                    token.httpsRequired = true;
                    repeat();
                    return true;
                } else if (error.apiError.errorCode == 17) {
                    Intent i = new Intent(VKUIHelper.getTopActivity(), VKOpenAuthActivity.class);
                    i.putExtra(VKOpenAuthActivity.VK_EXTRA_VALIDATION_URL, error.apiError.redirectUri);
                    VKUIHelper.getTopActivity().startActivityForResult(i, VKSdk.VK_SDK_REQUEST_CODE);
                    return true;
                }
            }

            return false;
        }

      

        /**
     * Sets preferred language for api results.
     * @param lang Two letter language code. May be "ru", "en", "ua", "es", "fi", "de", "it"
     */
        public void setPreferredLang(string lang) {
            useSystemLanguage = false;
            mPreferredLang = lang;
        }

      
    public static VKRequest getRegisteredRequest(long requestId) {
        return (VKRequest) getRegisteredObject(requestId);
    }
}}

        public abstract class VKRequestListener{
     
            public abstract void onComplete(VKResponse response) {}

        /**
         * Called when request has failed attempt, and ready to do next attempt
         *
         * @param request       Failed request
         * @param attemptNumber Number of failed attempt, started from 1
         * @param totalAttempts Total request attempts defined for request
         */
        public void attemptFailed(VKRequest request, int attemptNumber, int totalAttempts) {
        }

        /**
         * Called immediately if there was API error, or after <b>attempts</b> tries if there was an HTTP error
         *
         * @param error error for VKRequest
         */
        public void onError(VKError error) {
        }

        /**
         * Specify progress for uploading or downloading. Useless for text requests (because gzip encoding bytesTotal will always return -1)
         *
         * @param progressType type of progress (upload or download)
         * @param bytesLoaded  total bytes loaded
         * @param bytesTotal   total bytes suppose to be loaded
         */
        public void onProgress(VKRequest.VKProgressType progressType, long bytesLoaded, long bytesTotal) {
        }
    }