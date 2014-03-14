namespace Vk.SDK.model
{
    public class VKApiCommunityArray : VKList<VKApiCommunityFull> {
    
        public VKApiModel parse(JSONObject response) {
            fill(response, VKApiCommunityFull.class);
            return this;
        }
    }
}
