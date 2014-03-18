namespace Vk.SDK.model
{
    public class VKApiPoll : VKApiAttachment
    {

        /**
     * Poll ID to get information about it using polls.getById method;
     */
        public int id;

        /**
     * ID of the user or community that owns this poll.
     */
        public int owner_id;

        /**
     * Date (in Unix time) the poll was created.
     */
        public long created;

        /**
     * Question in the poll.
     */
        public string question;

        /**
     * The total number of users answered.
     */
        public int votes;

        /**
     * Response ID of the current user(if the current user has not yet posted in this poll, it contains 0)
     */
        public int answer_id;

        /**
     * Array of answers for this question.
     */
        public VKList<Answer> answers;


        /**
     * Creates empty Country instance.
     */
        public VKApiPoll()
        {

        }


        public override string ToAttachmentString()
        {
            return null;
        }


        public override string GetType()
        {
            return TYPE_POLL;
        }

        public override int Id
        {
            get;
            set;
        }
    }
}