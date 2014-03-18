namespace Vk.SDK.model
{
    public class VKApiMessage : VKApiModel, IIdentifiable
    {

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
     * Fills a Message instance from JObject.
     */
        public VKApiMessage()
        {

        }


        public int Id
        {
            get { return id; }
        }


        public int describeContents()
        {
            return 0;
        }


        public VKApiMessage[] newArray(int size)
        {
            return new VKApiMessage[size];
        }
    };
}