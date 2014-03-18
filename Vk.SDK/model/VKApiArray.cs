using System.Collections.Generic;

namespace Vk.SDK.model
{
    public abstract class VKApiArray<T> : VKApiModel where T : VKApiModel
    {
        private List<T> items;
        private int count;
    }
}
