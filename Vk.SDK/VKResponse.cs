using Newtonsoft.Json.Linq;

namespace Vk.SDK
{
    public class VKResponse {
        /**
     * Request which caused response
     */
        public AbstractRequest request;
        /**
     * Json content of response. Can be array or object.
     */
        public JObject json;
        /**
     * Model parsed from response
     */
        public object parsedModel;
    }
}
