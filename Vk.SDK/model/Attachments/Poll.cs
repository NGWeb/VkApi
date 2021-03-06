namespace Vk.SDK.Model
{
    public class Poll
    {
        /**
     * Poll ID to get information about it using polls.getById method;
     */
        public int answer_id;

        /**
     * Array of answers for this question.
     */
        public VkList<Answer> answers;
        public long created;
        public int id;

        /**
     * ID of the user or community that owns this poll.
     */
        public int owner_id;

        /**
     * Date (in Unix time) the poll was created.
     */

        /**
     * Question in the poll.
     */
        public string question;

        /**
     * The total number of users answered.
     */
        public int votes;
        public int Id { get; set; }

        /**
     * Response ID of the current user(if the current user has not yet posted in this poll, it contains 0)
     */


        /**
     * Creates empty Country instance.
     */


        public string ToAttachmentString()
        {
            return null;
        }


        public string GetType()
        {
            return AttachmentType.TYPE_POLL;
        }
    }
}