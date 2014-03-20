#region usings

using System.Collections.Generic;
using Vk.SDK.Util;

#endregion

namespace Vk.SDK
{
    public class VKParameters : Dictionary<string, object>
    {
        public VKParameters()
        {
        }

        public VKParameters(IDictionary<string, object> fromMap) : base(fromMap)
        {
        }

        public static VKParameters from(params object[] objects)
        {
            return VKUtil.paramsFrom(objects);
        }
    }
}