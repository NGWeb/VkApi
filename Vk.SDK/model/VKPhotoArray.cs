using Newtonsoft.Json.Linq;

namespace Vk.SDK.model
{
    public class VKPhotoArray : VKList<VKApiPhoto> {
    
        public VKApiModel parse(JObject response) {
            fill(response, typeof(VKApiPhoto));
            return this;
        }
    }
}
