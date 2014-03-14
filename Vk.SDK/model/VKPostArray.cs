namespace Vk.SDK.model
{
    public class VKPostArray : VKList<VKApiPost> {
    
        public VKApiModel parse(JObject response) {
            fill(response, VKApiPost.class);
            return this;
        }
    }
}
