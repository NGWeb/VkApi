using Newtonsoft.Json.Linq;

namespace Vk.SDK.photo
{
    public class VKUploadWallPhotoRequest : VKUploadPhotoBase
    {
        private static readonly long serialVersionUID = 4732771149932923938L;

        public VKUploadWallPhotoRequest(byte[] image, long userId, int groupId)
        {
            mUserId = userId;
            mGroupId = groupId;
            mImage = image;
        }

        public VKUploadWallPhotoRequest(VKUploadImage image, long userId, int groupId)
        {
            mUserId = userId;
            mGroupId = groupId;
            mImage = image.getTmpFile();
        }


        protected VKRequest getServerRequest()
        {
            return mGroupId != 0 ? VKApi.photos().getWallUploadServer(mGroupId) : VKApi.photos().getWallUploadServer();
        }


        protected VKRequest getSaveRequest(JObject response)
        {
            VKRequest saveRequest;
            try
            {
                saveRequest = VKApi.photos().saveWallPhoto(new VKParameters(VKJsonHelper.toMap(response)));
            }
            catch (JSONException e)
            {
                return null;
            }
            if (mUserId != 0)
                saveRequest.addExtraParameters(VKUtil.paramsFrom(VKApiConst.USER_ID, mUserId));
            if (mGroupId != 0)
                saveRequest.addExtraParameters(VKUtil.paramsFrom(VKApiConst.GROUP_ID, mGroupId));
            return saveRequest;
        }
    }
}
