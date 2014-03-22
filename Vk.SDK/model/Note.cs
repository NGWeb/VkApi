#region usings

using System.Text;

#endregion

namespace Vk.SDK.Model
{
    public class Note : Attachment, IIdentifiable
    {
        /**
     * Note ID, positive number
     */

        /**
     * Number of comments.
     */
        public int comments;
        public long date;
        public int id;

        /**
     * Number of read comments (only if owner_id is the current user).
     */
        public int read_comments;
        public string text;
        public string title;
        public int user_id;

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


        public override int Id { get; set; }


        public override string ToAttachmentString()
        {
            return new StringBuilder(AttachmentType.TYPE_NOTE).Append(user_id).Append('_').Append(id).ToString();
        }


        public override string GetType()
        {
            return AttachmentType.TYPE_NOTE;
        }


        public int describeContents()
        {
            return 0;
        }
    };
}