#region usings

using Vk.SDK.Vk;

#endregion

namespace Vk.SDK.Photo
{
    public class VKImageParameters : VKObject
    {
        /**
     * Describes image representation type
     */

        public enum VKImageType
        {
            /// Sets jpeg representation of image
            Jpg,

            /// Sets png representation of image
            Png
        }

        /**
     * PublicType of image compression. Can be <b>VKImageType.Jpg</b> or <b>VKImageType.Png</b>.
     */
        public VKImageType mImageType = VKImageType.Png;
        /**
     * Quality used for jpg compression. From 0.0 to 1.0
     */
        public float mJpegQuality;

        public static VKImageParameters pngImage()
        {
            VKImageParameters result = new VKImageParameters();
            result.mImageType = VKImageType.Png;
            return result;
        }

        public static VKImageParameters jpgImage(float quality)
        {
            VKImageParameters result = new VKImageParameters();
            result.mImageType = VKImageType.Jpg;
            result.mJpegQuality = quality;
            return result;
        }

        /**
     * Returns the file extension for specified parameters
     * @return "jpg", "png" or "file" if unknown
     */

        public string fileExtension()
        {
            switch (mImageType)
            {
                case VKImageType.Jpg:
                    return "jpg";
                case VKImageType.Png:
                    return "png";
                default:
                    return "file";
            }
        }

        /**
     * Returns the mime type for specified parameters
     * @return "mage/jpeg", "mage/png" or "application/octet-stream"
     */

        public string MimeType()
        {
            switch (mImageType)
            {
                case VKImageType.Jpg:
                    return "image/jpeg";
                case VKImageType.Png:
                    return "image/png";
                default:
                    return "application/octet-stream";
            }
        }
    }
}