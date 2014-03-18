using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Vk.SDK.httpClient
{
    public class VKJsonOperation : VKHttpOperation
    {
        private JObject mResponseJson;

        /**
     * Create new operation with request
     * @param uriRequest Request prepared manually or with RequestFactory
     */

        public VKJsonOperation(WebRequest uriRequest) : base(uriRequest)
        {
            FinishRequest += postExecution;
        }


        /**
     * Generate JSON-response for current operation
     * @return Parsed JSON object from response string
     */
        public JObject getResponseJson()
        {
            if (mResponseJson == null)
            {
                string response = System.Text.Encoding.Default.GetString(ResponseBytes);
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


        protected void postExecution(object sender)
        {
            mResponseJson = getResponseJson();
        }
    }
}
