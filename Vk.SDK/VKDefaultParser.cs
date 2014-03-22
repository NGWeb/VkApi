 #region usings

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Vk.SDK.Model;

#endregion

namespace Vk.SDK
{
    public class VKDefaultParser<T> : VKParser where T : IVKApiModel
    {
        public IVKApiModel CreateModel(JObject jsobject)
        {
            IVKApiModel model = JsonConvert.DeserializeObject<T>(jsobject.ToString());
            return model;
        }
    }
}