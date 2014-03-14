namespace Vk.SDK.model
{
    public class VKApiUserFull : VKApiUser
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
        public VKApiCity city;
        public Relative.Counters counters;

        /**
     * Country specified on user's page in "Contacts" section.
     */
        public VKApiCountry country;

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
        public VKList<Relative> relatives;
        public string religion;
        public VKList<VKApiSchool> schools;
        public string screen_name;
        public int sex;
        public string site;
        public string skype;
        public int smoking;
        public VKApiAudio status_audio;
        public string tv;
        public string twitter;
        public VKList<VKApiUniversity> universities;
        public bool verified;
        public bool wall_comments;
        public bool wall_default_owner;

        /**
     * Information whether the current user has add this user to the blacklist.
     */

        public class Relative : VKApiModel, IIdentifiable
        {
            public int id;
            public string name;


            public int GetId()
            {
                return id;
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

    public class Sex
    {
        public static readonly int FEMALE = 1;
        public static readonly int MALE = 2;

        private Sex()
        {
        }
    }

    public class Relation
    {
        public static readonly int SINGLE = 1;
        public static readonly int RELATIONSHIP = 2;
        public static readonly int ENGAGED = 3;
        public static readonly int MARRIED = 4;
        public static readonly int COMPLICATED = 5;
        public static readonly int SEARCHING = 6;
        public static readonly int IN_LOVE = 7;

        private Relation()
        {
        }
    }

    public class Attitude
    {
        public static readonly int VERY_NEGATIVE = 1;
        public static readonly int NEGATIVE = 2;
        public static readonly int COMPROMISABLE = 3;
        public static readonly int NEUTRAL = 4;
        public static readonly int POSITIVE = 5;

        private Attitude()
        {
        }
    }

    public class Political
    {
        public static readonly int COMMUNNIST = 1;
        public static readonly int SOCIALIST = 2;
        public static readonly int CENTRIST = 3;
        public static readonly int LIBERAL = 4;
        public static readonly int CONSERVATIVE = 5;
        public static readonly int MONARCHIST = 6;
        public static readonly int ULTRACONSERVATIVE = 7;
        public static readonly int LIBERTARIAN = 8;
        public static readonly int APATHETIC = 9;

        private Political()
        {
        }
    }

    public class LifeMain
    {
        public static readonly int FAMILY_AND_CHILDREN = 1;
        public static readonly int CAREER_AND_MONEY = 2;
        public static readonly int ENTERTAINMENT_AND_LEISURE = 3;
        public static readonly int SCIENCE_AND_RESEARCH = 4;
        public static readonly int IMPROOVING_THE_WORLD = 5;
        public static readonly int PERSONAL_DEVELOPMENT = 6;
        public static readonly int BEAUTY_AND_ART = 7;
        public static readonly int FAME_AND_INFLUENCE = 8;

        private LifeMain()
        {
        }
    }

    public class PeopleMain
    {
        public static readonly int INTELLECT_AND_CREATIVITY = 1;
        public static readonly int KINDNESS_AND_HONESTLY = 2;
        public static readonly int HEALTH_AND_BEAUTY = 3;
        public static readonly int WEALTH_AND_POWER = 4;
        public static readonly int COURAGE_AND_PERSISTENCE = 5;
        public static readonly int HUMOR_AND_LOVE_FOR_LIFE = 6;

        private PeopleMain()
        {
        }
    }

    public class RelativeType
    {
        public static readonly string PARTNER = "partner";
        public static readonly string GRANDCHILD = "grandchild";
        public static readonly string GRANDPARENT = "grandparent";
        public static readonly string CHILD = "child";
        public static readonly string SUBLING = "sibling";
        public static readonly string PARENT = "parent";

        private RelativeType()
        {
        }
    }
}