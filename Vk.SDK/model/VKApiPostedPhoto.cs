namespace Vk.SDK.model
{
    public class VKApiPostedPhoto : VKApiPhoto {

        /**
     * Fills a PostedPhoto instance from JObject.
     */
        public VKApiPostedPhoto parse(JObject from) {
            super.parse(from);
            return this;
        }

        /**
     * Creates a PostedPhoto instance from Parcel.
     */
        public VKApiPostedPhoto(Parcel in) {
            super(in);
        }

        /**
     * Creates empty PostedPhoto instance.
     */
        public VKApiPostedPhoto() {

        }

    
        public string getType() {
            return TYPE_POSTED_PHOTO;
        }
    }
}
