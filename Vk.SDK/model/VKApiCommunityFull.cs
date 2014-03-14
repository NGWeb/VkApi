using Newtonsoft.Json;
using Vk.SDK.model;

namespace Vk.SDK.model
{
    public class VKApiCommunityFull : VKApiCommunity
    {

        /**
     * Filed city from VK fields set
     */
        public readonly static string CITY = "city";

        /**
     * Filed country from VK fields set
     */
        public readonly static string COUNTRY = "country";

        /**
     * Filed place from VK fields set
     */
        public readonly static string PLACE = "place";

        /**
     * Filed description from VK fields set
     */
        public readonly static string DESCRIPTION = "description";

        /**
     * Filed wiki_page from VK fields set
     */
        public readonly static string WIKI_PAGE = "wiki_page";

        /**
     * Filed members_count from VK fields set
     */
        public readonly static string MEMBERS_COUNT = "members_count";

        /**
     * Filed counters from VK fields set
     */
        public readonly static string COUNTERS = "counters";

        /**
     * Filed start_date from VK fields set
     */
        public readonly static string START_DATE = "start_date";

        /**
     * Filed end_date from VK fields set
     */
        public readonly static string END_DATE = "end_date";

        /**
     * Filed can_post from VK fields set
     */
        public readonly static string CAN_POST = "can_post";

        /**
     * Filed can_see_all_posts from VK fields set
     */
        public readonly static string CAN_SEE_ALL_POSTS = "can_see_all_posts";

        /**
     * Filed status from VK fields set
     */
        public readonly static string STATUS = "status";

        /**
     * Filed contacts from VK fields set
     */
        public readonly static string CONTACTS = "contacts";

        /**
     * Filed links from VK fields set
     */
        public readonly static string LINKS = "links";

        /**
     * Filed fixed_post from VK fields set
     */
        public readonly static string FIXED_POST = "fixed_post";

        /**
     * Filed verified from VK fields set
     */
        public readonly static string VERIFIED = "verified";

        /**
     * Filed blacklisted from VK fields set
     */
        public readonly static string BLACKLISTED = "blacklisted";

        /**
     * Filed site from VK fields set
     */
        public readonly static string SITE = "site";

        /**
     * Filed activity from VK fields set
     */
        public readonly static string ACTIVITY = "activity";

        /**
     * City specified in information about community.
     */
        public VKApiCity city;

        /**
     * Country specified in information about community.
     */
        public VKApiCountry country;

        /**
     * Audio which broadcasting to status.
     */
        public VKApiAudio status_audio;

        /**
     * The location which specified in information about community
     */
        public VKApiPlace place;

        /**
     * Community description text.
     */
        public string description;

        /**
     * Name of the home wiki-page of the community.
     */
        public string wiki_page;

        /**
     * Number of community members.
     */
        public int members_count;

        /**
     * Counters object with community counters.
     */
        public Counters counters;

        /**
     * Returned only for meeting and contain start time of the meeting as unixtime.
     */
        public long start_date;

        /**
     * Returned only for meeting and contain end time of the meeting as unixtime.
     */
        public long end_date;

        /**
     * Whether the current user can post on the community's wall
     */
        public bool can_post;

        /**
     * Whether others' posts on the community's wall can be viewed
     */
        public bool can_see_all_posts;

        /**
     * Group status.
     */
        public string status;

        /**
     * Information from public page contact module.
     */
        public VKList<Contact> contacts;

        /**
     * Information from public page links module.
     */
        public VKList<Link> links;

        /**
     * ID of fixed post of this community.
     */
        public int fixed_post;

        /**
     * Information whether the community has a verified page in VK
     */
        public bool verified;

        /**
     * URL of community site
     */
        public string site;

        /**
     * Information whether the current community has add current user to the blacklist.
     */
        public bool blacklisted;


        public class Counters
        {

            /**
         * Значение в том случае, если счетчик не был явно указан.
         */
            public readonly static int NO_COUNTER = -1;

            public int photos = NO_COUNTER;
            public int albums = NO_COUNTER;
            public int audios = NO_COUNTER;
            public int videos = NO_COUNTER;
            public int topics = NO_COUNTER;
            public int docs = NO_COUNTER;




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

public class Contact : VKApiModel, IIdentifiable
{
    public int user_id;
    public VKApiUser user;
    public string email;
    public string desc;



    public int describeContents()
    {
        return 0;
    }


    public int Id
    {
        get { return user_id; }
    }
}

public class Link : VKApiModel, IIdentifiable
{

    public string url;
    public string name;
    public string desc;
    public VKPhotoSizes photo = new VKPhotoSizes();

    public int Id
    {
        get { return 0; }
    }
}
