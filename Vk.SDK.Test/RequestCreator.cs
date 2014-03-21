using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Vk.SDK.Http;

namespace Vk.SDK.Test
{
    class RequestCreator: IRequestCreator
    {
        public WebRequest Create(string url)
        {
            return WebRequest.Create(url);
        }
    }
}
