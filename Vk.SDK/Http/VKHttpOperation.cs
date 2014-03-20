#region usings

using System;
using System.IO;
using System.Net;
using System.Text;

#endregion

namespace Vk.SDK.Http
{
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
        public readonly WebRequest Request;
        /**
     * Last exception throws while loading or parsing
     */
        protected Exception mLastException;

        /**
     * string representation of response
     */

        /**
     * Create new operation for loading prepared Http request. Requests may be prepared in RequestFactory
     *
     * @param uriRequest Prepared request
     */

        public VKHttpOperation(WebRequest uriRequest)
        {
            Request = uriRequest;
        }

        public string ResponseString { get; private set; }

        /**
     * Start current prepared http-operation for result
     */

        public override void Start()
        {
            OnBeginRequest();
            SetState(VKOperationState.Executing);
            using (var response = (HttpWebResponse)Request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    var responseEncoding = Encoding.GetEncoding(response.CharacterSet);
                    using (StreamReader sr = new StreamReader(response.GetResponseStream(), responseEncoding))
                    {
                        ResponseString = sr.ReadToEnd();
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
            Request.Abort();
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