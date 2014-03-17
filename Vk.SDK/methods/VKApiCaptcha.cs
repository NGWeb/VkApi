namespace Vk.SDK.methods
{
    public class VKApiCaptcha : VKApiBase {
        public VKRequest Force() {
            return prepareRequest("force", null);
        }
    }
}
