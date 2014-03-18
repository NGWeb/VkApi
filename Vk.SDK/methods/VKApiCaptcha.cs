using Vk.SDK.model;

namespace Vk.SDK.methods
{
    public class VKApiCaptcha : VKApiBase<VKApiModel> {
        public VKRequest<VKApiModel> Force() {
            return prepareRequest("force", null);
        }
    }
}
