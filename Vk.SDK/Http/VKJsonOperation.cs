#region usings

using System;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

#endregion

namespace Vk.SDK.Http
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
                string response = Encoding.Default.GetString(ResponseBytes);
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