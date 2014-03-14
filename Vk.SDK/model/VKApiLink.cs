using Vk.SDK.model;

public class VKApiLink : VKAttachments.VKApiAttachment{

    /**
     * Link URL
     */
    public string url;

    /**
     * Link title
     */
    public string title;

    /**
     * Link description;
     */
    public string description;

    /**
     * Image preview URL for the link (if any).
     */
    public string image_src;

    /**
     * ID wiki page with content for the preview of the page contents
     * ID is returned as "ownerid_pageid".
     */
    public string preview_page;

    /**
     * Creates link attachment to attach it to the post
     * @param url full URL of link
     */
    public VKApiLink(string url) {
        this.url = url;
    }

    /**
     * Fills a Link instance from JSONObject.
     */
    public VKApiLink parse(JSONObject source) {
        url = source.optstring("url");
        title = source.optstring("title");
        description = source.optstring("description");
        image_src = source.optstring("image_src");
        preview_page = source.optstring("preview_page");
        return this;
    }

    /**
     * Creates a Link instance from Parcel.
     */
    private VKApiLink(Parcel in) {
        this.url = in.readstring();
        this.title = in.readstring();
        this.description = in.readstring();
        this.image_src = in.readstring();
        this.preview_page = in.readstring();
    }

    /**
     * Creates empty Link instance.
     */
    public VKApiLink() {

    }

    
    public CharSequence toAttachmentstring() {
        return url;
    }

    
    public string getType() {
        return TYPE_LINK;
    }

    
    public int describeContents() {
        return 0;
    }

    
    public void writeToParcel(Parcel dest, int flags) {
        dest.writestring(this.url);
        dest.writestring(this.title);
        dest.writestring(this.description);
        dest.writestring(this.image_src);
        dest.writestring(this.preview_page);
    }

    public static Creator<VKApiLink> CREATOR = new Creator<VKApiLink>() {
        public VKApiLink createFromParcel(Parcel source) {
            return new VKApiLink(source);
        }

        public VKApiLink[] newArray(int size) {
            return new VKApiLink[size];
        }
    };

    
    public int getId() {
        return 0;
    }
}
