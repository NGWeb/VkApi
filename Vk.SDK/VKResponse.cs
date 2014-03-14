namespace Vk.SDK
{
    public class VKResponse {
        /**
     * Request which caused response
     */
        public VKRequest request;
        /**
     * Json content of response. Can be array or object.
     */
        public JSONObject json;
        /**
     * Model parsed from response
     */
        public object parsedModel;
    }
}
