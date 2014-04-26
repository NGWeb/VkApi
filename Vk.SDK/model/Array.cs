#region usings

using System.Collections.Generic;

#endregion

namespace Vk.SDK.Model
{
    public class Array<T> : IVKApiModel where T : IVKApiModel
    {
        public Array()
        {
            Items = new List<T>();
        }

        public int Count { get; set; }

        public List<T> Items { get; set; }
    }
}