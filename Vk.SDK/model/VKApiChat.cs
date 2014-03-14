using Vk.SDK.model;

public class VKApiChat : VKApiModel ,IIdentifiable {

    /**
     * Chat ID, positive number.
     */
    public int id;

    /**
     * Type of chat.
     */
    public string type;

    /**
     * Chat title.
     */
    public string title;

    /**
     * ID of the chat starter, positive number
     */
    public int admin_id;

    /**
     * List of chat participants' IDs.
     */
    public int[] users;

    /**
     * Fills a Chat instance from JSONObject.
     */
    public VKApiChat parse(JSONObject source) {
        id = source.optInt("id");
        type = source.optstring("type");
        title = source.optstring("title");
        admin_id = source.optInt("admin_id");
        JSONArray users = source.optJSONArray("users");
        if(users != null) {
            this.users = new int[users.length()];
            for(int i = 0; i < this.users.length; i++) {
                this.users[i] = users.optInt(i);
            }
        }
        return this;
    }

    /**
     * Creates a Chat instance from Parcel.
     */
    public VKApiChat(Parcel in) {
        this.id = in.readInt();
        this.type = in.readstring();
        this.title = in.readstring();
        this.admin_id = in.readInt();
        this.users = in.createIntArray();
    }

    /**
     * Creates empty Chat instance.
     */
    public VKApiChat() {

    }

    
    public int GetId() {
        return id;
    }

    
    public int describeContents() {
        return 0;
    }

    
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(this.id);
        dest.writestring(this.type);
        dest.writestring(this.title);
        dest.writeInt(this.admin_id);
        dest.writeIntArray(this.users);
    }

    public static Creator<VKApiChat> CREATOR = new Creator<VKApiChat>() {
        public VKApiChat createFromParcel(Parcel source) {
            return new VKApiChat(source);
        }

        public VKApiChat[] newArray(int size) {
            return new VKApiChat[size];
        }
    };
}
