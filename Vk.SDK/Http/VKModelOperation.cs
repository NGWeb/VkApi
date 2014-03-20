#region usings

using System.Net;
using System.Text;
using Newtonsoft.Json;
using Vk.SDK.Model;

#endregion

namespace Vk.SDK.Http
{
    public class VKModelOperation<T> : VKHttpOperation where T : VKApiModel
    {
        public T parsedModel;

        /**
     * Create new model operation
     * @param uriRequest Prepared request
     * @param modelClass Model for parsing response
     */

        public VKModelOperation(WebRequest uriRequest)
            : base(uriRequest)
        {
            FinishRequest += PostExecution;
        }

        protected void PostExecution(object sender)
        {
            var str = Encoding.Default.GetString(ResponseBytes);
            parsedModel = JsonConvert.DeserializeObject<T>(str);
        }
    }
}