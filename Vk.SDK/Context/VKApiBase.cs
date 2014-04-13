#region usings

using System;
using Vk.SDK.Http;
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
        private readonly IRequestFactory _factory;

        protected VKApiBase(IRequestFactory factory)
        {
            _factory = factory;
            string className = GetType().Name;
            if (className == null)
            {
                throw new Exception("Enclosing classes denied");
            }
            _mMethodGroup = className.Replace("Service","").ToLower();
        }

        protected VKRequest<T> PrepareRequest<T>(string methodName, VKParameters methodParameters) where T : IVKApiModel
        {
            return PrepareRequest<T>(methodName, methodParameters, AbstractRequest.HttpMethod.GET);
        }

        protected VKRequest<T> PrepareRequest<T>(string methodName, VKParameters methodParameters,
            AbstractRequest.HttpMethod httpMethod) where T : IVKApiModel
        {
            return new VKRequest<T>(string.Format("{0}.{1}", _mMethodGroup, methodName), methodParameters, httpMethod,_factory);
        }

        protected VkJsonRequest PrepareJsonRequest(string methodName, VKParameters methodParameters)
        {
            return PrepareJsonRequest(methodName, methodParameters, AbstractRequest.HttpMethod.GET);
        }

        protected VkJsonRequest PrepareJsonRequest(string methodName, VKParameters methodParameters,
            AbstractRequest.HttpMethod httpMethod)
        {
            return new VkJsonRequest(string.Format("{0}.{1}", _mMethodGroup, methodName), methodParameters, httpMethod,_factory);
        }
    }
}