#region usings

using Newtonsoft.Json.Linq;
using Vk.SDK.Model;

#endregion

namespace Vk.SDK
{
    public interface VKParser
    {
        IVKApiModel CreateModel(JObject jsobject);
    }
}