namespace Vk.SDK.Model
{
    public class CommunityFull : Community
    {
        /**
     * Filed city from VK fields set
     */
        public static readonly string CITY = "city";

        /**
     * Filed country from VK fields set
     */
        public static readonly string COUNTRY = "country";

        /**
     * Filed place from VK fields set
     */
        public static readonly string PLACE = "place";

        /**
     * Filed description from VK fields set
     */
        public static readonly string DESCRIPTION = "description";

        /**
     * Filed wiki_page from VK fields set
     */
        public static readonly string WIKI_PAGE = "wiki_page";

        /**
     * Filed members_count from VK fields set
     */
        public static readonly string MEMBERS_COUNT = "members_count";

        /**
     * Filed counters from VK fields set
     */
        public static readonly string COUNTERS = "counters";

        /**
     * Filed start_date from VK fields set
     */
        public static readonly string START_DATE = "start_date";

        /**
     * Filed end_date from VK fields set
     */
        public static readonly string END_DATE = "end_date";

        /**
     * Filed can_post from VK fields set
     */
        public static readonly string CAN_POST = "can_post";

        /**
     * Filed can_see_all_posts from VK fields set
     */
        public static readonly string CAN_SEE_ALL_POSTS = "can_see_all_posts";

        /**
     * Filed status from VK fields set
     */
        public static readonly string STATUS = "status";

        /**
     * Filed contacts from VK fields set
     */
        public static readonly string CONTACTS = "contacts";

        /**
     * Filed links from VK fields set
     */
        public static readonly string LINKS = "links";

        /**
     * Filed fixed_post from VK fields set
     */
        public static readonly string FIXED_POST = "fixed_post";

        /**
     * Filed verified from VK fields set
     */
        public static readonly string VERIFIED = "verified";

        /**
     * Filed blacklisted from VK fields set
     */
        public static readonly string BLACKLISTED = "blacklisted";

        /**
     * Filed site from VK fields set
     */
        public static readonly string SITE = "site";

        /**
     * Filed activity from VK fields set
     */
        public static readonly string ACTIVITY = "activity";
        public bool blacklisted;
        public bool can_post;

        /**
     * Whether others' posts on the community's wall can be viewed
     */
        public bool can_see_all_posts;

        /**
     * City specified in information about community.
     */
        public City city;
        public VkList<Contact> contacts;
        public Counters counters;

        /**
     * Country specified in information about community.
     */
        public Country country;

        /**
     * Audio which broadcasting to status.
     */

        /**
     * Community description text.
     */
        public string description;
        public long end_date;
        public int fixed_post;
        public VkList<Link> links;

        /**
     * Name of the home wiki-page of the community.
     */

        /**
     * Number of community members.
     */
        public int members_count;
        public Place place;
        public string site;

        /**
     * Counters object with community counters.
     */

        /**
     * Returned only for meeting and contain GetResponse time of the meeting as unixtime.
     */
        public long start_date;

        /**
     * Returned only for meeting and contain end time of the meeting as unixtime.
     */

        /**
     * Group status.
     */
        public string status;
        public Audio status_audio;

        /**
     * Information from public page contact module.
     */

        /**
     * Information whether the community has a verified page in VK
     */
        public bool verified;
        public string wiki_page;

        /**
     * URL of community site
     */


        public class Counters
        {
            /**
         * Значение в том случае, если счетчик не был явно указан.
         */
            public static readonly int NO_COUNTER = -1;

            public int albums = NO_COUNTER;
            public int audios = NO_COUNTER;
            public int docs = NO_COUNTER;
            public int photos = NO_COUNTER;
            public int topics = NO_COUNTER;
            public int videos = NO_COUNTER;


            public int describeContents()
            {
                return 0;
            }

            public Counters[] newArray(int size)
            {
                return new Counters[size];
            }
        };
    }
}