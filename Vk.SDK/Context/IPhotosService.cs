using Vk.SDK.Model;

namespace Vk.SDK.Context
{
    public interface IPhotosService
    {
        VkJsonRequest GetUploadServer(long albumId);
        VkJsonRequest GetUploadServer(long albumId, long groupId);
        VkJsonRequest GetWallUploadServer();
        VkJsonRequest GetWallUploadServer(long groupId);
        VKRequest<PhotoArray> SaveWallPhoto(VKParameters parameters);
        VKRequest<PhotoArray> Save(VKParameters parameters);
    }
}