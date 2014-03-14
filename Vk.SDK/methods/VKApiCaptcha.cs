namespace Vk.SDK.methods
{
    public class VKApiCaptcha : VKApiBase {
        public VKRequest force() {
            return prepareRequest("force", null);
        }
    }
}
