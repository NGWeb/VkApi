
using System;
using System.Collections.Generic;
using Vk.SDK.model;

namespace Vk.SDK.model
{
    public class VKAttachments : VKList<VKApiAttachment>
    {

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


        public VKAttachments()
        {
        }

        public VKAttachments(List<VKApiAttachment> data)
            : base(data)
        {

        }

        public VKAttachments(JObject from)
        {
            super();
            fill(from);
        }

        public VKAttachments(JSONArray from)
        {
            super();
            fill(from);
        }

        public void fill(JObject from)
        {
            super.fill(from, parser);
        }

        public void fill(JSONArray from)
        {
            super.fill(from, parser);
        }

        /**
     * Parser that's used for parsing photo sizes.
     */
        //        private readonly Parser<VKApiAttachment> parser = new Parser<VKApiAttachment>() {

        //        public VKApiAttachment parseObject(JObject attachment) {
        //    string type = attachment.optstring("type");
        //    if(TYPE_PHOTO.Equals(type)) {
        //    return new VKApiPhoto().parse(attachment.getJObject(TYPE_PHOTO));
        //        } else if(TYPE_VIDEO.Equals(type)) {
        //            return new VKApiVideo().parse(attachment.getJObject(TYPE_VIDEO));
        //        } else if(
        //}TYPE_AUDIO.Equals(type)) {
        //                return new VKApiAudio().parse(attachment.getJObject(TYPE_AUDIO));
        //            } else if(TYPE_DOC.Equals(type)) {
        //                return new VKApiDocument().parse(attachment.getJObject(TYPE_DOC));
        //            } else if(TYPE_POST.Equals(type)) {
        //                return new VKApiPost().parse(attachment.getJObject(TYPE_POST));
        //            } else if(TYPE_POSTED_PHOTO.Equals(type)) {
        //                return new VKApiPostedPhoto().parse(attachment.getJObject(TYPE_POSTED_PHOTO));
        //            } else if(TYPE_LINK.Equals(type)) {
        //                return new VKApiLink().parse(attachment.getJObject(TYPE_LINK));
        //            } else if(TYPE_NOTE.Equals(type)) {
        //                return new VKApiNote().parse(attachment.getJObject(TYPE_NOTE));
        //            } else if(TYPE_APP.Equals(type)) {
        //                return new VKApiApplicationContent().parse(attachment.getJObject(TYPE_APP));
        //            } else if(TYPE_POLL.Equals(type)) {
        //                return new VKApiPoll().parse(attachment.getJObject(TYPE_POLL));
        //            } else if(TYPE_WIKI_PAGE.Equals(type)) {
        //                return new VKApiWikiPage().parse(attachment.getJObject(TYPE_WIKI_PAGE));
        //            } else if(TYPE_ALBUM.Equals(type)) {
        //                return new VKApiPhotoAlbum().parse(attachment.getJObject(TYPE_ALBUM));
        //            }
        //            return null;
        //        }
        //    };

    }
    public abstract class VKApiAttachment : VKApiModel, IIdentifiable
    {
        /**
             * Convert attachment to special string to attach it to the post, message or comment.
             */
        public abstract string toAttachmentstring();

        /**
         * @return type of this attachment
         */
        public abstract string getType();

        public abstract int Id
        {
            get;
            protected set;
        }
    };

}



