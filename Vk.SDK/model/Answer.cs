namespace Vk.SDK.model
{
    public class Answer : VKApiModel, IIdentifiable
    {

        /**
       * Text of the answer
       */
        public string text;

        /**
     * Number of users that voted for this answer
     */
        public int votes;

        /**
     * Rate of this answer in percent
     */
        public double rate;


        public int describeContents()
        {
            return 0;
        }


        public int Id { get; protected set; }
    };
}