namespace Vk.SDK.model
{
    public class VKApiApplicationContent : VKApiAttachment
    {

        /**
     * ID of the application that posted on the wall;
     */
        public int id;

        /**
     * Application name
     */
        public string name;

        /**
     * Image URL for preview with maximum width in 130px
     */
        public string photo_130;

        /**
     * Image URL for preview with maximum width in 130px
     */
        public string photo_604;

        /**
     * Image URL for preview;
     */
        public VKPhotoSizes photo = new VKPhotoSizes();

        public int describeContents()
        {
            return 0;
        }

        public override string ToAttachmentString()
        {
            throw new System.NotImplementedException();
        }

        public override string GetType()
        {
            throw new System.NotImplementedException();
        }

        public override int Id
        {
            get; protected set;
        }
    }
}

    
