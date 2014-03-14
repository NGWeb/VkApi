namespace Vk.SDK.photo
{
    public class VKUploadWallPhotoRequest : VKUploadPhotoBase
    {
        private static readonly long serialVersionUID = 4732771149932923938L;

        public VKUploadWallPhotoRequest(File image, long userId, int groupId)
        {
            mUserId = userId;
            mGroupId = groupId;
            mImage = image;
        }

        public VKUploadWallPhotoRequest(VKUploadImage image, long userId, int groupId)
        {
            super();
            mUserId = userId;
            mGroupId = groupId;
            mImage = image.getTmpFile();
        }


        protected VKRequest getServerRequest()
        {
            if (mGroupId != 0)
                return VKApi.photos().getWallUploadServer(mGroupId);
            else
                return VKApi.photos().getWallUploadServer();
        }


        protected VKRequest getSaveRequest(JSONObject response)
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
