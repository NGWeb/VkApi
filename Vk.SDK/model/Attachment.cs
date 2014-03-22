namespace Vk.SDK.Model
{
    public abstract class Attachment : IVKApiModel, IIdentifiable
    {
        /**
             * Convert attachment to special string to attach it to the post, message or comment.
             */
        public abstract int Id { get; set; }
        public abstract string ToAttachmentString();

        /**
         * @return type of this attachment
         */
        public abstract string GetType();
    };
}