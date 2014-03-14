using Vk.SDK.Vk;

namespace Vk.SDK.photo
{
    public class VKImageParameters : VKObject {
        /**
     * Describes image representation type
     */
        enum VKImageType {
            /// Sets jpeg representation of image
            Jpg,
            /// Sets png representation of image
            Png
        }

        /**
     * Type of image compression. Can be <b>VKImageType.Jpg</b> or <b>VKImageType.Png</b>.
     */
        public VKImageType mImageType = VKImageType.Png;
        /**
     * Quality used for jpg compression. From 0.0 to 1.0
     */
        public float mJpegQuality;

        public static VKImageParameters pngImage() {
            VKImageParameters result = new VKImageParameters();
            result.mImageType = VKImageType.Png;
            return result;
        }

        public static VKImageParameters jpgImage(float quality) {
            VKImageParameters result = new VKImageParameters();
            result.mImageType = VKImageType.Jpg;
            result.mJpegQuality = quality;
            return result;
        }

        /**
     * Returns the file extension for specified parameters
     * @return "jpg", "png" or "file" if unknown
     */
        public string fileExtension() {
            switch (mImageType) {
                case Jpg:
                    return "jpg";
                case Png:
                    return "png";
                default:
                    return "file";
            }
        }

        /**
     * Returns the mime type for specified parameters
     * @return "mage/jpeg", "mage/png" or "application/octet-stream"
     */
        public string mimeType() {
            switch (mImageType) {
                case Jpg:
                    return "image/jpeg";
                case Png:
                    return "image/png";
                default:
                    return "application/octet-stream";
            }
        }
    }
}
