using System;
using System.Text;
using Newtonsoft.Json.Linq;
using Vk.SDK.model;

public class VKApiVideo : VKApiAttachment, IIdentifiable {

    /**
     * Video ID.
     */
    public int id;

    /**
     * Video owner ID.
     */
    public int owner_id;

    /**
     * Video album ID.
     */
    public int album_id;

    /**
     * Video title.
     */
    public string title;

    /**
     * Text describing video.
     */
    public string description;

    /**
     * Duration of the video in seconds.
     */
    public int duration;

    /**
     * string with video+vid key.
     */
    public string link;

    /**
     * Date when the video was added, as unixtime.
     */
    public long date;

    /**
     * Number of views of the video.
     */
    public int views;

    /**
     * URL of the page with a player that can be used to play a video in the browser.
     * Flash and HTML5 video players are supported; the player is always zoomed to fit
     * the window size.
     */
    public string player;

    /**
     * URL of the video cover image with the size of 130x98px.
     */
    public string photo_130;

    /**
     * URL of the video cover image with the size of 320x240px.
     */
    public string photo_320;

    /**
     * URL of the video cover image with the size of 640x480px (if available).
     */
    public string photo_640;

    /**
     * Array of all photos.
     */
    public VKPhotoSizes photo = new VKPhotoSizes();

    /**
     * An access key using for get information about hidden objects.
     */
    public string access_key;

    /**
     * Number of comments on the video.
     */
    public int comments;

    /**
     * Whether the current user can comment on the video
     */
    public bool can_comment;

    /**
     * Whether the current user can repost this video
     */
    public bool can_repost;

    /**
     * Information whether the current user liked the video.
     */
    public bool user_likes;

    /**
     * Information whether the the video should be repeated.
     */
    public bool repeat;

    /**
     * Number of likes on the video.
     */
    public int likes;

    /**
     * Privacy to view of this video.
     */
    public int privacy_view;

    /**
     * Privacy to comment of this video.
     */
    public int privacy_comment;

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

    /**
     * URL of the external video link.
     */
    public string external;

    /**
     * Fills a Video instance from JObject.
     */
    public VKApiVideo parse(JObject from) {
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

        //privacy_view = VKPrivacy.parsePrivacy(from.optJObject("privacy_view"));
        //privacy_comment = VKPrivacy.parsePrivacy(from.optJObject("privacy_comment"));

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
    public VKApiVideo() {

    }


    public int Id
    {
        get { return id; }
    }


    public String ToAttachmentString() {
        StringBuilder result = new StringBuilder(TYPE_VIDEO).Append(owner_id).Append('_').Append(id);
        if(string.IsNullOrEmpty(access_key)) {
            result.Append('_');
            result.Append(access_key);
        }
        return result.ToString();
    }

    
    public string getType() {
        return TYPE_VIDEO;
    }

    
    public string tostring() {
        return title;
    }

    
    public int describeContents() {
        return 0;
    }
}
