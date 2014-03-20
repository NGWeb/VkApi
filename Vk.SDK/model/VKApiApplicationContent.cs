#region usings

using System;

#endregion

namespace Vk.SDK.Model
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
        public VKPhotoSizes photo = new VKPhotoSizes();

        /**
     * Image URL for preview with maximum width in 130px
     */
        public string photo_130;

        /**
     * Image URL for preview with maximum width in 130px
     */
        public string photo_604;
        public override int Id { get; set; }

        /**
     * Image URL for preview;
     */

        public int describeContents()
        {
            return 0;
        }

        public override string ToAttachmentString()
        {
            throw new NotImplementedException();
        }

        public override string GetType()
        {
            throw new NotImplementedException();
        }
    }
}