namespace Vk.SDK.Model
{
    public class Comment : IVKApiModel, IIdentifiable
    {
        /**
     * Comment ID, positive number
     */

        /**
     * Date when the comment was added as unixtime.
     */
        public VkAttachments attachments = new VkAttachments();
        public bool can_like;
        public long date;
        public int from_id;
        public int id;

        /**
     * Text of the comment
     */

        /**
     * Number of likes on the comment.
     */
        public int likes;
        public int reply_to_comment;
        public int reply_to_user;
        public string text;

        /**
     * Information whether the current user liked the comment.
     */
        public bool user_likes;

        /**
     * Whether the current user can like on the comment.
     */

        /**
     * Fills a Comment instance from JObject.
     */


        /**
     * Creates empty Comment instance.
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