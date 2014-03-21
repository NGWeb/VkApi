using System.Net;

namespace Vk.SDK.Http
{
    public interface IRequestCreator
    {
        WebRequest Create(string url);
    }
}