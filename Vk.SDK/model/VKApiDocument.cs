using System.Text;

namespace Vk.SDK.model
{
    public class VKApiDocument : VKApiAttachment ,IIdentifiable {

        /**
     * Document ID.
     */
        public int id;

        /**
     * ID of the user or group who uploaded the document.
     */
        public int owner_id;

        /**
     * Document title.
     */
        public string title;

        /**
     * Document size (in bytes).
     */
        public long size;

        /**
     * Document extension.
     */
        public string ext;

        /**
     * Document URL for downloading.
     */
        public string url;

        /**
     * URL of the 100x75px image (if the file is graphical).
     */
        public string photo_100;

        /**
     * URL of the 130x100px image (if the file is graphical).
     */
        public string photo_130;

        /**
     * Array of all photos.
     */
        public VKPhotoSizes photo = new VKPhotoSizes();

        /**
     * An access key using for get information about hidden objects.
     */
        public string access_key;

        private bool mIsGif;
        private bool mIsImage;

        /**
     * Fills a Doc instance from JObject.
     */
        public VKApiDocument parse(JObject jo) {
            id = jo.optInt("id");
            owner_id = jo.optInt("owner_id");
            title = jo.optstring("title");
            size = jo.optLong("size");
            ext = jo.optstring("ext");
            url = jo.optstring("url");
            access_key = jo.optstring("access_key");

            photo_100 = jo.optstring("photo_100");
            if(!TextUtils.isEmpty(photo_100)) {
                photo.add(VKApiPhotoSize.create(photo_100, 100, 75));
            }
            photo_130 = jo.optstring("photo_130");
            if(!TextUtils.isEmpty(photo_130)) {
                photo.add(VKApiPhotoSize.create(photo_130, 130, 100));
            }
            photo.sort();
            return this;
        }

        /**
     * Creates a Doc instance from Parcel.
     */
      
        /**
     * Creates empty Doc instance.
     */
        public VKApiDocument() {

        }

        public bool isImage() {
            mIsImage = mIsImage ||
                       "jpg".Equals(ext) ||
                       "jpeg".Equals(ext) ||
                       "png".Equals(ext) ||
                       "bmp".Equals(ext);
            return mIsImage;
        }

        public bool isGif() {
            mIsGif = mIsGif || "gif".Equals(ext);
            return mIsGif;
        }


        public override int Id
        {
            get { return id; }
        }


        public string tostring() {
            return title;
        }

    
        public string toAttachmentstring() {
            StringBuilder result = new StringBuilder(TYPE_DOC).Append(owner_id).Append('_').Append(id);
            if(!TextUtils.isEmpty(access_key)) {
                result.Append('_');
                result.Append(access_key);
            }
            return result.ToString();
        }

    
        public string getType() {
            return TYPE_DOC;
        }

    
        public int describeContents() {
            return 0;
        }

    public VKApiDocument[] newArray(int size) {
            return new VKApiDocument[size];
        }
    };
}
}
