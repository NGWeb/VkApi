using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using Vk.SDK.model;

public class VKApiWikiPage : VKApiAttachment{

    /**
     * Wiki page ID;
     */
    public int id;

    /**
     * ID of the group the wiki page belongs to;
     */
    public int group_id;

    /**
     * ID of the page creator.
     */
    public int creator_id;

    /**
     * Wiki page name.
     */
    public string title;

    /**
     * Text of the wiki page.
     */
    public string source;

    /**
     * Whether a user can edit page text (false — cannot, true — can).
     */
    public bool current_user_can_edit;

    /**
     * Whether a user can edit page access permissions (false — cannot, true — can).
     */
    public bool current_user_can_edit_access;

    /**
     * Who can view the wiki page(0 — only community managers, 1 — only community members, 2 — all users).
     */
    public int who_can_view;

    /**
     * Who can edit the wiki page (0 — only community managers, 1 — only community members, 2 — all users).
     */
    public int who_can_edit;

    /**
     * ID of the last user who edited the page.
     */
    public int editor_id;

    /**
     * Date of the last change.
     */
    public long edited;

    /**
     * Page creation date.
     */
    public long created;

    /**
     * Title of the parent page for navigation, if any.
     */
    public string parent;

    /**
     * Title of the second parent page for navigation, if any.
     */
    public string parent2;

    /**
     * Fills a WikiPage instance from JObject.
     */
    public VKApiWikiPage parse(JObject source) {
        //id = source.optInt("id");
        //group_id = source.optInt("group_id");
        //creator_id = source.optInt("creator_id");
        //title = source.optstring("title");
        //this.source = source.optstring("source");
        //current_user_can_edit = ParseUtils.parsebool(source, "current_user_can_edit");
        //current_user_can_edit_access = ParseUtils.parsebool(source, "current_user_can_edit_access");
        //who_can_view = source.optInt("who_can_view");
        //who_can_edit = source.optInt("who_can_edit");
        //editor_id = source.optInt("editor_id");
        //edited = source.optLong("edited");
        //created = source.optLong("created");
        //parent = source.optstring("parent");
        //parent2 = source.optstring("parent2");
        return this;
    }

    /**
     * Creates a WikiPage instance from Parcel.
     */
   
    /**
     * Creates empty WikiPage instance.
     */
    public VKApiWikiPage() {

    }

    
    public string ToAttachmentString() {
        return new StringBuilder(TYPE_WIKI_PAGE).Append(group_id).Append('_').Append(id);
    }

    
    public override string GetType() {
        return TYPE_WIKI_PAGE;
    }

    public override int Id
    {
        get; set;
    }


    public int describeContents()
    {
        return 0;
    }
}
