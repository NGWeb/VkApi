#region usings

using System;
using Vk.SDK.Model;

#endregion

namespace Vk.SDK.Context
{
    public abstract class VKApiBase
    {
        /**
     * Selected methods group
     */
        private readonly string _mMethodGroup;

        protected VKApiBase()
        {
            string className = GetType().Name;
            if (className == null)
            {
                throw new Exception("Enclosing classes denied");
            }
            _mMethodGroup = className.Substring("VKApi".Length).ToLower();
        }

        protected VKRequest<T> PrepareRequest<T>(string methodName, VKParameters methodParameters) where T : VKApiModel
        {
            return PrepareRequest<T>(methodName, methodParameters, AbstractRequest.HttpMethod.GET);
        }

        protected VKRequest<T> PrepareRequest<T>(string methodName, VKParameters methodParameters,
            AbstractRequest.HttpMethod httpMethod) where T : VKApiModel
        {
            return new VKRequest<T>(string.Format("{0}.{1}", _mMethodGroup, methodName), methodParameters, httpMethod);
        }

        protected VkJsonRequest PrepareJsonRequest(string methodName, VKParameters methodParameters)
        {
            return PrepareJsonRequest(methodName, methodParameters, AbstractRequest.HttpMethod.GET);
        }

        protected VkJsonRequest PrepareJsonRequest(string methodName, VKParameters methodParameters,
            AbstractRequest.HttpMethod httpMethod)
        {
            return new VkJsonRequest(string.Format("{0}.{1}", _mMethodGroup, methodName), methodParameters, httpMethod);
        }
    }
}