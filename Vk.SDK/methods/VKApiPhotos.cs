using Vk.SDK;
using Vk.SDK.methods;
using Vk.SDK.model;

public class VKApiPhotos : VKApiBase
{
    public VKRequest getUploadServer(long albumId)
    {
        return prepareRequest("getUploadServer", VKUtil.paramsFrom(VKApiConst.ALBUM_ID, albumId));
    }

    public VKRequest getUploadServer(long albumId, long groupId)
    {
        return prepareRequest("getUploadServer", VKUtil.paramsFrom(VKApiConst.ALBUM_ID, albumId, VKApiConst.GROUP_ID, groupId));
    }

    public VKRequest getWallUploadServer()
    {
        return prepareRequest("getWallUploadServer", null);
    }

    public VKRequest getWallUploadServer(long groupId)
    {
        return prepareRequest("getWallUploadServer", VKUtil.paramsFrom(VKApiConst.GROUP_ID, groupId));
    }

    public VKRequest saveWallPhoto(VKParameters parameters)
    {
        return prepareRequest("saveWallPhoto", parameters, VKRequest.HttpMethod.POST, typeof(VKPhotoArray));

    }

    public VKRequest save(VKParameters parameters)
    {
        return prepareRequest("save", parameters, VKRequest.HttpMethod.POST, typeof(VKPhotoArray));
    }
}
