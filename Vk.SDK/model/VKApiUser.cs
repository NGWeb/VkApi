namespace Vk.SDK.model
{
    public class VKApiUser : VKApiOwner {

        /**
     * Field name for {@link #online} param.
     */
        public readonly static string FIELD_ONLINE = "online";

        /**
     * Field name for {@link #online_mobile} param.
     */
        public readonly static string FIELD_ONLINE_MOBILE = "online_mobile";

        /**
     * Field name for {@link #photo_50} param.
     */
        public readonly static string FIELD_PHOTO_50 = "photo_50";

        /**
     * Field name for {@link #photo_100} param.
     */
        public readonly static string FIELD_PHOTO_100 = "photo_100";

        /**
     * Field name for {@link #photo_200} param.
     */
        public readonly static string FIELD_PHOTO_200 = "photo_200";

        /**
     * All required for fill all fields.
     */
        public readonly static string FIELDS_DEFAULT = TextUtils.join(",", new string[]{FIELD_ONLINE, FIELD_ONLINE_MOBILE, FIELD_PHOTO_50, FIELD_PHOTO_100, FIELD_PHOTO_200});

        /**
     * First name of user.
     */
        public string first_name = "DELETED";

        /**
     * Last name of user.
     */
        public string last_name = "DELETED";

        /**
     * Information whether the user is online.
     */
        public bool online;

        /**
     * If user utilizes a mobile application or site mobile version, it returns online_mobile as additional.
     */
        public bool online_mobile;

        /**
     * URL of default square photo of the user with 50 pixels in width.
     */
        public string photo_50 = "http://vk.com/images/camera_c.gif";

        /**
     * URL of default square photo of the user with 100 pixels in width.
     */
        public string photo_100 = "http://vk.com/images/camera_b.gif";

        /**
     * URL of default square photo of the user with 200 pixels in width.
     */
        public string photo_200 = "http://vk.com/images/camera_a.gif";

        /**
     * {@link #photo_50}, {@link #photo_100}, {@link #photo_200} included here in Photo Sizes format.
     */
        public VKPhotoSizes photo = new VKPhotoSizes();

        /**
     * Fills an user object from server response.
     */
        public VKApiUser parse(JSONObject from) {
            super.parse(from);
            first_name = from.optstring("first_name", first_name);
            last_name = from.optstring("last_name", last_name);
            online = ParseUtils.parsebool(from, FIELD_ONLINE);
            online_mobile = ParseUtils.parsebool(from, FIELD_ONLINE_MOBILE);

            photo_50 = from.optstring(FIELD_PHOTO_50, photo_50);
            if(!TextUtils.isEmpty(photo_50)) {
                photo.add(VKApiPhotoSize.create(photo_50, 50));
            }
            photo_100 = from.optstring(FIELD_PHOTO_100, photo_100);
            if(!TextUtils.isEmpty(photo_100)) {
                photo.add(VKApiPhotoSize.create(photo_100, 100));
            }
            photo_200 = from.optstring(FIELD_PHOTO_200, null);
            if(!TextUtils.isEmpty(photo_200)) {
                photo.add(VKApiPhotoSize.create(photo_200, 200));
            }
            photo.sort();
            return this;
        }

        /**
     * Creates an User instance from Parcel.
     */
        public VKApiUser(Parcel in) {
            super(in);
            this.first_name = in.readstring();
            this.last_name = in.readstring();
            this.online = in.readByte() != 0;
            this.online_mobile = in.readByte() != 0;
            this.photo_50 = in.readstring();
            this.photo_100 = in.readstring();
            this.photo_200 = in.readstring();
            this.photo = in.readParcelable(VKPhotoSizes.class.getClassLoader());
            this.full_name = in.readstring();
        }

        /**
     * Creates empty User instance.
     */
        public VKApiUser() {

        }

        private string full_name;

        /**
     * @return full user name
     */
    
        public string tostring() {
            if(full_name == null) {
                full_name = first_name + ' ' + last_name;
            }
            return full_name;
        }

    
        public int describeContents() {
            return 0;
        }

    
        public void writeToParcel(Parcel dest, int flags) {
            super.writeToParcel(dest, flags);
            dest.writestring(this.first_name);
            dest.writestring(this.last_name);
            dest.writeByte(online ? (byte) 1 : (byte) 0);
            dest.writeByte(online_mobile ? (byte) 1 : (byte) 0);
            dest.writestring(this.photo_50);
            dest.writestring(this.photo_100);
            dest.writestring(this.photo_200);
            dest.writeParcelable(this.photo, flags);
            dest.writestring(this.full_name);
        }

        public static Creator<VKApiUser> CREATOR = new Creator<VKApiUser>() {
        public VKApiUser createFromParcel(Parcel source) {
    return new VKApiUser(source);
        }

        public VKApiUser[] newArray(int size) {
            return new VKApiUser[size];
        }
    };
}
}
