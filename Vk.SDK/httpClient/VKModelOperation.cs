using System.ComponentModel;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Vk.SDK.model;

namespace Vk.SDK.httpClient
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
            var str = System.Text.Encoding.Default.GetString(ResponseBytes);
            parsedModel = JsonConvert.DeserializeObject<T>(str);
        }
    }
}
