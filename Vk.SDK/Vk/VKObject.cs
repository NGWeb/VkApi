using System;
using System.Collections.Generic;

namespace Vk.SDK.Vk
{
    public class VKObject
    {
        private static readonly Dictionary<long, VKObject> sRegisteredObjects = new Dictionary<long, VKObject>();
        private long mRegisteredObjectId = 0;

        /**
     * Returns object saved in local cache
     * @param registeredObjectId Registered object id
     * @return Object which was saved with registerObject() method
     */
        public static VKObject getRegisteredObject(long registeredObjectId)
        {
            return sRegisteredObjects[registeredObjectId];
        }

        /**
     * Saves object in local cache for future use. Always call unregisterObject() after use
     * @return Registered object id
     */
        public long registerObject()
        {
            Random rand = new Random();
            while (true)
            {
                long nextRand = rand.Next();
                if (sRegisteredObjects.ContainsKey(nextRand))
                    continue;
                if (nextRand == 0)
                    continue;
                sRegisteredObjects.Add(nextRand, this);
                mRegisteredObjectId = nextRand;
                return nextRand;
            }
        }

        /**
     * Unregister object from local cache.
     */
        public void unregisterObject()
        {
            sRegisteredObjects.Remove(mRegisteredObjectId);
            mRegisteredObjectId = 0;
        }

    }
}
