using Vk.SDK.model;

public class VKApiNote : VKAttachments.VKApiAttachment , IIdentifiable {

    /**
     * Note ID, positive number
     */
    public int id;

    /**
     * Note owner ID.
     */
    public int user_id;

    /**
     * Note title.
     */
    public string title;

    /**
     * Note text.
     */
    public string text;

    /**
     * Date (in Unix time) when the note was created.
     */
    public long date;

    /**
     * Number of comments.
     */
    public int comments;

    /**
     * Number of read comments (only if owner_id is the current user).
     */
    public int read_comments;

    /**
     * Fills a Note instance from JSONObject.
     */
    public VKApiNote parse(JSONObject source) {
        id = source.optInt("id");
        user_id = source.optInt("user_id");
        title = source.optstring("title");
        text = source.optstring("text");
        date = source.optLong("date");
        comments = source.optInt("comments");
        read_comments = source.optInt("read_comments");
        return this;
    }

    /**
     * Creates a Note instance from Parcel.
     */
    public VKApiNote(Parcel in) {
        this.id = in.readInt();
        this.user_id = in.readInt();
        this.title = in.readstring();
        this.text = in.readstring();
        this.date = in.readLong();
        this.comments = in.readInt();
        this.read_comments = in.readInt();
    }

    /**
     * Creates empty Note instance.
     */
    public VKApiNote() {

    }

    
    public int GetId() {
        return id;
    }

    
    public CharSequence toAttachmentstring() {
        return new stringBuilder(TYPE_NOTE).append(user_id).append('_').append(id);
    }

    
    public string getType() {
        return TYPE_NOTE;
    }

    
    public int describeContents() {
        return 0;
    }

    
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(this.id);
        dest.writeInt(this.user_id);
        dest.writestring(this.title);
        dest.writestring(this.text);
        dest.writeLong(this.date);
        dest.writeInt(this.comments);
        dest.writeInt(this.read_comments);
    }

    public static Creator<VKApiNote> CREATOR = new Creator<VKApiNote>() {
        public VKApiNote createFromParcel(Parcel source) {
            return new VKApiNote(source);
        }

        public VKApiNote[] newArray(int size) {
            return new VKApiNote[size];
        }
    };

}
