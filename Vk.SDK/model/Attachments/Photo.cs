#region usings

using System.Text;

#endregion

namespace Vk.SDK.Model
{
    public class Photo : IVKApiModel, IIdentifiable
    {
        /**
     * Photo ID, positive number
     */
        public Photo photo { get { return this; } }
        /**
     * Photo album ID.
     */
        public string access_key;
        public int album_id;
        public bool can_comment;
        public int comments;

        /**
     * ID of the user or community that owns the photo.
     */

        /**
     * Date (in Unix time) the photo was added.
     */
        public long date;
        public int height;
        public int id;
        public int likes;
        public int owner_id;
        public string photo_1280;

        /**
     * URL of image with maximum size 75x75px.
     */

        /**
     * URL of image with maximum size 130x130px.
     */
        public string photo_130;
        public string photo_2560;

        /**
     * URL of image with maximum size 604x604px.
     */
        public string photo_604;
        public string photo_75;

        /**
     * URL of image with maximum size 807x807px.
     */
        public string photo_807;

        /**
     * URL of image with maximum size 1280x1024px.
     */

        /**
     * All photo thumbs in photo sizes.
     * It has data even if server returned them without {@code PhotoSizes} format.
     */
        public PhotoSizes src = new PhotoSizes();

        /**
     * Information whether the current user liked the photo.
     */

        /**
     * Number of tags on the photo.
     */
        public int tags;
        public string text;
        public bool user_likes;
        public int width;

        /**
     * An access key using for get information about hidden objects.
     */

        public int Id { get; set; }


        public string ToAttachmentString()
        {
            StringBuilder result = new StringBuilder(AttachmentType.TYPE_PHOTO).Append(owner_id).Append('_').Append(id);
            if (!string.IsNullOrEmpty(access_key))
            {
                result.Append('_');
                result.Append(access_key);
            }
            return result.ToString();
        }


        public string GetType()
        {
            return AttachmentType.TYPE_PHOTO;
        }


        public int describeContents()
        {
            return 0;
        }
    }
}