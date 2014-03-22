namespace Vk.SDK.Model
{
    public class Answer : IVKApiModel, IIdentifiable
    {
        /**
       * Text of the answer
       */
        public double rate;
        public string text;

        /**
     * Number of users that voted for this answer
     */
        public int votes;

        /**
     * Rate of this answer in percent
     */


        public int Id { get; protected set; }

        public int describeContents()
        {
            return 0;
        }
    };
}