#region usings

using System.IO;
using Vk.SDK.Vk;

#endregion

namespace Vk.SDK.Photo
{
    public class VKUploadImage : VKObject
    {
        /**
     * Bitmap representation of image
     */
        public readonly FileInfo mImageData;
        /**
     * Image basic info
     */
        public readonly VKImageParameters mParameters;

        public VKUploadImage(FileInfo data, VKImageParameters parameters)
        {
            mImageData = data;
            mParameters = parameters;
        }
    }
}