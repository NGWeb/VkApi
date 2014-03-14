using Newtonsoft.Json.Linq;
using Vk.SDK.model;

public class VKApiPhotoAlbum : VKApiAttachment ,IIdentifiable {

    /**
     * URL for empty album cover with max width at 75px
     */
    public readonly static string COVER_S = "http://vk.com/images/s_noalbum.png";

    /**
     * URL of empty album cover with max width at 130px
     */
    public readonly static string COVER_M = "http://vk.com/images/m_noalbum.png";

    /**
     * URL of empty album cover with max width at 604px
     */
    public readonly static string COVER_X = "http://vk.com/images/x_noalbum.png";

    /**
     * Album ID.
     */
    public int id;

    /**
     * Album title.
     */
    public string title;

    /**
     * Number of photos in the album.
     */
    public int size;

    /**
     * Privacy settings for the album.
     */
    public int privacy;

    /**
     * Album description.
     */
    public string description;

    /**
     * ID of the user or community that owns the album.
     */
    public int owner_id;

    /**
     * Whether a user can upload photos to this album(false — cannot, true — can).
     */
    public bool can_upload;

    /**
     * Date (in Unix time) the album was last updated.
     */
    public long updated;

    /**
     * Album creation date (in Unix time).
     */
    public long created;

    /**
     * ID of the photo which is the cover.
     */
    public int thumb_id;

    /**
     * Link to album cover photo.
     */
    public string thumb_src;

    /**
     * Links to to cover photo.
     */
    public VKPhotoSizes photo = new VKPhotoSizes();

    /**
     * Creates a PhotoAlbum instance from JObject.
     */
    public VKApiPhotoAlbum parse(JObject from) {
        id = from.optInt("id");
        thumb_id = from.optInt("thumb_id");
        owner_id = from.optInt("owner_id");
        title = from.optstring("title");
        description = from.optstring("description");
        created = from.optLong("created");
        updated = from.optLong("updated");
        size = from.optInt("size");
        can_upload = ParseUtils.parsebool(from, "can_upload");
        thumb_src = from.optstring("thumb_src");
        if(from.has("privacy")) {
            privacy = from.optInt("privacy");
        } else {
            privacy = VKPrivacy.parsePrivacy(from.optJObject("privacy_view"));
        }
        JSONArray sizes = from.optJSONArray("sizes");
        if(sizes != null) {
            photo.fill(sizes);
        } else {
            photo.add(VKApiPhotoSize.create(COVER_S, 75, 55));
            photo.add(VKApiPhotoSize.create(COVER_M, 130, 97));
            photo.add(VKApiPhotoSize.create(COVER_X, 432, 249));
            photo.sort();
        }
        return this;
    }

    /**
     * Creates a PhotoAlbum instance from Parcel.
     */
    public VKApiPhotoAlbum() {

    }

    public bool isClosed() {
        return privacy != VKPrivacy.PRIVACY_ALL;
    }


    public int Id
    {
        get { return id; }
    }


    public string tostring() {
        return title;
    }

    
    public CharSequence toAttachmentstring() {
        return new stringBuilder(TYPE_ALBUM).append(owner_id).append('_').append(id);
    }

    
    public string getType() {
        return TYPE_ALBUM;
    }

    
    public int describeContents() {
        return 0;
    }

    
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(this.id);
        dest.writestring(this.title);
        dest.writeInt(this.size);
        dest.writeInt(this.privacy);
        dest.writestring(this.description);
        dest.writeInt(this.owner_id);
        dest.writeByte(can_upload ? (byte) 1 : (byte) 0);
        dest.writeLong(this.updated);
        dest.writeLong(this.created);
        dest.writeInt(this.thumb_id);
        dest.writestring(this.thumb_src);
        dest.writeParcelable(this.photo, flags);
    }

    public static Creator<VKApiPhotoAlbum> CREATOR = new Creator<VKApiPhotoAlbum>() {
        public VKApiPhotoAlbum createFromParcel(Parcel source) {
            return new VKApiPhotoAlbum(source);
        }

        public VKApiPhotoAlbum[] newArray(int size) {
            return new VKApiPhotoAlbum[size];
        }
    };

}
