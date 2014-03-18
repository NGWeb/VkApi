using System.Text;

namespace Vk.SDK.model
{
    public class VKApiNote : VKApiAttachment, IIdentifiable
    {

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
     * Fills a Note instance from JObject.
     */
        //public VKApiNote parse(JObject source)
        //{
        //    id = source.optInt("id");
        //    user_id = source.optInt("user_id");
        //    title = source.optstring("title");
        //    text = source.optstring("text");
        //    date = source.optLong("date");
        //    comments = source.optInt("comments");
        //    read_comments = source.optInt("read_comments");
        //    return this;
        //}


        /**
     * Creates empty Note instance.
     */
        public VKApiNote()
        {

        }


        public override int Id
        {
            get { return id; }
        }


        public override string ToAttachmentString()
        {
            return new StringBuilder(TYPE_NOTE).Append(user_id).Append('_').Append(id);
        }


        public override string GetType()
        {
            return TYPE_NOTE;
        }


        public int describeContents()
        {
            return 0;
        }

    };
}
