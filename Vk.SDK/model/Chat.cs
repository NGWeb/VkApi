namespace Vk.SDK.Model
{
    public class Chat : IVKApiModel, IIdentifiable
    {
        /**
     * Chat ID, positive number.
     */
        public int admin_id;
        public int id;

        /**
     * PublicType of chat.
     */

        /**
     * Chat title.
     */
        public string title;
        public string type;

        /**
     * ID of the chat starter, positive number
     */

        /**
     * List of chat participants' IDs.
     */
        public int[] users;

        /**
     * Creates empty Chat instance.
  */

        public int Id
        {
            get { return id; }
        }


        public int describeContents()
        {
            return 0;
        }
    }
}