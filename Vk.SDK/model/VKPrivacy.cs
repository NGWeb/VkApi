namespace Vk.SDK.model
{
    public class VKPrivacy {

        VKPrivacy() {}

        /**
     * Access for all users
     */
        public readonly static int PRIVACY_ALL = 0;

        /**
     * Access only for friends.
     */
        public readonly static int PRIVACY_FRIENDS = 1;

        /**
     * Access only for friends and friend of friends.
     */
        public readonly static int PRIVACY_FRIENDS_OF_FRIENDS = 2;

        /**
     * Access only for logged user.
     */
        public readonly static int PRIVACY_NOBODY = 3;

        /**
     * Unknown privacy format
     */
        public readonly static int PRIVACY_UNKNOWN = 4;

        /**
     * Parses privacy in int format from privacy_view format.
     * @see <a href="http://vk.com/dev/privacy_setting">http://vk.com/dev/privacy_setting</a>
     */
        public static int parsePrivacy(JObject privacyView) {
            int privacy = 0;
            if(privacyView != null) {
                string type = privacyView.optstring("type");
                if("all".Equals(type)) {
                    privacy = PRIVACY_ALL;
                } else if("friends".Equals(type)) {
                    privacy = PRIVACY_FRIENDS;
                } else if("friends_of_friends".Equals(type)) {
                    privacy = PRIVACY_FRIENDS_OF_FRIENDS;
                } else if("nobody".Equals(type)) {
                    privacy = PRIVACY_NOBODY;
                } else {
                    privacy = PRIVACY_UNKNOWN;
                }
            }
            return privacy;
        }
    }
}