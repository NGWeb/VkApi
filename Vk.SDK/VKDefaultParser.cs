using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Vk.SDK.model;
using Vk.SDK.Vk;

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
