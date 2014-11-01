using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.SDK.Model.AttachmentWarpers
{
    public class PollWarper : Attachment, IIdentifiable
    {
        public override int Id { get; set; }
        public Poll Poll { get; set; }
        public override string ToAttachmentString()
        {
            return this.Poll.ToAttachmentString();
        }
        public override string GetType()
        {
            return AttachmentType.TYPE_POLL;
        }
    }
}
