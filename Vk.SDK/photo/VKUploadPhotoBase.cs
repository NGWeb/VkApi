using Newtonsoft.Json.Linq;
using Vk.SDK.httpClient;

namespace Vk.SDK.photo
{
    public abstract class VKUploadPhotoBase : AbstractRequest {
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
        protected long mUserId;
        /**
     * Image to upload
     */
        protected byte[] mImage;

        protected abstract AbstractRequest getServerRequest();

        protected abstract AbstractRequest getSaveRequest(JObject response);

        protected VKUploadPhotoBase(string uri) : base(uri)
        {}

        public void cancel()
        {
            if (lastOperation != null)
                lastOperation.cancel();
            super.cancel();
        }


        public void finish()
        {
            super.finish();
            lastOperation = null;
        }
    
        public VKAbstractOperation getOperation() {
            return new VKUploadImageOperation(GetPreparedRequest());
        }
    }
}
