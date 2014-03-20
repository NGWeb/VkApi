#region usings

using System;
using System.IO;
using Newtonsoft.Json.Linq;
using Vk.SDK.Model;
using Vk.SDK.Util;

#endregion

namespace Vk.SDK.Photo
{
    public class VKUploadWallPhotoRequest : VKUploadPhotoBase<VKPhotoArray>
    {
        public VKUploadWallPhotoRequest(FileInfo[] image, long userId, int groupId) : base("")
        {
            mUserId = userId;
            mGroupId = groupId;
            mImage = image;
        }

        public VKUploadWallPhotoRequest(VKUploadImage image, long userId, int groupId) : base("")
        {
            mUserId = userId;
            mGroupId = groupId;
            mImage = new[] {image.mImageData};
        }


        protected override AbstractRequest getServerRequest()
        {
            return mGroupId != 0 ? VKApi.photos().getWallUploadServer(mGroupId) : VKApi.photos().getWallUploadServer();
        }


        protected override VKRequest<VKPhotoArray> getSaveRequest(JObject response)
        {
            VKRequest<VKPhotoArray> saveRequest =
                VKApi.photos().saveWallPhoto(new VKParameters(VKJsonHelper.toMap(response)));
            if (mUserId != 0)
                saveRequest.addExtraParameters(VKUtil.paramsFrom(VKApiConst.USER_ID, mUserId));
            if (mGroupId != 0)
                saveRequest.addExtraParameters(VKUtil.paramsFrom(VKApiConst.GROUP_ID, mGroupId));
            return saveRequest;
        }

        public override void Cancel()
        {
            throw new NotImplementedException();
        }

        public override object GetResponse()
        {
            throw new NotImplementedException();
        }
    }
}