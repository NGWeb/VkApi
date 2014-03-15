using Newtonsoft.Json.Linq;
using Vk.SDK.model;

namespace Vk.SDK
{
    public interface VKParser
    {
        VKApiModel CreateModel(JObject jsobject);
    }
}
