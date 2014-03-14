using Newtonsoft.Json.Linq;

namespace Vk.SDK.model
{
    public class VKUsersArray : VKList<VKApiUserFull>
    {

        public VKApiModel parse(JObject response)
        {
            fill(response, typeof(VKApiUserFull));
            return this;
        }
    }
}
