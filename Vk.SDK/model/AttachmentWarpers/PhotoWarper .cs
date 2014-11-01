using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.SDK.Model.AttachmentWarpers
{
    public class PhotoWarper : Attachment, IIdentifiable
    {
        public override int Id { get; set; }
        public Photo Photo { get; set; }
        public override string ToAttachmentString()
        {
            return this.Photo.ToAttachmentString();
        }
        public override string GetType()
        {
            return AttachmentType.TYPE_PHOTO;
        }
    }
}
