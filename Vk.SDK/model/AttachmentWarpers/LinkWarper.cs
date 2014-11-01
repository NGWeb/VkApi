using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.SDK.Model.AttachmentWarpers
{
    public class LinkWarper : Attachment, IIdentifiable
    {
        public override int Id { get; set; }
        public Link Link { get; set; }
        public override string ToAttachmentString()
        {
            return this.Link.ToAttachmentString();
        }
        public override string GetType()
        {
            return AttachmentType.TYPE_LINK;
        }
    }
}
