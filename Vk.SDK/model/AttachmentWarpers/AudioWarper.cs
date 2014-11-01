using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.SDK.Model.AttachmentWarpers
{
    public class AudioWarper : Attachment, IIdentifiable
    {
        public override int Id { get; set; }
        public Audio Audio { get; set; }
        public override string ToAttachmentString()
        {
            return this.Audio.ToAttachmentString();
        }
        public override string GetType()
        {
            return AttachmentType.TYPE_AUDIO;
        }
    }
}
