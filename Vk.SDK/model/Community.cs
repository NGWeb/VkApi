namespace Vk.SDK.Model
{
    public class Community : Owner
    {
        public enum AdminLevel
        {
            MODERATOR = 1,
            EDITOR = 2,
            ADMIN = 3
        }

        public enum PublicType
        {
            GROUP = 0,
            PAGE = 1,
            EVENT = 2
        }

        public enum Status
        {
            OPEN = 0,
            CLOSED = 1,
            PRIVATE = 2
        }

        private static readonly string TYPE_GROUP = "group";
        private static readonly string TYPE_PAGE = "page";
        private static readonly string TYPE_EVENT = "event";
        private static readonly string PHOTO_50 = "http://vk.com/images/community_50.gif";
        private static readonly string PHOTO_100 = "http://vk.com/images/community_100.gif";

        /**
     * Community name
     */

        /**
     * Rights of the user
     * @see {@link AdminLevel}
     */
        public int admin_level;
        public bool is_admin;
        public int is_closed;

        /**
     * Whether a user is a community member
     */
        public bool is_member;
        public string name;
        public PhotoSizes photo = new PhotoSizes();

        /**
     * Community type
     * @see {@link com.vk.sdk.api.model.VKCommunity.PublicType}
     */

        /**
     * URL of the 100px-wide community logo.
     */
        public string photo_100;

        /**
     * URL of the 200px-wide community logo.
     */
        public string photo_200;
        public string photo_50;
        public string screen_name;
        public int type;

        /**
     * {@link #photo_50}, {@link #photo_100}, {@link #photo_200} included here in Photo Sizes format.
     */


        public string ToString()
        {
            return name;
        }


        public int describeContents()
        {
            return 0;
        }


        /**
     * Access level to manage community.
     */
    }
}