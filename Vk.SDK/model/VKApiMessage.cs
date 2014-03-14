namespace Vk.SDK.model
{
    public class VKApiMessage : VKApiModel,IIdentifiable{

        /**
     * 	Message ID. (Not returned for forwarded messages), positive number
     */
        public int id;

        /**
     * For an incoming message, the user ID of the author. For an outgoing message, the user ID of the receiver.
     */
        public int user_id;

        /**
     * 	Date (in Unix time) when the message was sent.
     */
        public long date;

        /**
     * Message status (false — not read, true — read). (Not returned for forwarded messages.)
     */
        public bool read_state;

        /**
     * Message type (false — received, true — sent). (Not returned for forwarded messages.)
     */
        public bool @out;

        /**
     * Title of message or chat.
     */
        public string title;

        /**
     * Body of the message.
     */
        public string body;

        /**
     * List of media-attachments;
     */
        public VKAttachments attachments = new VKAttachments();

        /**
     * Array of forwarded messages (if any).
     */
        public VKList<VKApiMessage> fwd_messages;

        /**
     *	Whether the message contains smiles (false — no, true — yes).
     */
        public bool emoji;

        /**
     * Whether the message is deleted (false — no, true — yes).
     */
        public bool deleted;

        /**
     * Fills a Message instance from JSONObject.
     */
        public VKApiMessage parse(JSONObject source)  {
            id = source.optInt("id");
            user_id = source.optInt("user_id");
            date = source.optLong("date");
            read_state = ParseUtils.parsebool(source, "read_state");
            @out = ParseUtils.parsebool(source, "out");
            title = source.optstring("title");
            body = source.optstring("body");
            attachments .fill(source.optJSONArray("attachments"));
            fwd_messages = new VKList<VKApiMessage>(source.optJSONArray("fwd_messages"), VKApiMessage.class);
            emoji = ParseUtils.parsebool(source, "emoji");
            deleted = ParseUtils.parsebool(source, "deleted");
            return this;
        }

        /**
     * Creates a Message instance from Parcel.
     */
        public VKApiMessage(Parcel in) {
            this.id = in.readInt();
            this.user_id = in.readInt();
            this.date = in.readLong();
            this.read_state = in.readByte() != 0;
            this.out = in.readByte() != 0;
            this.title = in.readstring();
            this.body = in.readstring();
            this.attachments = in.readParcelable(VKAttachments.class.getClassLoader());
            this.fwd_messages = in.readParcelable(VKList.class.getClassLoader());
            this.emoji = in.readByte() != 0;
            this.deleted = in.readByte() != 0;
        }

        /**
     * Creates empty Country instance.
     */
        public VKApiMessage() {

        }

    
        public int GetId() {
            return id;
        }

    
        public int describeContents() {
            return 0;
        }

    
        public void writeToParcel(Parcel dest, int flags) {
            dest.writeInt(this.id);
            dest.writeInt(this.user_id);
            dest.writeLong(this.date);
            dest.writeByte(read_state ? (byte) 1 : (byte) 0);
            dest.writeByte(out ? (byte) 1 : (byte) 0);
            dest.writestring(this.title);
            dest.writestring(this.body);
            dest.writeParcelable(attachments, flags);
            dest.writeParcelable(this.fwd_messages, flags);
            dest.writeByte(emoji ? (byte) 1 : (byte) 0);
            dest.writeByte(deleted ? (byte) 1 : (byte) 0);
        }

        public static Creator<VKApiMessage> CREATOR = new Creator<VKApiMessage>() {
        public VKApiMessage createFromParcel(Parcel source) {
    return new VKApiMessage(source);
        }

        public VKApiMessage[] newArray(int size) {
            return new VKApiMessage[size];
        }
    };
}
}
