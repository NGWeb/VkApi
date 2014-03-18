using Vk.SDK.model;

public class VKApiCommunity : VKApiOwner, IIdentifiable
{

    private readonly static string TYPE_GROUP = "group";
    private readonly static string TYPE_PAGE = "page";
    private readonly static string TYPE_EVENT = "event";
    readonly static string PHOTO_50 = "http://vk.com/images/community_50.gif";
    readonly static string PHOTO_100 = "http://vk.com/images/community_100.gif";

    /**
     * Community name
     */
    public string name;

    /**
     * Screen name of the community page (e.g. apiclub or club1).
     */
    public string screen_name;

    /**
     * Whether the community is closed
     * @see {@link com.vk.sdk.api.model.VKCommunity.Status}
     */
    public int is_closed;

    /**
     * Whether a user is the community manager
     */
    public bool is_admin;

    /**
     * Rights of the user
     * @see {@link AdminLevel}
     */
    public int admin_level;

    /**
     * Whether a user is a community member
     */
    public bool is_member;

    /**
     * Community type
     * @see {@link com.vk.sdk.api.model.VKCommunity.PublicType}
     */
    public int type;

    /**
     * URL of the 50px-wide community logo.
     */
    public string photo_50;

    /**
     * URL of the 100px-wide community logo.
     */
    public string photo_100;

    /**
     * URL of the 200px-wide community logo.
     */
    public string photo_200;

    /**
     * {@link #photo_50}, {@link #photo_100}, {@link #photo_200} included here in Photo Sizes format.
     */
    public VKPhotoSizes photo = new VKPhotoSizes();


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
    public enum AdminLevel
    {
       
        MODERATOR = 1,EDITOR = 2,ADMIN = 3
    }

    /**
     * Privacy status of the group.
     */
    public enum Status
    {
        OPEN = 0, CLOSED = 1, PRIVATE = 2
    }

    /**
     * Types of communities.
     */
    public enum PublicType
    {
        GROUP = 0, PAGE = 1, EVENT = 2
    }
}
