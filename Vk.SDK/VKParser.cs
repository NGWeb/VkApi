#region usings

using Newtonsoft.Json.Linq;
using Vk.SDK.Model;

#endregion

namespace Vk.SDK
{
    public interface VKParser
    {
        VKApiModel CreateModel(JObject jsobject);
    }
}