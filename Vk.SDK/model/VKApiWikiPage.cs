using Vk.SDK.model;

public class VKApiWikiPage : VKAttachments.VKApiAttachment{

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
        id = source.optInt("id");
        group_id = source.optInt("group_id");
        creator_id = source.optInt("creator_id");
        title = source.optstring("title");
        this.source = source.optstring("source");
        current_user_can_edit = ParseUtils.parsebool(source, "current_user_can_edit");
        current_user_can_edit_access = ParseUtils.parsebool(source, "current_user_can_edit_access");
        who_can_view = source.optInt("who_can_view");
        who_can_edit = source.optInt("who_can_edit");
        editor_id = source.optInt("editor_id");
        edited = source.optLong("edited");
        created = source.optLong("created");
        parent = source.optstring("parent");
        parent2 = source.optstring("parent2");
        return this;
    }

    /**
     * Creates a WikiPage instance from Parcel.
     */
    public VKApiWikiPage(Parcel in) {
        this.id = in.readInt();
        this.group_id = in.readInt();
        this.creator_id = in.readInt();
        this.title = in.readstring();
        this.source = in.readstring();
        this.current_user_can_edit = in.readByte() != 0;
        this.current_user_can_edit_access = in.readByte() != 0;
        this.who_can_view = in.readInt();
        this.who_can_edit = in.readInt();
        this.editor_id = in.readInt();
        this.edited = in.readLong();
        this.created = in.readLong();
        this.parent = in.readstring();
        this.parent2 = in.readstring();
    }

    /**
     * Creates empty WikiPage instance.
     */
    public VKApiWikiPage() {

    }

    
    public CharSequence toAttachmentstring() {
        return new stringBuilder(TYPE_WIKI_PAGE).append(group_id).append('_').append(id);
    }

    
    public string getType() {
        return TYPE_WIKI_PAGE;
    }

    
    public int describeContents() {
        return 0;
    }

    
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(this.id);
        dest.writeInt(this.group_id);
        dest.writeInt(this.creator_id);
        dest.writestring(this.title);
        dest.writestring(this.source);
        dest.writeByte(current_user_can_edit ? (byte) 1 : (byte) 0);
        dest.writeByte(current_user_can_edit_access ? (byte) 1 : (byte) 0);
        dest.writeInt(this.who_can_view);
        dest.writeInt(this.who_can_edit);
        dest.writeInt(this.editor_id);
        dest.writeLong(this.edited);
        dest.writeLong(this.created);
        dest.writestring(this.parent);
        dest.writestring(this.parent2);
    }

    public static Creator<VKApiWikiPage> CREATOR = new Creator<VKApiWikiPage>() {
        public VKApiWikiPage createFromParcel(Parcel source) {
            return new VKApiWikiPage(source);
        }

        public VKApiWikiPage[] newArray(int size) {
            return new VKApiWikiPage[size];
        }
    };

    
    public int getId() {
        return id;
    }
}
