namespace Vk.SDK.model
{
    public class VKApiComment : VKApiModel, IIdentifiable
    {

        /**
     * Comment ID, positive number
     */
        public int id;

        /**
     * Comment author ID.
     */
        public int from_id;

        /**
     * Date when the comment was added as unixtime.
     */
        public long date;

        /**
     * Text of the comment
     */
        public string text;

        /**
     * ID of the user or community to whom the reply is addressed (if the comment is a reply to another comment).
     */
        public int reply_to_user;

        /**
     * ID of the comment the reply to which is represented by the current comment (if the comment is a reply to another comment).
     */
        public int reply_to_comment;

        /**
     * Number of likes on the comment.
     */
        public int likes;

        /**
     * Information whether the current user liked the comment.
     */
        public bool user_likes;

        /**
     * Whether the current user can like on the comment.
     */
        public bool can_like;

        /**
     * Information about attachments in the comments (photos, links, etc.;)
     */
        public VKAttachments attachments = new VKAttachments();

        /**
     * Fills a Comment instance from JObject.
     */


        /**
     * Creates empty Comment instance.
     */
        public VKApiComment()
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
    }
}
