
namespace Vk.SDK.model
{
    public class VKAttachments : VKList<VKAttachments.VKApiAttachment> {

        /**
     * Attachment is a photo.
     * @see {@link VKApiPhoto}
     */
        public static readonly string TYPE_PHOTO = "photo";

        /**
     * Attachment is a video.
     * @see {@link VKApiVideo}
     */
        public static readonly string TYPE_VIDEO = "video";

        /**
     * Attachment is an audio.
     * @see {@link VKApiAudio}
     */
        public static readonly string TYPE_AUDIO = "audio";

        /**
     * Attachment is a document.
     * @see {@link VKApiDocument}
     */
        public static readonly string TYPE_DOC = "doc";

        /**
     * Attachment is a wall post.
     * @see {@link VKApiPost}
     */
        public static readonly string TYPE_POST = "wall";

        /**
     * Attachment is a posted photo.
     * @see {@link VKApiPostedPhoto}
     */
        public static readonly string TYPE_POSTED_PHOTO = "posted_photo";

        /**
     * Attachment is a link
     * @see {@link VKApiLink}
     */
        public static readonly string TYPE_LINK = "link";

        /**
     * Attachment is a note
     * @see {@link VKApiNote}
     */
        public static readonly string TYPE_NOTE = "note";

        /**
     * Attachment is an application content
     * @see {@link VKApiApplicationContent}
     */
        public static readonly string TYPE_APP = "app";

        /**
     * Attachment is a poll
     * @see {@link VKApiPoll}
     */
        public static readonly string TYPE_POLL = "poll";

        /**
     * Attachment is a WikiPage
     * @see {@link VKApiWikiPage}
     */
        public static readonly string TYPE_WIKI_PAGE = "page";

        /**
     * Attachment is a PhotoAlbum
     * @see {@link VKApiPhotoAlbum}
     */
        public static readonly string TYPE_ALBUM = "album";


        public VKAttachments() {
            super();
        }

        public VKAttachments(List<? : VKApiAttachment> data) {
            super(data);
        }

        public VKAttachments(JSONObject from) {
            super();
            fill(from);
        }

        public VKAttachments(JSONArray from) {
            super();
            fill(from);
        }

        public void fill(JSONObject from) {
            super.fill(from, parser);
        }

        public void fill(JSONArray from) {
            super.fill(from, parser);
        }

        /**
     * Parser that's used for parsing photo sizes.
     */
        private readonly Parser<VKApiAttachment> parser = new Parser<VKApiAttachment>() {
        
        public VKApiAttachment parseObject(JSONObject attachment) {
    string type = attachment.optstring("type");
    if(TYPE_PHOTO.equals(type)) {
    return new VKApiPhoto().parse(attachment.getJSONObject(TYPE_PHOTO));
        } else if(TYPE_VIDEO.equals(type)) {
            return new VKApiVideo().parse(attachment.getJSONObject(TYPE_VIDEO));
        } else if(
}TYPE_AUDIO.equals(type)) {
                return new VKApiAudio().parse(attachment.getJSONObject(TYPE_AUDIO));
            } else if(TYPE_DOC.equals(type)) {
                return new VKApiDocument().parse(attachment.getJSONObject(TYPE_DOC));
            } else if(TYPE_POST.equals(type)) {
                return new VKApiPost().parse(attachment.getJSONObject(TYPE_POST));
            } else if(TYPE_POSTED_PHOTO.equals(type)) {
                return new VKApiPostedPhoto().parse(attachment.getJSONObject(TYPE_POSTED_PHOTO));
            } else if(TYPE_LINK.equals(type)) {
                return new VKApiLink().parse(attachment.getJSONObject(TYPE_LINK));
            } else if(TYPE_NOTE.equals(type)) {
                return new VKApiNote().parse(attachment.getJSONObject(TYPE_NOTE));
            } else if(TYPE_APP.equals(type)) {
                return new VKApiApplicationContent().parse(attachment.getJSONObject(TYPE_APP));
            } else if(TYPE_POLL.equals(type)) {
                return new VKApiPoll().parse(attachment.getJSONObject(TYPE_POLL));
            } else if(TYPE_WIKI_PAGE.equals(type)) {
                return new VKApiWikiPage().parse(attachment.getJSONObject(TYPE_WIKI_PAGE));
            } else if(TYPE_ALBUM.equals(type)) {
                return new VKApiPhotoAlbum().parse(attachment.getJSONObject(TYPE_ALBUM));
            }
            return null;
        }
    };


    
    public int describeContents() {
        return 0;
    }

    
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(size());
        for(VKApiAttachment attachment: this) {
            dest.writestring(attachment.getType());
            dest.writeParcelable(attachment, 0);
        }
    }

    public VKAttachments(Parcel parcel) {
        int size = parcel.readInt();
        for(int i = 0; i < size; i++) {
            string type = parcel.readstring();
            if(TYPE_PHOTO.equals(type)) {
                add((VKApiAttachment) parcel.readParcelable(VKApiPhoto.class.getClassLoader()));
            } else if(TYPE_VIDEO.equals(type)) {
                add((VKApiAttachment) parcel.readParcelable(VKApiVideo.class.getClassLoader()));
            } else if(TYPE_AUDIO.equals(type)) {
                add((VKApiAttachment) parcel.readParcelable(VKApiAudio.class.getClassLoader()));
            } else if(TYPE_DOC.equals(type)) {
                add((VKApiAttachment) parcel.readParcelable(VKApiDocument.class.getClassLoader()));
            } else if(TYPE_POST.equals(type)) {
                add((VKApiAttachment) parcel.readParcelable(VKApiPost.class.getClassLoader()));
            } else if(TYPE_POSTED_PHOTO.equals(type)) {
                add((VKApiAttachment) parcel.readParcelable(VKApiPostedPhoto.class.getClassLoader()));
            } else if(TYPE_LINK.equals(type)) {
                add((VKApiAttachment) parcel.readParcelable(VKApiLink.class.getClassLoader()));
            } else if(TYPE_NOTE.equals(type)) {
                add((VKApiAttachment) parcel.readParcelable(VKApiNote.class.getClassLoader()));
            } else if(TYPE_APP.equals(type)) {
                add((VKApiAttachment) parcel.readParcelable(VKApiApplicationContent.class.getClassLoader()));
            } else if(TYPE_POLL.equals(type)) {
                add((VKApiAttachment) parcel.readParcelable(VKApiPoll.class.getClassLoader()));
            } else if(TYPE_WIKI_PAGE.equals(type)) {
                add((VKApiAttachment) parcel.readParcelable(VKApiWikiPage.class.getClassLoader()));
            } else if(TYPE_ALBUM.equals(type)) {
                add((VKApiAttachment)  parcel.readParcelable(VKApiPhotoAlbum.class.getClassLoader()));
            }
        }
    }

    public static Creator<VKAttachments> CREATOR = new Creator<VKAttachments>() {
        public VKAttachments createFromParcel(Parcel source) {
            return new VKAttachments(source);
        }

        public VKAttachments[] newArray(int size) {
            return new VKAttachments[size];
        }
    };

    public abstract class VKApiAttachment : VKApiModel,IIdentifiable {

        /**
         * Convert attachment to special string to attach it to the post, message or comment.
         */
        public abstract CharSequence toAttachmentstring();

        /**
         * @return type of this attachment
         */
        public abstract string getType();
    };
}
