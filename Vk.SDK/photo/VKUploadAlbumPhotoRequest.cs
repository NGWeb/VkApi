#region usings

using System;
using System.IO;
using Newtonsoft.Json.Linq;
using Vk.SDK.Model;
using Vk.SDK.Util;

#endregion

namespace Vk.SDK.Photo
{
    public class VKUploadAlbumPhotoRequest : VKUploadPhotoBase<VKPhotoArray>
    {
        public VKUploadAlbumPhotoRequest(FileInfo[] image, long albumId, long groupId)
            : base("")
        {
            mAlbumId = albumId;
            mGroupId = groupId;
            mImage = image;
        }

        public VKUploadAlbumPhotoRequest(VKUploadImage image, long albumId, long groupId)
            : base("")
        {
            mAlbumId = albumId;
            mGroupId = groupId;
            mImage = new[] {image.mImageData};
        }

        protected override AbstractRequest getServerRequest()
        {
            if (mAlbumId != 0 && mGroupId != 0)
                return VKApi.photos().GetUploadServer(mAlbumId, mGroupId);
            return VKApi.photos().GetUploadServer(mAlbumId);
        }


        protected override VKRequest<VKPhotoArray> getSaveRequest(JObject response)
        {
            var saveRequest = VKApi.photos().Save(new VKParameters(VKJsonHelper.toMap(response)));
            if (mAlbumId != 0)
                saveRequest.addExtraParameters(VKUtil.paramsFrom(VKApiConst.ALBUM_ID, mAlbumId));
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
            var serverRequest = getServerRequest() as VkJsonRequest;
            if (serverRequest == null)
                return null;

            var jobject = serverRequest.GetResponse() as JObject;

            getSaveRequest(jobject);
            return jobject;
        }
    }
}