
using Vk.SDK.model;

public class VKApiPhoto : VKAttachments.VKApiAttachment , IIdentifiable {

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
     * Fills a Photo instance from JSONObject.
     */
    public VKApiPhoto parse(JSONObject from) {
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

        JSONObject likes = from.optJSONObject("likes");
        this.likes = ParseUtils.parseInt(likes, "count");
        this.user_likes = ParseUtils.parsebool(likes, "user_likes");
        comments = parseInt(from.optJSONObject("comments"), "count");
        tags = parseInt(from.optJSONObject("tags"), "count");
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
    public VKApiPhoto(Parcel in) {
        this.id = in.readInt();
        this.album_id = in.readInt();
        this.owner_id = in.readInt();
        this.width = in.readInt();
        this.height = in.readInt();
        this.text = in.readstring();
        this.date = in.readLong();
        this.src = in.readParcelable(VKPhotoSizes.class.getClassLoader());
        this.photo_75 = in.readstring();
        this.photo_130 = in.readstring();
        this.photo_604 = in.readstring();
        this.photo_807 = in.readstring();
        this.photo_1280 = in.readstring();
        this.photo_2560 = in.readstring();
        this.user_likes = in.readByte() != 0;
        this.can_comment = in.readByte() != 0;
        this.likes = in.readInt();
        this.comments = in.readInt();
        this.tags = in.readInt();
        this.access_key = in.readstring();
    }

    /**
     * Creates empty Photo instance.
     */
    public VKApiPhoto() {

    }

    
    public int GetId() {
        return id;
    }

    
    public CharSequence toAttachmentstring() {
        stringBuilder result = new stringBuilder(TYPE_PHOTO).append(owner_id).append('_').append(id);
        if(!TextUtils.isEmpty(access_key)) {
            result.append('_');
            result.append(access_key);
        }
        return result;
    }

    
    public string getType() {
        return TYPE_PHOTO;
    }

    
    public int describeContents() {
        return 0;
    }

    
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(this.id);
        dest.writeInt(this.album_id);
        dest.writeInt(this.owner_id);
        dest.writeInt(this.width);
        dest.writeInt(this.height);
        dest.writestring(this.text);
        dest.writeLong(this.date);
        dest.writeParcelable(this.src, flags);
        dest.writestring(this.photo_75);
        dest.writestring(this.photo_130);
        dest.writestring(this.photo_604);
        dest.writestring(this.photo_807);
        dest.writestring(this.photo_1280);
        dest.writestring(this.photo_2560);
        dest.writeByte(user_likes ? (byte) 1 : (byte) 0);
        dest.writeByte(can_comment ? (byte) 1 : (byte) 0);
        dest.writeInt(this.likes);
        dest.writeInt(this.comments);
        dest.writeInt(this.tags);
        dest.writestring(this.access_key);
    }

    public static Creator<VKApiPhoto> CREATOR = new Creator<VKApiPhoto>() {
        public VKApiPhoto createFromParcel(Parcel source) {
            return new VKApiPhoto(source);
        }

        public VKApiPhoto[] newArray(int size) {
            return new VKApiPhoto[size];
        }
    };

}
