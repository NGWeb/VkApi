#region usings

using System.Text;

#endregion

namespace Vk.SDK.Model
{
    public class Photo : Attachment, IIdentifiable
    {
        /**
     * Photo ID, positive number
     */

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
        public VkPhotoSizes src = new VkPhotoSizes();

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

        /**
     * Fills a Photo instance from JObject.
     */
        //public VKApiPhoto parse(JObject from) {
        //    album_id = from.optInt("album_id");
        //    date = from.optLong("date");
        //    height = from.optInt("height");
        //    width = from.optInt("width");
        //    owner_id = from.optInt("owner_id");
        //    id = from.optInt("id");
        //    text = from.optstring("text");
        //    access_key = from.optstring("access_key");

        //    photo_75 = from.optstring("photo_75");
        //    photo_130 = from.optstring("photo_130");
        //    photo_604 = from.optstring("photo_604");
        //    photo_807 = from.optstring("photo_807");
        //    photo_1280 = from.optstring("photo_1280");
        //    photo_2560 = from.optstring("photo_2560");

        //    JObject likes = from.optJObject("likes");
        //    this.likes = ParseUtils.parseInt(likes, "count");
        //    this.user_likes = ParseUtils.parsebool(likes, "user_likes");
        //    comments = parseInt(from.optJObject("comments"), "count");
        //    tags = parseInt(from.optJObject("tags"), "count");
        //    can_comment = parsebool(from, "can_comment");

        //    src.setOriginalDimension(width, height);
        //    JSONArray photo_sizes = from.optJSONArray("sizes");
        //    if(photo_sizes != null) {
        //        src.fill(photo_sizes);
        //    } else {
        //        if(!TextUtils.isEmpty(photo_75)) {
        //            src.add(VKApiPhotoSize.create(photo_75, VKApiPhotoSize.S, width, height));
        //        }
        //        if(!TextUtils.isEmpty(photo_130)) {
        //            src.add(VKApiPhotoSize.create(photo_130, VKApiPhotoSize.M, width, height));
        //        }
        //        if(!TextUtils.isEmpty(photo_604)) {
        //            src.add(VKApiPhotoSize.create(photo_604, VKApiPhotoSize.X, width, height));
        //        }
        //        if(!TextUtils.isEmpty(photo_807)) {
        //            src.add(VKApiPhotoSize.create(photo_807, VKApiPhotoSize.Y, width, height));
        //        }
        //        if(!TextUtils.isEmpty(photo_1280)) {
        //            src.add(VKApiPhotoSize.create(photo_1280, VKApiPhotoSize.Z, width, height));
        //        }
        //        if(!TextUtils.isEmpty(photo_2560)) {
        //            src.add(VKApiPhotoSize.create(photo_2560, VKApiPhotoSize.W, width, height));
        //        }
        //        src.sort();
        //    }
        //    return this;
        //}


        /**
     * Creates empty Photo instance.
     */


        public override int Id { get; set; }


        public override string ToAttachmentString()
        {
            StringBuilder result = new StringBuilder(AttachmentType.TYPE_PHOTO).Append(owner_id).Append('_').Append(id);
            if (!string.IsNullOrEmpty(access_key))
            {
                result.Append('_');
                result.Append(access_key);
            }
            return result.ToString();
        }


        public override string GetType()
        {
            return AttachmentType.TYPE_PHOTO;
        }


        public int describeContents()
        {
            return 0;
        }
    }
}