using System.Collections.Generic;

namespace Vk.SDK.Model
{
    public class Message : IVKApiModel, IIdentifiable
    {
        public Message()
        {
            Attachments = new List<Attachment>();
        }

        /**
     * 	Message ID. (Not returned for forwarded messages), positive number
     */

        /**
     * 	Date (in Unix time) when the message was sent.
     */
        public List<Attachment> Attachments { get; set; }
        public string body;
        public long date;
        public bool deleted;
        public bool emoji;
        public VkList<Message> fwd_messages;
        public int id;

        /**
     * Message status (false — not read, true — read). (Not returned for forwarded messages.)
     */

        /**
     * Message type (false — received, true — sent). (Not returned for forwarded messages.)
     */
        public bool @out;
        public bool read_state;

        /**
     * Title of message or chat.
     */
        public string title;
        public int user_id;

        /**
     * Body of the message.
     */

        /**
     * Fills a Message instance from JObject.
     */


        public int Id
        {
            get { return id; }
        }


        public int describeContents()
        {
            return 0;
        }


        public Message[] newArray(int size)
        {
            return new Message[size];
        }
    };
}