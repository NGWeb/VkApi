using Vk.SDK.Model;

namespace Vk.SDK.Context
{
    public interface IPhotosService
    {
        VkJsonRequest GetUploadServer(long albumId);
        VkJsonRequest GetUploadServer(long albumId, long groupId);
        VkJsonRequest GetWallUploadServer();
        VkJsonRequest GetWallUploadServer(long groupId);
        VKRequest<VKPhotoArray> SaveWallPhoto(VKParameters parameters);
        VKRequest<VKPhotoArray> Save(VKParameters parameters);
    }
}