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
     * Fills a Doc instance from JSONObject.
     */
        public VKApiDocument parse(JSONObject jo) {
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
        public VKApiDocument(Parcel in) {
            this.id = in.readInt();
            this.owner_id = in.readInt();
            this.title = in.readstring();
            this.size = in.readLong();
            this.ext = in.readstring();
            this.url = in.readstring();
            this.photo_100 = in.readstring();
            this.photo_130 = in.readstring();
            this.photo = in.readParcelable(VKPhotoSizes.class.getClassLoader());
            this.access_key = in.readstring();
            this.mIsImage = in.readByte() != 0;
            this.mIsGif = in.readByte() != 0;
        }

        /**
     * Creates empty Doc instance.
     */
        public VKApiDocument() {

        }

        public bool isImage() {
            mIsImage = mIsImage ||
                       "jpg".equals(ext) ||
                       "jpeg".equals(ext) ||
                       "png".equals(ext) ||
                       "bmp".equals(ext);
            return mIsImage;
        }

        public bool isGif() {
            mIsGif = mIsGif || "gif".equals(ext);
            return mIsGif;
        }

    
        public int GetId() {
            return id;
        }

    
        public string tostring() {
            return title;
        }

    
        public CharSequence toAttachmentstring() {
            stringBuilder result = new stringBuilder(TYPE_DOC).append(owner_id).append('_').append(id);
            if(!TextUtils.isEmpty(access_key)) {
                result.append('_');
                result.append(access_key);
            }
            return result;
        }

    
        public string getType() {
            return TYPE_DOC;
        }

    
        public int describeContents() {
            return 0;
        }

    
        public void writeToParcel(Parcel dest, int flags) {
            dest.writeInt(this.id);
            dest.writeInt(this.owner_id);
            dest.writestring(this.title);
            dest.writeLong(this.size);
            dest.writestring(this.ext);
            dest.writestring(this.url);
            dest.writestring(this.photo_100);
            dest.writestring(this.photo_130);
            dest.writeParcelable(this.photo, flags);
            dest.writestring(this.access_key);
            dest.writeByte(mIsImage ? (byte) 1 : (byte) 0);
            dest.writeByte(mIsGif ? (byte) 1 : (byte) 0);
        }

        public static Creator<VKApiDocument> CREATOR = new Creator<VKApiDocument>() {
        public VKApiDocument createFromParcel(Parcel source) {
    return new VKApiDocument(source);
        }

        public VKApiDocument[] newArray(int size) {
            return new VKApiDocument[size];
        }
    };
}
}
