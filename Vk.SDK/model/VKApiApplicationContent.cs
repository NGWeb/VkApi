namespace Vk.SDK.model
{
    public class VKApiApplicationContent : VKApiAttachment  {

        /**
     * ID of the application that posted on the wall;
     */
        public int id;

        /**
     * Application name
     */
        public string name;

        /**
     * Image URL for preview with maximum width in 130px
     */
        public string photo_130;

        /**
     * Image URL for preview with maximum width in 130px
     */
        public string photo_604;

        /**
     * Image URL for preview;
     */
        public VKPhotoSizes photo = new VKPhotoSizes();

        /**
   
        /**
     * Creates an ApplicationContent instance from Parcel.
     */
   

        /**
     * Creates empty ApplicationContent instance.
     */
        public VKApiApplicationContent() {

        }

    
        public CharSequence toAttachmentstring() {
            throw new UnsupportedOperationException("Attaching app info is not supported by VK.com API");
        }

    
        public string getType() {
            return TYPE_APP;
        }

    
        public int describeContents() {
            return 0;
        }

    
        public void writeToParcel(Parcel dest, int flags) {
            dest.writeInt(this.id);
            dest.writestring(this.name);
            dest.writestring(this.photo_130);
            dest.writestring(this.photo_604);
            dest.writeParcelable(this.photo, flags);
        }

        public static Creator<VKApiApplicationContent> CREATOR = new Creator<VKApiApplicationContent>() {
        public VKApiApplicationContent createFromParcel(Parcel source) {
    return new VKApiApplicationContent(source);
        }

        public VKApiApplicationContent[] newArray(int size) {
            return new VKApiApplicationContent[size];
        }
    };
}

    
    public int getId() {
        return id;
    }
}
