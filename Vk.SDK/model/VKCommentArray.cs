using Newtonsoft.Json.Linq;

namespace Vk.SDK.model
{
    public class VKCommentArray : VKList<VKApiComment>
    {

        public VKApiModel parse(JObject response)
        {
            fill(response, typeof(VKApiComment));
            return this;
        }
    }
}