namespace Vk.SDK.model
{
    public class VKPostArray : VKList<VKApiPost> {
    
        public VKApiModel parse(JSONObject response) {
            fill(response, VKApiPost.class);
            return this;
        }
    }
}
