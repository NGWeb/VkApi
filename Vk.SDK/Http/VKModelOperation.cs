#region usings

using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Vk.SDK.Converters;
using Vk.SDK.Model;

#endregion

namespace Vk.SDK.Http
{
    public class VKModelOperation<T> : VKHttpOperation where T : IVKApiModel
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
            JObject val = JObject.Parse(ResponseString);
            var serializer = new JsonSerializer();
          //  serializer.Converters.Add(new AttachmentListConverter());
            serializer.Converters.Add(new AttachmentConverter());
            parsedModel = val.GetValue("response").ToObject<T>(serializer);
        }
    }
}