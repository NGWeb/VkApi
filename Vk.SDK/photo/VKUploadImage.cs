using Vk.SDK.Vk;

namespace Vk.SDK.photo
{
    public class VKUploadImage : VKObject {
        /**
     * Bitmap representation of image
     */
        public readonly Bitmap mImageData;
        /**
     * Image basic info
     */
        public readonly VKImageParameters mParameters;

        public VKUploadImage(Bitmap data, VKImageParameters params) {
            mImageData = data;
            mParameters = params;
        }

        public byte[] getTmpFile() {
            Context ctx = VKUIHelper.getTopActivity();
            File outputDir = null;
            if (ctx != null) {
                outputDir = ctx.getExternalCacheDir();
                if (outputDir == null)
                    outputDir = ctx.getCacheDir();
            }
            File tmpFile = null;
            try {
                tmpFile = File.createTempFile("tmpImg", string.format(".%s", mParameters.fileExtension()), outputDir);
                FileOutputStream fos = new FileOutputStream(tmpFile);
                if (mParameters.mImageType == VKImageParameters.VKImageType.Png)
                    mImageData.compress(Bitmap.CompressFormat.PNG, 100, fos);
                else
                    mImageData.compress(Bitmap.CompressFormat.JPEG, (int) (mParameters.mJpegQuality * 100), fos);
                fos.close();
            } catch (IOException ignored) {
                if (VKSdk.DEBUG)
                    ignored.printStackTrace();
            }
            return tmpFile;
        }
    }
}
