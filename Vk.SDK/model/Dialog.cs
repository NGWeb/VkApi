using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.SDK.Model
{
    public class Dialog : IVKApiModel
    {
        public int? unread { get; set; }
        public Message message { get; set; }
    }
}
