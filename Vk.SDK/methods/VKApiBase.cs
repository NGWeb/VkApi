using System;
using Newtonsoft.Json.Linq;
using Vk.SDK.model;

namespace Vk.SDK.methods
{
    public class VKApiBase
    {
        /**
     * Selected methods group
     */
        private string mMethodGroup;

        public VKApiBase()
        {
            string className = this.getClass().getSimpleName();
            if (className == null)
            {
                throw new Exception("Enclosing classes denied");
            }
            mMethodGroup = className.substring("VKApi".length()).toLowerCase();
        }

        protected VKRequest<T> prepareRequest<T>(string methodName, VKParameters methodParameters) where T : VKApiModel
        {
            return prepareRequest<T>(methodName, methodParameters, AbstractRequest.HttpMethod.GET);
        }
        protected VKRequest<T> prepareRequest<T>(string methodName, VKParameters methodParameters, AbstractRequest.HttpMethod httpMethod) where T : VKApiModel
        {
            return new VKRequest<T>(string.Format("{0}.{1}", mMethodGroup, methodName), methodParameters, httpMethod);
        }
    }
}
