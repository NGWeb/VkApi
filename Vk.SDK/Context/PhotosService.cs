#region usings

using Vk.SDK.Http;
using Vk.SDK.Interfaces;
using Vk.SDK.Model;
using Vk.SDK.Util;

#endregion

namespace Vk.SDK.Context
{
    public class PhotosService : VKApiBase, IPhotosService
    {
        public PhotosService(IRequestFactory factory) : base(factory)
        {
        }

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

        public VKRequest<PhotoArray> SaveWallPhoto(VKParameters parameters)
        {
            return PrepareRequest<PhotoArray>("saveWallPhoto", parameters, AbstractRequest.HttpMethod.POST);
        }

        public VKRequest<PhotoArray> Save(VKParameters parameters)
        {
            return PrepareRequest<PhotoArray>("save", parameters, AbstractRequest.HttpMethod.POST);
        }
    }
}