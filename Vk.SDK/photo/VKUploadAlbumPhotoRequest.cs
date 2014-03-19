using Newtonsoft.Json.Linq;
using Vk.SDK.Util;

namespace Vk.SDK.photo
{
    public class VKUploadAlbumPhotoRequest : VKUploadPhotoBase {
     
        public VKUploadAlbumPhotoRequest(byte[] image, long albumId, long groupId) {
            mAlbumId = albumId;
            mGroupId = groupId;
            mImage = image;
        }

        public VKUploadAlbumPhotoRequest(VKUploadImage image, long albumId, long groupId) {
            super();
            mAlbumId = albumId;
            mGroupId = groupId;
            mImage = image.getTmpFile();
        }

        protected VKRequest getServerRequest() {
            if (mAlbumId != 0 && mGroupId != 0)
                return VKApi.photos().getUploadServer(mAlbumId, mGroupId);
            return VKApi.photos().getUploadServer(mAlbumId);
        }

    
        protected VKRequest getSaveRequest(JObject response) {
            VKRequest saveRequest;
            try {
                saveRequest = VKApi.photos().save(new VKParameters(VKJsonHelper.toMap(response)));
            } catch (JSONException e) {
                return null;
            }
            if (mAlbumId != 0)
                saveRequest.addExtraParameters(VKUtil.paramsFrom(VKApiConst.ALBUM_ID, mAlbumId));
            if (mGroupId != 0)
                saveRequest.addExtraParameters(VKUtil.paramsFrom(VKApiConst.GROUP_ID, mGroupId));
            return saveRequest;

        }

    }
}
