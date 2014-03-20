#region usings

using System.IO;
using Newtonsoft.Json.Linq;
using Vk.SDK.Http;
using Vk.SDK.Model;

#endregion

namespace Vk.SDK.Photo
{
    public abstract class VKUploadPhotoBase<T> : AbstractRequest where T : VKApiModel
    {
        /**
     * ID of album to upload
     */
        protected long mAlbumId;
        /**
     * ID of group to upload
     */
        protected long mGroupId;
        /**
     * ID of user wall to upload
     */
        /**
     * Image to upload
     */
        protected FileInfo[] mImage;
        protected long mUserId;

        protected VKUploadPhotoBase(string uri)
            : base(uri)
        {
        }

        protected abstract AbstractRequest getServerRequest();

        protected abstract VKRequest<T> getSaveRequest(JObject response);

        public void cancel()
        {
            //if (lastOperation != null)
            //    lastOperation.cancel();
            //super.cancel();
        }


        public void finish()
        {
            //super.finish();
            //lastOperation = null;
        }

        public VKAbstractOperation getOperation()
        {
            return new VKUploadImageOperation(GetPreparedRequest());
        }
    }
}