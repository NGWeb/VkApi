#region usings

using System.Collections.Generic;

#endregion

namespace Vk.SDK.Model
{
    public class VkAttachments : VkList<Attachment>
    {
        public VkAttachments()
        {
        }

        public VkAttachments(List<Attachment> data)
            : base(data)
        {
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
}