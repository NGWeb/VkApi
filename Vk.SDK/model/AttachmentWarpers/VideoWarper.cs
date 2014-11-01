using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.SDK.Model.AttachmentWarpers
{
    public class VideoWarper : Attachment, IIdentifiable
    {
        public override int Id { get; set; }
        public Video Video { get; set; }
        public override string ToAttachmentString()
        {
            return this.Video.ToAttachmentString();
        }
        public override string GetType()
        {
            return AttachmentType.TYPE_VIDEO;
        }
    }
}
