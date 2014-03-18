using System;
using System.IO;
using System.Net;

namespace Vk.SDK.httpClient
{

    public delegate void BeginRequestDelegate(object sender);

    public delegate void FinishRequestDelegate(object sender);

    public delegate void CompleteDelegate(object sender);


    public class VKHttpOperation : VKAbstractOperation
    {

        #region events
        public event BeginRequestDelegate BeginRequest;

        protected virtual void OnBeginRequest()
        {
            BeginRequestDelegate handler = BeginRequest;
            if (handler != null) handler(this);
        }

        public event FinishRequestDelegate FinishRequest;

        protected virtual void OnFinishRequest()
        {
            FinishRequestDelegate handler = FinishRequest;
            if (handler != null) handler(this);
        }

        public event CompleteDelegate Complete;

        protected virtual void OnComplete()
        {
            CompleteDelegate handler = Complete;
            if (handler != null) handler(this);
        }
        #endregion

        /**
     * Request initialized this object
     */
        private readonly WebRequest _request;
        /**
     * Last exception throws while loading or parsing
     */
        protected Exception mLastException;

        /**
     * string representation of response
     */
        public byte[] ResponseBytes { get; private set; }

        /**
     * Create new operation for loading prepared Http request. Requests may be prepared in VKHttpClient
     *
     * @param uriRequest Prepared request
     */
        public VKHttpOperation(WebRequest uriRequest)
        {
            _request = uriRequest;
        }
        
        /**
     * Start current prepared http-operation for result
     */
        public override void Start()
        {
            OnBeginRequest();
            SetState(VKOperationState.Executing);
            using (var response = _request.GetResponse())
            {

                using (var stream = response.GetResponseStream())
                {
                    using (var outputStream = new MemoryStream())
                    {
                        if (stream != null)
                            stream.CopyTo(outputStream);
                        outputStream.Flush();
                        ResponseBytes = outputStream.ToArray();
                        outputStream.Close();
                    }
                }
            }
            OnFinishRequest();
            OnComplete();
        }
        
        /**
        * Cancel current operation execution
        */

        public override void Cancel()
        {
            _request.Abort();
            base.Cancel();
        }

        /**
     * Get operation response data
     * @return Bytes of response
     */
        protected VKError generateError(Exception e)
        {
            VKError error = new VKError(VKError.VK_API_REQUEST_HTTP_FAILED);
            error.errorMessage = e.Message;
            if (error.errorMessage == null)
                error.errorMessage = e.Source;
            error.httpError = e;
            return error;
        }
    }
}
