#region usings

using Newtonsoft.Json.Linq;

#endregion

namespace Vk.SDK
{
    public class VKResponse
    {
        /**
     * Request which caused response
     */
        /**
     * Json content of response. Can be array or object.
     */
        public JObject json;
        /**
     * Model parsed from response
     */
        public object parsedModel;
        public AbstractRequest request;
    }
}