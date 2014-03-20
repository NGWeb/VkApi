#region usings

using System;
using Newtonsoft.Json.Linq;

#endregion

namespace Vk.SDK.Model
{
    public class VKApiPhotoSize : VKApiModel, IIdentifiable
    {
        /**
     * Proportional copy with 75px max width
     */
        public const char S = 's';

        /**
     *  Proportional copy with 130px max width
     */
        public const char M = 'm';

        /**
     * Proportional copy with 604px max width
     */
        public const char X = 'x';

        /**
     * Proportional copy with 807px max width
     */
        public const char Y = 'y';

        /**
     * If original image's "width/height" ratio is less or equal to 3:2, then proportional
     * copy with 130px max width. If original image's "width/height" ratio is more than 3:2,
     * then copy of cropped by left side image with 130px max width and 3:2 sides ratio.
     */
        public const char O = 'o';

        /**
     * If original image's "width/height" ratio is less or equal to 3:2, then proportional
     * copy with 200px max width. If original image's "width/height" ratio is more than 3:2,
     * then copy of cropped by left side image with 200px max width and 3:2 sides ratio.
     */
        public const char P = 'p';

        /**
     * If original image's "width/height" ratio is less or equal to 3:2, then proportional
     * copy with 320px max width. If original image's "width/height" ratio is more than 3:2,
     * then copy of cropped by left side image with 320px max width and 3:2 sides ratio.
     */
        public const char Q = 'q';

        /**
     * Proportional copy with 1280x1024px max size
     */
        public const char Z = 'z';

        /**
     * Proportional copy with 2560x2048px max size
     */
        public const char W = 'w';

        /**
     * Url of image
     */

        /**
     * Height of image in pixels
     */
        public int height;
        public string src;

        /**
     * Designation of size and proportions copy, @see {{@link #S}, {@link #M}, {@link #X}, {@link #O}, {@link #P}, {@link #Q}, {@link #Y}, {@link #Z}, {@link #W}}
     */
        public char type;
        public int width;

        private VKApiPhotoSize()
        {
        }

        public int Id
        {
            get { return 0; }
        }


        public int compareTo(VKApiPhotoSize another)
        {
            // Так как основной превалирующий элемент в фотографиях именно ширина и все фотографии пропорциональны,
            // то сравниваем именно по ней
            return width < another.width ? -1 : (width == another.width ? 0 : 1);
        }


        public int describeContents()
        {
            return 0;
        }


        /**
     * Creates dimension from {@code source}. Used in parsing.
     * If size is not specified copies calculates them based on internal algorithms.
     * @param source object in format, returned VK API, which is generated from the dimension
     * @param originalWidth original image width in pixels
     * @param originalHeight original image height in pixels
     */

        public VKApiPhotoSize parse(JObject source, int originalWidth, int originalHeight)
        {
            VKApiPhotoSize result = new VKApiPhotoSize();
            //result.src = source.optstring("src");
            //result.width = source.optInt("width");
            //result.height = source.optInt("height");
            //string type = source.optstring("type");
            //if(!TextUtils.isEmpty(type)) {
            //    result.type = type.charAt(0);
            //}
            //// Казалось бы, теперь можно с чистой советью закончить метод.
            //// Но нет, оказывается, width и height не просчитывается на некоторых серверах ВК.
            //// Приходится гадать на кофейной гуще.
            //if(result.width == 0 || result.height == 0) {
            //    fillDimensions(result, originalWidth, originalHeight);
            //}
            return result;
        }

        /*
     * Устанавливает размерность исходя из размеров оригинала и типа изображения.
     */

        private static void fillDimensions(VKApiPhotoSize result, int originalWidth, int originalHeight)
        {
            float ratio = (float) originalWidth/originalHeight;
            switch (result.type)
            {
                case S:
                {
                    fillDimensionSMXY(result, ratio, Math.Min(originalWidth, 75));
                }
                    break;
                case M:
                {
                    fillDimensionSMXY(result, ratio, Math.Min(originalWidth, 130));
                }
                    break;
                case X:
                {
                    fillDimensionSMXY(result, ratio, Math.Min(originalWidth, 604));
                }
                    break;
                case Y:
                {
                    fillDimensionSMXY(result, ratio, Math.Min(originalWidth, 807));
                }
                    break;
                case O:
                {
                    fillDimensionOPQ(result, ratio, Math.Min(originalWidth, 130));
                }
                    break;
                case P:
                {
                    fillDimensionOPQ(result, ratio, Math.Min(originalWidth, 200));
                }
                    break;
                case Q:
                {
                    fillDimensionOPQ(result, ratio, Math.Min(originalWidth, 320));
                }
                    break;
                case Z:
                {
                    fillDimensionZW(result, ratio, Math.Min(originalWidth, 1280), Math.Min(originalHeight, 1024));
                }
                    break;
                case W:
                {
                    fillDimensionZW(result, ratio, Math.Min(originalWidth, 2560), Math.Min(originalHeight, 2048));
                }
                    break;
            }
        }

        /*
     * Про S, M, X, Y известно, про копия обязательно пропорциональна, а ширина не должна превышать заданную.
     * Это значит, что для всех случаев(кроме тех, когда ширина картинки меньше указанной) соотношения
     * сторон картинка впишется пропорционально по ширине.
     */

        private static void fillDimensionSMXY(VKApiPhotoSize result, float ratio, int width)
        {
            result.width = width;
            result.height = (int) Math.Ceiling(result.width/ratio);
        }

        /*
     * Пропорциональная ширина. В принципе, все, что было сказано к предыдущему, верно и здесь,
     * за исключением того, что высота здесь не может превышать ширину * 1,5f
     */

        private static void fillDimensionOPQ(VKApiPhotoSize result, float ratio, int width)
        {
            fillDimensionSMXY(result, Math.Min(1.5f, ratio), width);
        }

        /*
     * А здесь просто берем одну сторону за фактическую и исходя из нее вычисляем другую.
     */

        private static void fillDimensionZW(VKApiPhotoSize result, float ratio, int allowedWidth, int allowedHeight)
        {
            if (ratio > 1)
            {
                // ширина больше высоты
                result.width = allowedWidth;
                result.height = (int) (result.width/ratio);
            }
            else
            {
                result.height = allowedHeight;
                result.width = (int) (result.height*ratio);
            }
        }

        /**
     * Creates a dimension with explicit dimensions.
     * Can be helpful if the dimensions are exactly known.
     */

        public static VKApiPhotoSize create(string url, int width, int height)
        {
            VKApiPhotoSize result = new VKApiPhotoSize();
            result.src = url;
            result.width = width;
            result.height = height;
            float ratio = width/(float) height;
            if (width <= 75)
            {
                result.type = S;
            }
            else if (width <= 130)
            {
                result.type = ratio <= 1.5f ? O : M;
            }
            else if (width <= 200 && ratio <= 1.5f)
            {
                result.type = P;
            }
            else if (width <= 320 && ratio <= 1.5f)
            {
                result.type = Q;
            }
            else if (width <= 604)
            {
                result.type = X;
            }
            else if (width <= 807)
            {
                result.type = Y;
            }
            else if (width <= 1280 && height <= 1024)
            {
                result.type = Z;
            }
            else if (width <= 2560 && height <= 2048)
            {
                result.type = W;
            }
            return result;
        }

        /**
     * Creates a dimension type and size of the original.
     */

        public static VKApiPhotoSize create(string url, char type, int originalWidth, int originalHeight)
        {
            VKApiPhotoSize result = new VKApiPhotoSize();
            result.src = url;
            result.type = type;
            fillDimensions(result, originalWidth, originalHeight);
            return result;
        }

        /**
     * Creates a square dimension type and size of the original.
     */

        public static VKApiPhotoSize create(string url, int dimension)
        {
            return create(url, dimension, dimension);
        }
    }
}