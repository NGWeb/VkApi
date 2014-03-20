namespace Vk.SDK.Model
{
    public class VKApiChat : VKApiModel, IIdentifiable
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
     * Fills a Chat instance from JObject.
     */
        //public VKApiChat parse(JObject source)
        //{
        //    id = source.optInt("id");
        //    type = source.optstring("type");
        //    title = source.optstring("title");
        //    admin_id = source.optInt("admin_id");
        //    JSONArray users = source.optJSONArray("users");
        //    if (users != null)
        //    {
        //        this.users = new int[users.length()];
        //        for (int i = 0; i < this.users.length; i++)
        //        {
        //            this.users[i] = users.optInt(i);
        //        }
        //    }
        //    return this;
        //}


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