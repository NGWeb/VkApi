#region usings

using System.Text;
using Newtonsoft.Json.Linq;

#endregion

namespace Vk.SDK.Model
{
    public class PhotoAlbum : Attachment
    {
        /**
     * URL for empty album cover with max width at 75px
     */
        public static readonly string COVER_S = "http://vk.com/images/s_noalbum.png";

        /**
     * URL of empty album cover with max width at 130px
     */
        public static readonly string COVER_M = "http://vk.com/images/m_noalbum.png";

        /**
     * URL of empty album cover with max width at 604px
     */
        public static readonly string COVER_X = "http://vk.com/images/x_noalbum.png";

        /**
     * Album ID.
     */

        /**
     * Whether a user can upload photos to this album(false — cannot, true — can).
     */
        public bool can_upload;

        /**
     * Date (in Unix time) the album was last updated.
     */

        /**
     * Album creation date (in Unix time).
     */
        public long created;
        public string description;
        public int id;
        public int owner_id;
        public PhotoSizes photo = new PhotoSizes();
        public int privacy;
        public int size;

        /**
     * ID of the photo which is the cover.
     */
        public int thumb_id;

        /**
     * Link to album cover photo.
     */
        public string thumb_src;
        public string title;
        public long updated;

        public override int Id
        {
            get { return id; }
            set { id = value; }
        }

        /**
     * Links to to cover photo.
     */

        /**
     * Creates a PhotoAlbum instance from JObject.
     */

        public PhotoAlbum parse(JObject from)
        {
            //id = from.optInt("id");
            //thumb_id = from.optInt("thumb_id");
            //owner_id = from.optInt("owner_id");
            //title = from.optstring("title");
            //description = from.optstring("description");
            //created = from.optLong("created");
            //updated = from.optLong("updated");
            //size = from.optInt("size");
            //can_upload = ParseUtils.parsebool(from, "can_upload");
            //thumb_src = from.optstring("thumb_src");
            //if(from.has("privacy")) {
            //    privacy = from.optInt("privacy");
            //} else {
            //    privacy = Privacy.parsePrivacy(from.optJObject("privacy_view"));
            //}
            //JSONArray sizes = from.optJSONArray("sizes");
            //if(sizes != null) {
            //    photo.fill(sizes);
            //} else {
            //    photo.add(VKApiPhotoSize.create(COVER_S, 75, 55));
            //    photo.add(VKApiPhotoSize.create(COVER_M, 130, 97));
            //    photo.add(VKApiPhotoSize.create(COVER_X, 432, 249));
            //    photo.sort();
            //}
            return this;
        }

        /**
     * Creates a PhotoAlbum instance from Parcel.
     */

        public bool isClosed()
        {
            return privacy != Privacy.PRIVACY_ALL;
        }


        public override string GetType()
        {
            return AttachmentType.TYPE_ALBUM;
        }


        public string tostring()
        {
            return title;
        }


        public override string ToAttachmentString()
        {
            return new StringBuilder(AttachmentType.TYPE_ALBUM).Append(owner_id).Append('_').Append(id).ToString();
        }


        public int describeContents()
        {
            return 0;
        }
    }
}