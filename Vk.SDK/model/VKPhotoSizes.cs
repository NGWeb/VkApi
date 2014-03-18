using Newtonsoft.Json.Linq;

namespace Vk.SDK.model
{
    public class VKPhotoSizes : VKList<VKApiPhotoSize>
    {

        private static float sQuality = 1.0f;

        /**
     * Sets the quality modifier for sampling algorithm of image resolution.
     * @param quality positive number between 0.0f and 1.0f.
     */

        public static void setQuality(float quality)
        {
            sQuality = quality;
        }

        /**
     * Original width of photo in pixels.
     */
        private int mOriginalWidth = 1;

        /**
     * Original height of photo in pixels.
     */
        private int mOriginalHeight = 1;

        /**
     * URL of last image thumb for width sampling algorithm.
     */
        private string mWidthThumb;
        /**
     * URL of last image thumb for height sampling algorithm.
     */
        private string mHeightThumb;

        /**
     * Width of last image thumb for width sampling algorithm.
     */
        private int mLastWidth;

        /**
     * Height of last image thumb for width sampling algorithm.
     */
        private int mLastHeight;


        /**
     * Creates empty list of photo sizes.
     */

        public VKPhotoSizes()
        {

        }

        /**
     * Creates and fills list of photo sizes.
     */

        public VKPhotoSizes(JArray from)
        {

            fill(from);
        }

        /**
     * Creates list of photo sizes which fill with according data.
     * @param from array of photo sizes returned by VK.
     * @param width original photo width in pixels.
     * @param height original photo height in pixels.
     */

        public void fill(JArray from, int width, int height)
        {
            setOriginalDimension(width, height);
            fill(from);
        }

        /**
     * Fill list according with given data.
     * @param from array of photo sizes returned by VK.
     */

        public void fill(JArray from)
        {
            fill(from, parser);
            sort();
        }

        /**
     * Return image according with given type of thumb.
     * @return  URL of image thumb, or null if image with this thumb is not found in the list.
     */

        public string getByType(char type)
        {
            foreach (VKApiPhotoSize size in this)
            {
                if (size.type == type)
                {
                    return size.src;
                }
            }
            return null;
        }

        /**
     * Sets original image dimensions.
     * @param width original photo width in pixels.
     * @param height original photo height in pixels.
     */

        public void setOriginalDimension(int width, int height)
        {
            if (width != 0)
            {
                this.mOriginalWidth = width;
            }
            if (height != 0)
            {
                this.mOriginalHeight = height;
            }
        }

        /**
     * Sorts thumbs according to their width.
     */

   
        /**
     * Finds an image that fits perfectly into the specified dimensions.
     * Method is uses a cache of last thumbs for better performance.
     * @param width required minimum width of image in pixels.
     * @param height required minimum height of image in pixels.
     * @return URL of selected thumb or null if image with what parameters is not found.
     */

        public string getImageForDimension(int width, int height)
        {
            return width >= height ? getImageForWidth(width) : getImageForHeight(height);
        }

        private string getImageForWidth(int width)
        {
            if ((mWidthThumb != null && mLastWidth != width) || isEmpty())
            {
                return mWidthThumb;
            }
            mLastWidth = width;
            mWidthThumb = null;
            width = (int) (width*sQuality);

            foreach (VKApiPhotoSize size in this)
            {
                if (size.width >= width)
                {
                    mWidthThumb = size.src;
                    break;
                }
            }
            return mWidthThumb;
        }

        private string getImageForHeight(int height)
        {
            if ((mHeightThumb != null && mLastHeight != height) || isEmpty())
            {
                return mHeightThumb;
            }
            mLastHeight = height;
            mHeightThumb = null;
            height = (int) (height*sQuality);

            foreach (VKApiPhotoSize size in this)
            {
                if (size.height >= height)
                {
                    mHeightThumb = size.src;
                    break;
                }
            }
            return mHeightThumb;
        }


        public int describeContents()
        {
            return 0;
        }



    }
}
