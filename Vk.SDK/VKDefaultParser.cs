#region usings

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Vk.SDK.Model;

#endregion

namespace Vk.SDK
{
    public class VKDefaultParser<T> : VKParser where T : VKApiModel
    {
        public VKApiModel CreateModel(JObject jsobject)
        {
            VKApiModel model = JsonConvert.DeserializeObject<T>(jsobject.ToString());
            return model;
        }
    }
}