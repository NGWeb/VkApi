using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Vk.SDK.httpClient
{
    public class VKJsonOperation : VKAbstractOperation<JObject>
    {
        private JObject mResponseJson;

        /**
     * Create new operation with request
     * @param uriRequest Request prepared manually or with VKHttpClient
     */
        public VKJsonOperation(WebRequest uriRequest) : base(uriRequest) { }


        /**
     * Generate JSON-response for current operation
     * @return Parsed JSON object from response string
     */
        public JObject getResponseJson()
        {
            if (mResponseJson == null)
            {
                string response = getResponsestring();
                if (response == null)
                    return null;
                try
                {
                    mResponseJson = new JObject(response);
                }
                catch (Exception e)
                {
                    mLastException = e;
                }
            }
            return mResponseJson;
        }


        protected bool postExecution()
        {
            if (!base.postExecution())
                return false;
            mResponseJson = getResponseJson();
            return true;
        }

        /**
     * Sets that json operation listener
     * @param listener Listener object for that operation
     */
        //    public void setJsonOperationListener(Func<VKJsonOperation ,JObject, Void> expression) {
        //        if (listener == null) {
        //            super.setCompleteListener(null);
        //            return;
        //        }

        //        this.setCompleteListener(new VKOperationCompleteListener() {

        //        public void onComplete() {
        //if (mLastException != null) {
        //listener.onError(VKJsonOperation.this, generateError(mLastException));
        //        } else {
        //            listener.onComplete(VKJsonOperation, mResponseJson);
        //        }
        //    }
        //    });
        //    }

        public override void start()
        {
            throw new NotImplementedException();
        }
    }
}
