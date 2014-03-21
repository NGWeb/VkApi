#region usings

using System.Collections.Generic;

#endregion

namespace Vk.SDK.Vk
{
    public class VKScope
    {
        public static readonly string NOTIFY = "notify";
        public static readonly string FRIENDS = "friends";
        public static readonly string PHOTOS = "photos";
        public static readonly string AUDIO = "audio";
        public static readonly string VIDEO = "video";
        public static readonly string DOCS = "docs";
        public static readonly string NOTES = "notes";
        public static readonly string PAGES = "pages";
        public static readonly string STATUS = "status";
        public static readonly string WALL = "wall";
        public static readonly string GROUPS = "groups";
        public static readonly string MESSAGES = "messages";
        public static readonly string NOTIFICATIONS = "notifications";
        public static readonly string STATS = "stats";
        public static readonly string ADS = "ads";
        public static readonly string OFFLINE = "offline";
        public static readonly string NOHTTPS = "nohttps";

        /**
     * Converts integer value of permissions into List of constants
     * @param permissionsValue integer permissions value
     * @return List contains string constants of permissions (scope)
     */

        public static List<string> parseVkPermissionsFromInteger(int permissionsValue)
        {
            List<string> res = new List<string>();
            if ((permissionsValue & 1) > 0) res.Add(NOTIFY);
            if ((permissionsValue & 2) > 0) res.Add(FRIENDS);
            if ((permissionsValue & 4) > 0) res.Add(PHOTOS);
            if ((permissionsValue & 8) > 0) res.Add(AUDIO);
            if ((permissionsValue & 16) > 0) res.Add(VIDEO);
            if ((permissionsValue & 128) > 0) res.Add(PAGES);
            if ((permissionsValue & 1024) > 0) res.Add(STATUS);
            if ((permissionsValue & 2048) > 0) res.Add(NOTES);
            if ((permissionsValue & 4096) > 0) res.Add(MESSAGES);
            if ((permissionsValue & 8192) > 0) res.Add(WALL);
            if ((permissionsValue & 32768) > 0) res.Add(ADS);
            if ((permissionsValue & 65536) > 0) res.Add(OFFLINE);
            if ((permissionsValue & 131072) > 0) res.Add(DOCS);
            if ((permissionsValue & 262144) > 0) res.Add(GROUPS);
            if ((permissionsValue & 524288) > 0) res.Add(NOTIFICATIONS);
            if ((permissionsValue & 1048576) > 0) res.Add(STATS);
            return res;
        }
   

    }
}