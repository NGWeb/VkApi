using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.SDK
{
    public static class StreamExtension
    {
        public static void CopyToStream(this Stream input, Stream output)
        {

            var buffer = new byte[16 * 1024];

            int read;

            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                output.Write(buffer, 0, read);
        }
    }
}
