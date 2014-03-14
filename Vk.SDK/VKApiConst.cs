namespace Vk.SDK
{
    public class VKApiConst
    {
        //Commons
        public static readonly string USER_ID = "user_id";
        public static readonly string USER_IDS = "user_ids";
        public static readonly string FIELDS = "fields";
        public static readonly string SORT = "sort";
        public static readonly string OFFSET = "offset";
        public static readonly string COUNT = "count";
        public static readonly string OWNER_ID = "owner_id";

        //auth
        public static readonly string VERSION = "v";
        public static readonly string HTTPS = "https";
        public static readonly string LANG = "lang";
        public static readonly string ACCESS_TOKEN = "access_token";
        public static readonly string SIG = "sig";

        //get users
        public static readonly string NAME_CASE = "name_case";

        //Get subscriptions
        public static readonly string EXTENDED = "extended";

        //Search
        public static readonly string Q = "q";
        public static readonly string CITY = "city";
        public static readonly string COUNTRY = "country";
        public static readonly string HOMETOWN = "hometown";
        public static readonly string UNIVERSITY_COUNTRY = "university_country";
        public static readonly string UNIVERSITY = "university";
        public static readonly string UNIVERSITY_YEAR = "university_year";
        public static readonly string SEX = "sex";
        public static readonly string STATUS = "status";
        public static readonly string AGE_FROM = "age_from";
        public static readonly string AGE_TO = "age_to";
        public static readonly string BIRTH_DAY = "birth_day";
        public static readonly string BIRTH_MONTH = "birth_month";
        public static readonly string BIRTH_YEAR = "birth_year";
        public static readonly string ONLINE = "online";
        public static readonly string HAS_PHOTO = "has_photo";
        public static readonly string SCHOOL_COUNTRY = "school_country";
        public static readonly string SCHOOL_CITY = "school_city";
        public static readonly string SCHOOL = "school";
        public static readonly string SCHOOL_YEAR = "school_year";
        public static readonly string RELIGION = "religion";
        public static readonly string INTERESTS = "interests";
        public static readonly string COMPANY = "company";
        public static readonly string POSITION = "position";
        public static readonly string GROUP_ID = "group_id";

        public static readonly string FRIENDS_ONLY = "friends_only";
        public static readonly string FROM_GROUP = "from_group";
        public static readonly string MESSAGE = "message";
        public static readonly string ATTACHMENTS = "attachments";
        public static readonly string SERVICES = "services";
        public static readonly string SIGNED = "signed";
        public static readonly string PUBLISH_DATE = "publish_date";
        public static readonly string LAT = "lat";
        public static readonly string LONG = "long";
        public static readonly string PLACE_ID = "place_id";
        public static readonly string POST_ID = "post_id";

        //Errors
        public static readonly string ERROR_CODE = "error_code";
        public static readonly string ERROR_MSG = "error_msg";
        public static readonly string REQUEST_PARAMS = "request_params";

        //Captcha
        public static readonly string CAPTCHA_IMG = "captcha_img";
        public static readonly string CAPTCHA_SID = "captcha_sid";
        public static readonly string CAPTCHA_KEY = "captcha_key";

        //Photos
        public static readonly string PHOTO = "photo";
        public static readonly string ALBUM_ID = "album_id";
        public static readonly string PHOTO_IDS = "photo_ids";
        public static readonly string PHOTO_SIZES = "photo_sizes";
        public static readonly string REV = "rev";
        public static readonly string FEED_TYPE = "feed_type";
        public static readonly string FEED = "feed";

        //Enums
        enum VKProgressType
        {
            VKProgressTypeUpload,
            VKProgressTypeDownload
        }

        //Events
        public static readonly string VKCaptchaAnsweredEvent = "VKCaptchaAnsweredEvent";
    }
}
