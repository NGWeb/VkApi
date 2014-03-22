#region usings

using System.Text;

#endregion

namespace Vk.SDK.Model
{
    public class Document : Attachment, IIdentifiable
    {
        /**
     * Document ID.
     */
        public string access_key;
        public string ext;
        public int id;
        private bool mIsGif;
        private bool mIsImage;

        /**
     * ID of the user or group who uploaded the document.
     */
        public int owner_id;
        public PhotoSizes photo = new PhotoSizes();

        /**
     * Document title.
     */

        /**
     * URL of the 100x75px image (if the file is graphical).
     */
        public string photo_100;

        /**
     * URL of the 130x100px image (if the file is graphical).
     */
        public string photo_130;
        public long size;
        public string title;
        public string url;
        public override int Id { get; set; }

        /**
     * Array of all photos.
     */

        /**
     * Fills a Doc instance from JObject.
     */
        //public VKApiDocument parse(JObject jo) {
        //    id = jo.optInt("id");
        //    owner_id = jo.optInt("owner_id");
        //    title = jo.optstring("title");
        //    size = jo.optLong("size");
        //    ext = jo.optstring("ext");
        //    url = jo.optstring("url");
        //    access_key = jo.optstring("access_key");

        //    photo_100 = jo.optstring("photo_100");
        //    if(!TextUtils.isEmpty(photo_100)) {
        //        photo.add(VKApiPhotoSize.create(photo_100, 100, 75));
        //    }
        //    photo_130 = jo.optstring("photo_130");
        //    if(!TextUtils.isEmpty(photo_130)) {
        //        photo.add(VKApiPhotoSize.create(photo_130, 130, 100));
        //    }
        //    photo.sort();
        //    return this;
        //}

        /**
     * Creates a Doc instance from Parcel.
     */

        /**
     * Creates empty Doc instance.
     */

        public bool isImage()
        {
            mIsImage = mIsImage ||
                       "jpg".Equals(ext) ||
                       "jpeg".Equals(ext) ||
                       "png".Equals(ext) ||
                       "bmp".Equals(ext);
            return mIsImage;
        }

        public bool isGif()
        {
            mIsGif = mIsGif || "gif".Equals(ext);
            return mIsGif;
        }


        public string tostring()
        {
            return title;
        }


        public override string ToAttachmentString()
        {
            StringBuilder result = new StringBuilder(AttachmentType.TYPE_DOC).Append(owner_id).Append('_').Append(id);
            if (!string.IsNullOrEmpty(access_key))
            {
                result.Append('_');
                result.Append(access_key);
            }
            return result.ToString();
        }


        public override string GetType()
        {
            return AttachmentType.TYPE_DOC;
        }


        public int describeContents()
        {
            return 0;
        }

        public Document[] newArray(int size)
        {
            return new Document[size];
        }
    };
}