#region usings

using System.IO;
using Vk.SDK.Context;
using Vk.SDK.Http;
using Vk.SDK.Photo;

#endregion

namespace Vk.SDK
{
    public class VKApi
    {
        /**
         * https://vk.com/dev/users
         * Returns object for preparing requests to users part of API
         */

     
        /**
         * Upload a specified file to VK servers for posting on user or group wall
         * @param image Image file to upload. Must have extension jpg or png
         * @param userId User wall id or 0
         * @param groupId Group id or 0
         * @return Prepared vk request for photo upload
         */

        public static AbstractRequest UploadWallPhotoRequest(FileInfo[] image, long userId, int groupId, IRequestFactory factory)
        {
            return new VKUploadWallPhotoRequest(image, userId, groupId,factory);
        }

        /**
         * Upload a specified file to VK servers for posting on user or group wall
         * @param image Special image object to upload
         * @param userId User wall id or 0
         * @param groupId Group id or 0
         * @return Prepared vk request for photo upload
         */

        public static VKUploadWallPhotoRequest UploadWallPhotoRequest(VKUploadImage image, long userId, int groupId, IRequestFactory factory)
        {
            return new VKUploadWallPhotoRequest(image, userId, groupId,factory);
        }

        /**
         * Upload a specified file to VK servers and saves it into the album
         * @param image Image file to upload. Must have extension jpg or png
         * @param albumId Album id to upload. Must be specified
         * @param groupId Group id or 0
         * @return Prepared vk request for photo upload
         */

        public static VKUploadAlbumPhotoRequest UploadAlbumPhotoRequest(FileInfo[] image, long albumId, int groupId, IRequestFactory factory)
        {
            return new VKUploadAlbumPhotoRequest(image, albumId, groupId,factory);
        }

        /**
         * Upload a specified file to VK servers and saves it into the album
         * @param image Special image object to upload
         * @param albumId Album id to upload. Must be specified
         * @param groupId Group id or 0
         * @return Prepared vk request for photo upload
         */

        public static AbstractRequest UploadAlbumPhotoRequest(VKUploadImage image, long albumId, int groupId, IRequestFactory factory)
        {
            return new VKUploadAlbumPhotoRequest(image, albumId, groupId,factory);
        }
    }
}