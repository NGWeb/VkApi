#region usings

using System;
using System.Text;
using Newtonsoft.Json.Linq;

#endregion

namespace Vk.SDK.Model
{
    public class Video : IVKApiModel
    {
        /**
     * Video ID.
     */

        /**
     * An access key using for get information about hidden objects.
     */
        public string access_key;
        public int album_id;

        /**
     * Number of comments on the video.
     */

        /**
     * Whether the current user can comment on the video
     */
        public bool can_comment;

        /**
     * Whether the current user can repost this video
     */
        public bool can_repost;
        public int comments;
        public long date;
        public string description;

        /**
     * Duration of the video in seconds.
     */
        public int duration;
        public string external;
        public int id;

        /**
     * Information whether the current user liked the video.
     */

        /**
     * Number of likes on the video.
     */
        public int likes;
        public string link;

        /**
     * Privacy to view of this video.
     */

        /**
     * URL of video with height of 240 pixels. Returns only if you use direct auth.
     */
        public string mp4_240;

        /**
     * URL of video with height of 360 pixels. Returns only if you use direct auth.
     */
        public string mp4_360;

        /**
     * URL of video with height of 480 pixels. Returns only if you use direct auth.
     */
        public string mp4_480;

        /**
     * URL of video with height of 720 pixels. Returns only if you use direct auth.
     */
        public string mp4_720;
        public int owner_id;
        public PhotoSizes photo = new PhotoSizes();
        public string photo_130;

        /**
     * URL of the video cover image with the size of 320x240px.
     */
        public string photo_320;

        /**
     * URL of the video cover image with the size of 640x480px (if available).
     */
        public string photo_640;
        public string player;
        public int privacy_comment;
        public int privacy_view;
        public bool repeat;
        public string title;
        public bool user_likes;
        public int views;
        public int Id { get; set; }

        /**
     * URL of the external video link.
     */

        /**
     * Fills a Video instance from JObject.
     */

        public Video parse(JObject from)
        {
            //id = from.optInt("id");
            //owner_id = from.optInt("owner_id");
            //title = from.optstring("title");
            //description = from.optstring("description");
            //duration = from.optInt("duration");
            //link = from.optstring("link");
            //date = from.optLong("date");
            //views = from.optInt("views");
            //comments = from.optInt("comments");
            //player = from.optstring("player");
            //access_key = from.optstring("access_key");
            //album_id = from.optInt("album_id");

            //JObject likes = from.optJObject("likes");
            //if(likes != null) {
            //    this.likes = likes.optInt("count");
            //    user_likes = parsebool(likes, "user_likes");
            //}
            //can_comment = parsebool(from, "can_comment");
            //can_repost = parsebool(from, "can_repost");
            //repeat = parsebool(from, "repeat");

            //privacy_view = Privacy.parsePrivacy(from.optJObject("privacy_view"));
            //privacy_comment = Privacy.parsePrivacy(from.optJObject("privacy_comment"));

            //JObject files = from.optJObject("files");
            //if(files != null) {
            //    mp4_240 = files.optstring("mp4_240");
            //    mp4_360 = files.optstring("mp4_360");
            //    mp4_480 = files.optstring("mp4_480");
            //    mp4_720 = files.optstring("mp4_720");
            //    external = files.optstring("external");
            //}

            //photo_130 = from.optstring("photo_130");
            //if(!TextUtils.isEmpty(photo_130)) {
            //    photo.add(VKApiPhotoSize.create(photo_130, 130));
            //}

            //photo_320 = from.optstring("photo_320");
            //if(!TextUtils.isEmpty(photo_320)) {
            //    photo.add(VKApiPhotoSize.create(photo_320, 320));
            //}

            //photo_640 = from.optstring("photo_640");
            //if(!TextUtils.isEmpty(photo_640)) {
            //    photo.add(VKApiPhotoSize.create(photo_640, 640));
            //}
            return this;
        }

        /**
     * Creates a Video instance from Parcel.
     */

        /**
     * Creates empty Video instance.
     */


        public string GetType()
        {
            return AttachmentType.TYPE_VIDEO;
        }

        public string ToAttachmentString()
        {
            StringBuilder result = new StringBuilder(AttachmentType.TYPE_VIDEO).Append(owner_id).Append('_').Append(id);
            if (string.IsNullOrEmpty(access_key))
            {
                result.Append('_');
                result.Append(access_key);
            }
            return result.ToString();
        }


        public override string ToString()
        {
            return title;
        }


        public int describeContents()
        {
            return 0;
        }
    }
}