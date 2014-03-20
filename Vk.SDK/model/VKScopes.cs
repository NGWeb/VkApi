#region usings

using System.Collections.Generic;

#endregion

namespace Vk.SDK.Model
{
    public class VKScopes
    {
        /**
     * User allowed to send notifications to him/her.
     */
        public static readonly string NOTIFY = "notify";

        /**
     * Access to friends.
     */
        public static readonly string FRIENDS = "friends";

        /**
     * Access to photos.
     */
        public static readonly string PHOTOS = "photos";

        /**
     * Access to audios.
     */
        public static readonly string AUDIO = "audio";

        /**
     * Access to videos.
     */
        public static readonly string VIDEO = "video";

        /**
     * Access to documents.
     */
        public static readonly string DOCS = "docs";

        /**
     * Access to user notes.
     */
        public static readonly string NOTES = "notes";

        /**
     * Access to wiki pages.
     */
        public static readonly string PAGES = "pages";

        /**
     * Access to user status.
     */
        public static readonly string STATUS = "status";

        /**
     * Access to offers (obsolete methods).
     */
        public static readonly string OFFERS = "offers";

        /**
     * Access to questions (obsolete methods).
     */
        public static readonly string QUESTIONS = "questions";

        /**
     * Access to standard and advanced methods for the wall.
     */
        public static readonly string WALL = "wall";

        /**
     * Access to user groups.
     */
        public static readonly string GROUPS = "groups";

        /**
     * Access to advanced methods for messaging.
     */
        public static readonly string MESSAGES = "messages";

        /**
     * Access to notifications about answers to the user.
     */
        public static readonly string NOTIFICATIONS = "notifications";

        /**
     * Access to statistics of user groups and applications where he/she is an administrator.
     */
        public static readonly string STATS = "stats";

        /**
     * Access to advanced methods for <a href="http://vk.com/dev/ads">Ads API</a>.
     */
        public static readonly string ADS = "ads";

        /**
     * Access to API at any time from a third party server.
     */
        public static readonly string OFFLINE = "offline";

        /**
     * Possibility to make API requests without HTTPS. <br />
     * <b>Note that this functionality is under testing and can be changed.</b>
     */
        public static readonly string NOHTTPS = "nohttps";

        private VKScopes()
        {
        }

        /**
     * Converts integer value of permissions into List of constants
     * @param permissions integer permissions value
     * @return List contains string constants of permissions (scope)
     */

        public static List<string> parse(int permissions)
        {
            List<string> result = new List<string>();
            if ((permissions & 1) > 0) result.Add(NOTIFY);
            if ((permissions & 2) > 0) result.Add(FRIENDS);
            if ((permissions & 4) > 0) result.Add(PHOTOS);
            if ((permissions & 8) > 0) result.Add(AUDIO);
            if ((permissions & 16) > 0) result.Add(VIDEO);
            if ((permissions & 128) > 0) result.Add(PAGES);
            if ((permissions & 1024) > 0) result.Add(STATUS);
            if ((permissions & 2048) > 0) result.Add(NOTES);
            if ((permissions & 4096) > 0) result.Add(MESSAGES);
            if ((permissions & 8192) > 0) result.Add(WALL);
            if ((permissions & 32768) > 0) result.Add(ADS);
            if ((permissions & 65536) > 0) result.Add(OFFLINE);
            if ((permissions & 131072) > 0) result.Add(DOCS);
            if ((permissions & 262144) > 0) result.Add(GROUPS);
            if ((permissions & 524288) > 0) result.Add(NOTIFICATIONS);
            if ((permissions & 1048576) > 0) result.Add(STATS);
            return result;
        }
    }
}