#region usings

using System.Collections.Generic;

#endregion

namespace Vk.SDK.Model
{
    public abstract class Array<T> : IVKApiModel where T : IVKApiModel
    {
        private int count;
        private List<T> items;
    }
}