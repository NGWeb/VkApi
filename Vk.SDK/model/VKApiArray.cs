#region usings

using System.Collections.Generic;

#endregion

namespace Vk.SDK.Model
{
    public abstract class VKApiArray<T> : VKApiModel where T : VKApiModel
    {
        private int count;
        private List<T> items;
    }
}