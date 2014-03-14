
using System.Text;
using Vk.SDK.model;

public class VKApiPhoto : VKApiAttachment , IIdentifiable {

    /**
     * Photo ID, positive number
     */
    public int id;

    /**
     * Photo album ID.
     */
    public int album_id;

    /**
     * ID of the user or community that owns the photo.
     */
    public int owner_id;

    /**
     * Width (in pixels) of the original photo.
     */
    public int width;

    /**
     * Height (in pixels) of the original photo.
     */
    public int height;

    /**
     * Text describing the photo.
     */
    public string text;

    /**
     * Date (in Unix time) the photo was added.
     */
    public long date;

    /**
     * URL of image with maximum size 75x75px.
     */
    public string photo_75;

    /**
     * URL of image with maximum size 130x130px.
     */
    public string photo_130;

    /**
     * URL of image with maximum size 604x604px.
     */
    public string photo_604;

    /**
     * URL of image with maximum size 807x807px.
     */
    public string photo_807;

    /**
     * URL of image with maximum size 1280x1024px.
     */
    public string photo_1280;

    /**
     * URL of image with maximum size 2560x2048px.
     */
    public string photo_2560;

    /**
     * All photo thumbs in photo sizes.
     * It has data even if server returned them without {@code PhotoSizes} format.
     */
    public VKPhotoSizes src = new VKPhotoSizes();

    /**
     * Information whether the current user liked the photo.
     */
    public bool user_likes;

    /**
     * Whether the current user can comment on the photo
     */
    public bool can_comment;

    /**
     * Number of likes on the photo.
     */
    public int likes;

    /**
     * Number of comments on the photo.
     */
    public int comments;

    /**
     * Number of tags on the photo.
     */
    public int tags;

    /**
     * An access key using for get information about hidden objects.
     */
    public string access_key;

    /**
     * Fills a Photo instance from JObject.
     */
    public VKApiPhoto parse(JObject from) {
        album_id = from.optInt("album_id");
        date = from.optLong("date");
        height = from.optInt("height");
        width = from.optInt("width");
        owner_id = from.optInt("owner_id");
        id = from.optInt("id");
        text = from.optstring("text");
        access_key = from.optstring("access_key");

        photo_75 = from.optstring("photo_75");
        photo_130 = from.optstring("photo_130");
        photo_604 = from.optstring("photo_604");
        photo_807 = from.optstring("photo_807");
        photo_1280 = from.optstring("photo_1280");
        photo_2560 = from.optstring("photo_2560");

        JObject likes = from.optJObject("likes");
        this.likes = ParseUtils.parseInt(likes, "count");
        this.user_likes = ParseUtils.parsebool(likes, "user_likes");
        comments = parseInt(from.optJObject("comments"), "count");
        tags = parseInt(from.optJObject("tags"), "count");
        can_comment = parsebool(from, "can_comment");

        src.setOriginalDimension(width, height);
        JSONArray photo_sizes = from.optJSONArray("sizes");
        if(photo_sizes != null) {
            src.fill(photo_sizes);
        } else {
            if(!TextUtils.isEmpty(photo_75)) {
                src.add(VKApiPhotoSize.create(photo_75, VKApiPhotoSize.S, width, height));
            }
            if(!TextUtils.isEmpty(photo_130)) {
                src.add(VKApiPhotoSize.create(photo_130, VKApiPhotoSize.M, width, height));
            }
            if(!TextUtils.isEmpty(photo_604)) {
                src.add(VKApiPhotoSize.create(photo_604, VKApiPhotoSize.X, width, height));
            }
            if(!TextUtils.isEmpty(photo_807)) {
                src.add(VKApiPhotoSize.create(photo_807, VKApiPhotoSize.Y, width, height));
            }
            if(!TextUtils.isEmpty(photo_1280)) {
                src.add(VKApiPhotoSize.create(photo_1280, VKApiPhotoSize.Z, width, height));
            }
            if(!TextUtils.isEmpty(photo_2560)) {
                src.add(VKApiPhotoSize.create(photo_2560, VKApiPhotoSize.W, width, height));
            }
            src.sort();
        }
        return this;
    }

    /**
     * Creates a Photo instance from Parcel.
     */
   

    /**
     * Creates empty Photo instance.
     */
    public VKApiPhoto() {

    }


    public override int Id
    {
        get { return id; }
    }


    public override string toAttachmentstring() {
        StringBuilder result = new StringBuilder(TYPE_PHOTO).Append(owner_id).Append('_').Append(id);
        if(!TextUtils.isEmpty(access_key)) {
            result.Append('_');
            result.Append(access_key);
        }
        return result.ToString();
    }

    
    public override string getType() {
        return TYPE_PHOTO;
    }

    
    public int describeContents() {
        return 0;
    }

}