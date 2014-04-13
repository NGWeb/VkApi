#region usings

using Newtonsoft.Json.Linq;

#endregion

namespace Vk.SDK.Model
{
    public class User : Owner
    {
        /**
     * Field name for {@link #online} param.
     */
        public static readonly string FIELD_ONLINE = "online";

        /**
     * Field name for {@link #online_mobile} param.
     */
        public static readonly string FIELD_ONLINE_MOBILE = "online_mobile";

        /**
     * Field name for {@link #photo_50} param.
     */
        public static readonly string FIELD_PHOTO_50 = "photo_50";

        /**
     * Field name for {@link #photo_100} param.
     */
        public static readonly string FIELD_PHOTO_100 = "photo_100";

        /**
     * Field name for {@link #photo_200} param.
     */
        public static readonly string FIELD_PHOTO_200 = "photo_200";

        /**
     * All required for fill all fields.
     */

        public static readonly string FIELDS_DEFAULT = string.Join(",",
            new[] {FIELD_ONLINE, FIELD_ONLINE_MOBILE, FIELD_PHOTO_50, FIELD_PHOTO_100, FIELD_PHOTO_200});

        /**
     * First name of user.
     */
        public string first_name = "DELETED";
        private string full_name;

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
        public PhotoSizes photo = new PhotoSizes();

        /**
     * URL of default square photo of the user with 50 pixels in width.
     */

        /**
     * URL of default square photo of the user with 100 pixels in width.
     */
        public string photo_100 = "http://vk.com/images/camera_b.gif";

        /**
     * URL of default square photo of the user with 200 pixels in width.
     */
        public string photo_200 = "http://vk.com/images/camera_a.gif";
        public string photo_50 = "http://vk.com/images/camera_c.gif";

        /**
     * {@link #photo_50}, {@link #photo_100}, {@link #photo_200} included here in Photo Sizes format.
     */

        /**
     * Fills an user object from server response.
     */

        public User parse(JObject from)
        {
            //super.parse(from);
            //first_name = from.optstring("first_name", first_name);
            //last_name = from.optstring("last_name", last_name);
            //online = ParseUtils.parsebool(from, FIELD_ONLINE);
            //online_mobile = ParseUtils.parsebool(from, FIELD_ONLINE_MOBILE);

            //photo_50 = from.optstring(FIELD_PHOTO_50, photo_50);
            //if (!TextUtils.isEmpty(photo_50))
            //{
            //    photo.add(VKApiPhotoSize.create(photo_50, 50));
            //}
            //photo_100 = from.optstring(FIELD_PHOTO_100, photo_100);
            //if (!TextUtils.isEmpty(photo_100))
            //{
            //    photo.add(VKApiPhotoSize.create(photo_100, 100));
            //}
            //photo_200 = from.optstring(FIELD_PHOTO_200, null);
            //if (!TextUtils.isEmpty(photo_200))
            //{
            //    photo.add(VKApiPhotoSize.create(photo_200, 200));
            //}
            //photo.sort();
            return this;
        }

        /**
            /**
     * Creates empty User instance.
     */

        /**
     * @return full user name
     */

        public string tostring()
        {
            if (full_name == null)
            {
                full_name = first_name + ' ' + last_name;
            }
            return full_name;
        }


        public int describeContents()
        {
            return 0;
        }
    }
}