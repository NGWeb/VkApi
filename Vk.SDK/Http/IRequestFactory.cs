using System.IO;
using System.Net;

namespace Vk.SDK.Http
{
    public interface IRequestFactory
    {
        WebRequest RequestWithVkRequest(AbstractRequest vkRequest);
        WebRequest FileUploadRequest(string uploadUrl, params FileInfo[] files);
    }
}