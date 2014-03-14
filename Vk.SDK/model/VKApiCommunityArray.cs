using Newtonsoft.Json.Linq;

namespace Vk.SDK.model
{
    public class VKApiCommunityArray : VKList<VKApiCommunityFull> {
    
        public VKApiModel parse(JObject response) {
            fill(response, VKApiCommunityFull.class);
            return this;
        }
    }
}
