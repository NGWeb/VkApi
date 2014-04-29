#region usings

using System;
using System.IO;
using Newtonsoft.Json.Linq;
using Vk.SDK.Context;
using Vk.SDK.Http;
using Vk.SDK.Interfaces;
using Vk.SDK.Model;
using Vk.SDK.Util;

#endregion

namespace Vk.SDK.Photo
{
    public class VKUploadWallPhotoRequest : VKUploadPhotoBase<PhotoArray>
    {
        private readonly IPhotosService _photosService;
        public VKUploadWallPhotoRequest(FileInfo[] image, long userId, int groupId,IRequestFactory factory) : base("",factory)
        {
            mUserId = userId;
            mGroupId = groupId;
            mImage = image;
        }

        public VKUploadWallPhotoRequest(VKUploadImage image, long userId, int groupId, IRequestFactory factory)
            : base("",factory)
        {
            mUserId = userId;
            mGroupId = groupId;
            mImage = new[] {image.mImageData};
        }


        protected override AbstractRequest getServerRequest()
        {
            return mGroupId != 0 ? _photosService.GetWallUploadServer(mGroupId) : _photosService.GetWallUploadServer();
        }


        protected override VKRequest<PhotoArray> getSaveRequest(JObject response)
        {
            VKRequest<PhotoArray> saveRequest =
                _photosService.SaveWallPhoto(new VKParameters(VKJsonHelper.toMap(response)));
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