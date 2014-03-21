#region usings

using System;
using Vk.SDK.Http;

#endregion

namespace Vk.SDK
{
    public class VkJsonRequest : AbstractRequest
    {
        public VkJsonRequest(string method, IRequestFactory factory)
            : base(method, factory)
        {
        }

        public VkJsonRequest(string method, VKParameters parameters, IRequestFactory factory)
            : base(method, parameters, factory)
        {
        }

        public VkJsonRequest(string method, VKParameters parameters, HttpMethod httpMethod, IRequestFactory factory)
            : base(method, parameters, httpMethod, factory)
        {
        }

        public override void Cancel()
        {
            throw new NotImplementedException();
        }

        public override object GetResponse()
        {
            var operation = new VKJsonOperation(GetPreparedRequest());
            operation.Start();
            return operation.getResponseJson();
        }
    }
}