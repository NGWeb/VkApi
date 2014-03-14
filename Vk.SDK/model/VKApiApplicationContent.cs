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

        public override string toAttachmentstring()
        {
            throw new System.NotImplementedException();
        }

        public override string getType()
        {
            throw new System.NotImplementedException();
        }

        public override int GetId()
        {
            throw new System.NotImplementedException();
        }
    }
}

    
