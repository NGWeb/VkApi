#region usings

using Vk.SDK.Model;
using Vk.SDK.Util;

#endregion

namespace Vk.SDK.Context
{
    public class PhotosService : VKApiBase, IPhotosService
    {
        public VkJsonRequest GetUploadServer(long albumId)
        {
            return PrepareJsonRequest("getUploadServer", VKUtil.paramsFrom(VKApiConst.ALBUM_ID, albumId));
        }

        public VkJsonRequest GetUploadServer(long albumId, long groupId)
        {
            return PrepareJsonRequest("getUploadServer",
                VKUtil.paramsFrom(VKApiConst.ALBUM_ID, albumId, VKApiConst.GROUP_ID, groupId));
        }

        public VkJsonRequest GetWallUploadServer()
        {
            return PrepareJsonRequest("getWallUploadServer", null);
        }

        public VkJsonRequest GetWallUploadServer(long groupId)
        {
            return PrepareJsonRequest("getWallUploadServer", VKUtil.paramsFrom(VKApiConst.GROUP_ID, groupId));
        }

        public VKRequest<VKPhotoArray> SaveWallPhoto(VKParameters parameters)
        {
            return PrepareRequest<VKPhotoArray>("saveWallPhoto", parameters, AbstractRequest.HttpMethod.POST);
        }

        public VKRequest<VKPhotoArray> Save(VKParameters parameters)
        {
            return PrepareRequest<VKPhotoArray>("save", parameters, AbstractRequest.HttpMethod.POST);
        }
    }
}