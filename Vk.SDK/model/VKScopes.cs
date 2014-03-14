namespace Vk.SDK.model
{
    public class VKScopes
    {

        private VKScopes() { }

        /**
     * User allowed to send notifications to him/her.
     */
        public readonly static string NOTIFY = "notify";

        /**
     * Access to friends.
     */
        public readonly static string FRIENDS = "friends";

        /**
     * Access to photos.
     */
        public readonly static string PHOTOS = "photos";

        /**
     * Access to audios.
     */
        public readonly static string AUDIO = "audio";

        /**
     * Access to videos.
     */
        public readonly static string VIDEO = "video";

        /**
     * Access to documents.
     */
        public readonly static string DOCS = "docs";

        /**
     * Access to user notes.
     */
        public readonly static string NOTES = "notes";

        /**
     * Access to wiki pages.
     */
        public readonly static string PAGES = "pages";

        /**
     * Access to user status.
     */
        public readonly static string STATUS = "status";

        /**
     * Access to offers (obsolete methods).
     */
        public readonly static string OFFERS = "offers";

        /**
     * Access to questions (obsolete methods).
     */
        public readonly static string QUESTIONS = "questions";

        /**
     * Access to standard and advanced methods for the wall.
     */
        public readonly static string WALL = "wall";

        /**
     * Access to user groups.
     */
        public readonly static string GROUPS = "groups";

        /**
     * Access to advanced methods for messaging.
     */
        public readonly static string MESSAGES = "messages";

        /**
     * Access to notifications about answers to the user.
     */
        public readonly static string NOTIFICATIONS = "notifications";

        /**
     * Access to statistics of user groups and applications where he/she is an administrator.
     */
        public readonly static string STATS = "stats";

        /**
     * Access to advanced methods for <a href="http://vk.com/dev/ads">Ads API</a>.
     */
        public readonly static string ADS = "ads";

        /**
     * Access to API at any time from a third party server.
     */
        public readonly static string OFFLINE = "offline";

        /**
     * Possibility to make API requests without HTTPS. <br />
     * <b>Note that this functionality is under testing and can be changed.</b>
     */
        public readonly static string NOHTTPS = "nohttps";

        /**
     * Converts integer value of permissions into List of constants
     * @param permissions integer permissions value
     * @return List contains string constants of permissions (scope)
     */
        public static List<string> parse(int permissions)
        {
            List<string> result = new List<string>();
            if ((permissions & 1) > 0) result.add(NOTIFY);
            if ((permissions & 2) > 0) result.add(FRIENDS);
            if ((permissions & 4) > 0) result.add(PHOTOS);
            if ((permissions & 8) > 0) result.add(AUDIO);
            if ((permissions & 16) > 0) result.add(VIDEO);
            if ((permissions & 128) > 0) result.add(PAGES);
            if ((permissions & 1024) > 0) result.add(STATUS);
            if ((permissions & 2048) > 0) result.add(NOTES);
            if ((permissions & 4096) > 0) result.add(MESSAGES);
            if ((permissions & 8192) > 0) result.add(WALL);
            if ((permissions & 32768) > 0) result.add(ADS);
            if ((permissions & 65536) > 0) result.add(OFFLINE);
            if ((permissions & 131072) > 0) result.add(DOCS);
            if ((permissions & 262144) > 0) result.add(GROUPS);
            if ((permissions & 524288) > 0) result.add(NOTIFICATIONS);
            if ((permissions & 1048576) > 0) result.add(STATS);
            return result;
        }

    }
}
