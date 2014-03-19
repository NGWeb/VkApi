using Vk.SDK;
using Vk.SDK.methods;
using Vk.SDK.model;
using Vk.SDK.Util;

public class VKApiPhotos : VKApiBase
{
    public VkJsonRequest getUploadServer(long albumId)
    {
        return PrepareJsonRequest("getUploadServer", VKUtil.paramsFrom(VKApiConst.ALBUM_ID, albumId));
    }

    public VkJsonRequest getUploadServer(long albumId, long groupId)
    {
        return PrepareJsonRequest("getUploadServer", VKUtil.paramsFrom(VKApiConst.ALBUM_ID, albumId, VKApiConst.GROUP_ID, groupId));
    }

    public VkJsonRequest getWallUploadServer()
    {
        return PrepareJsonRequest("getWallUploadServer", null);
    }

    public VkJsonRequest getWallUploadServer(long groupId)
    {
        return PrepareJsonRequest("getWallUploadServer", VKUtil.paramsFrom(VKApiConst.GROUP_ID, groupId));
    }

    public VKRequest<VKPhotoArray> saveWallPhoto(VKParameters parameters)
    {
        return prepareRequest<VKPhotoArray>("saveWallPhoto", parameters, AbstractRequest.HttpMethod.POST);

    }

    public VKRequest<VKPhotoArray> save(VKParameters parameters)
    {
        return prepareRequest<VKPhotoArray>("save", parameters, AbstractRequest.HttpMethod.POST);
    }
}
