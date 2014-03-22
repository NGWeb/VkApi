namespace Vk.SDK.Model
{
    public class IvkApiUserFull : IvkApiUser
    {
        /**
     * Filed last_seen from VK fields set
     */
        public static readonly string LAST_SEEN = "last_seen";

        /**
     * Filed bdate from VK fields set
     */
        public static readonly string BDATE = "bdate";

        /**
     * Filed city from VK fields set
     */
        public static readonly string CITY = "city";

        /**
     * Filed country from VK fields set
     */
        public static readonly string COUNTRY = "country";

        /**
     * Filed universities from VK fields set
     */
        public static readonly string UNIVERSITIES = "universities";

        /**
     * Filed schools from VK fields set
     */
        public static readonly string SCHOOLS = "schools";

        /**
     * Filed activity from VK fields set
     */
        public static readonly string ACTIVITY = "activity";

        /**
     * Filed personal from VK fields set
     */
        public static readonly string PERSONAL = "personal";

        /**
     * Filed sex from VK fields set
     */
        public static readonly string SEX = "sex";

        /**
     * Filed site from VK fields set
     */
        public static readonly string SITE = "site";

        /**
     * Filed contacts from VK fields set
     */
        public static readonly string CONTACTS = "contacts";

        /**
     * Filed can_post from VK fields set
     */
        public static readonly string CAN_POST = "can_post";

        /**
     * Filed can_see_all_posts from VK fields set
     */
        public static readonly string CAN_SEE_ALL_POSTS = "can_see_all_posts";

        /**
     * Filed can_write_private_message from VK fields set
     */
        public static readonly string CAN_WRITE_PRIVATE_MESSAGE = "can_write_private_message";

        /**
     * Filed relation from VK fields set
     */
        public static readonly string RELATION = "relation";

        /**
     * Filed counters from VK fields set
     */
        public static readonly string COUNTERS = "counters";

        /**
     * Filed activities from VK fields set
     */
        public static readonly string ACTIVITIES = "activities";

        /**
     * Filed interests from VK fields set
     */
        public static readonly string INTERESTS = "interests";

        /**
     * Filed movies from VK fields set
     */
        public static readonly string MOVIES = "movies";

        /**
     * Filed tv from VK fields set
     */
        public static readonly string TV = "tv";

        /**
     * Filed books from VK fields set
     */
        public static readonly string BOOKS = "books";

        /**
     * Filed games from VK fields set
     */
        public static readonly string GAMES = "games";

        /**
     * Filed about from VK fields set
     */
        public static readonly string ABOUT = "about";

        /**
     * Filed quotes from VK fields set
     */
        public static readonly string QUOTES = "quotes";

        /**
     * Filed connections from VK fields set
     */
        public static readonly string CONNECTIONS = "connections";

        /**
     * Filed relatives from VK fields set
     */
        public static readonly string RELATIVES = "relatives";

        /**
     * Filed wall_default from VK fields set
     */
        public static readonly string WALL_DEFAULT = "wall_default";

        /**
     * Filed verified from VK fields set
     */
        public static readonly string VERIFIED = "verified";

        /**
     * Filed screen_name from VK fields set
     */
        public static readonly string SCREEN_NAME = "screen_name";

        /**
     * Filed blacklisted_by_me from VK fields set
     */
        public static readonly string BLACKLISTED_BY_ME = "blacklisted_by_me";
        public string about;
        public string activities;

        /**
     * Text of user status.
     */
        public string activity;
        public int alcohol;

        /**
     * Audio which broadcasting to status.
     */

        /**
     * User's date of birth.  Returned as DD.MM.YYYY or DD.MM (if birth year is hidden).
     */
        public string bdate;
        public bool blacklisted_by_me;
        public string books;
        public bool can_post;

        /**
     * Information whether others' posts on user's wall can be viewed
     */
        public bool can_see_all_posts;

        /**
     * Information whether private messages can be sent to this user.
     */
        public bool can_write_private_message;

        /**
     * City specified on user's page in "Contacts" section.
     */
        public City city;
        public Relative.Counters counters;

        /**
     * Country specified on user's page in "Contacts" section.
     */
        public Country country;

        /**
     * Last visit date(in Unix time).
     */

        /**
     * Name of user's account in Facebook
     */
        public string facebook;

        /**
     * ID of user's facebook
     */
        public string facebook_name;
        public string games;

        /**
     * Name of user's account in LiveJournal
     */

        /**
     * User's home phone number
     */
        public string home_phone;
        public string inspired_by;
        public string instagram;

        /**
     * Page screen name.
     */

        /**
     * User's interests
     */
        public string interests;

        /**
     * User's favorite movies
     */

        /**
     * Information whether the user is banned in VK.
     */
        public bool is_banned;

        /**
     * Information whether the user is deleted in VK.
     */
        public bool is_deleted;
        public string[] langs;
        public long last_seen;
        public int life_main;
        public string livejournal;
        public string mobile_phone;
        public string movies;
        public int people_main;
        public int political;
        public string quotes;

        /**
     * Information whether the user's post of wall shows by default.
     */

        /**
     * Relationship status.
     * @see {@link com.vk.sdk.api.model.VKUserFull.Relation}
     */
        public int relation;

        /**
     * List of user's relatives
     */
        public VkList<Relative> relatives;
        public string religion;
        public VkList<IvkApiSchool> schools;
        public string screen_name;
        public int sex;
        public string site;
        public string skype;
        public int smoking;
        public Audio status_audio;
        public string tv;
        public string twitter;
        public VkList<IvkApiUniversity> universities;
        public bool verified;
        public bool wall_comments;
        public bool wall_default_owner;

        /**
     * Information whether the current user has add this user to the blacklist.
     */

        public class Relative : IVKApiModel, IIdentifiable
        {
            public int id;
            public string name;


            public int Id
            {
                get { return id; }
            }


            public int describeContents()
            {
                return 0;
            }


            public class Counters
            {
                /**
         * Count was not in server response.
         */
                public static readonly int NO_COUNTER = -1;

                public int albums = NO_COUNTER;
                public int audios = NO_COUNTER;
                public int followers = NO_COUNTER;
                public int friends = NO_COUNTER;
                public int groups = NO_COUNTER;
                public int mutual_friends = NO_COUNTER;
                public int notes = NO_COUNTER;
                public int online_friends = NO_COUNTER;
                public int pages = NO_COUNTER;
                public int photos = NO_COUNTER;
                public int subscriptions = NO_COUNTER;
                public int user_videos = NO_COUNTER;
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
}