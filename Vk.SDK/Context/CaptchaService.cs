using Vk.SDK.Http;

namespace Vk.SDK.Context
{
    public class CaptchaService : VKApiBase
    {
        //public VKRequest<VKApiModel> Force() {
        //    return Pre("force", null);
        //}
        public CaptchaService(IRequestFactory factory) : base(factory)
        {
        }
    }
}