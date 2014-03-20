#region usings

using System;
using Vk.SDK.Http;

#endregion

namespace Vk.SDK
{
    public class VkJsonRequest : AbstractRequest
    {
        public VkJsonRequest(string method)
            : base(method)
        {
        }

        public VkJsonRequest(string method, VKParameters parameters)
            : base(method, parameters)
        {
        }

        public VkJsonRequest(string method, VKParameters parameters, HttpMethod httpMethod)
            : base(method, parameters, httpMethod)
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