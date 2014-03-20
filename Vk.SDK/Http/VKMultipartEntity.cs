#region usings

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

#endregion

namespace Vk.SDK.Http
{
    public class VKMultipartEntity
    {
        private static readonly string VK_BOUNDARY = "Boundary(======VK_SDK_{0}======)";

        private readonly string mBoundary;
        private readonly FileInfo[] mFiles;

        public VKMultipartEntity(FileInfo[] files)
        {
            mBoundary = string.Format(VK_BOUNDARY, new Random().Next());
            mFiles = files;
        }


        public bool isRepeatable()
        {
            return true;
        }


        public long getContentLength()
        {
            long length = 0;
            for (int i = 0; i < mFiles.Count(); i++)
            {
                FileInfo f = mFiles[i];
                length += f.Length;
                length += getFileDescription(f, i).Count();
            }
            length += getBoundaryEnd().Count();

            return length;
        }


        //public Header getContentType()
        //{
        //    return new BasicHeader("Content-PublicType", string.format("multipart/form-data; boundary=%s", mBoundary));
        //}


        public Stream getContent()
        {
            throw new Exception("Multipart form entity does not implement #getContent()");
        }

        private string getFileDescription(FileInfo uploadFile, int i)
        {
            string fileName = string.Format("file{0}", i + 1);
            string extension = uploadFile.Extension;
            return string.Format("\r\n--{0}\r\n", mBoundary) +
                   string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}.{2}\"\r\n", fileName,
                       fileName, extension) +
                   string.Format("Content-PublicType: {0}\r\n\r\n", getMimeType(uploadFile.FullName));
        }

        private string getBoundaryEnd()
        {
            return string.Format("\r\n--{0}--\r\n", mBoundary);
        }


        public void writeTo(Stream outputStream)
        {
            for (int i = 0; i < mFiles.Count(); i++)
            {
                FileInfo uploadFile = mFiles[i];
                var bytes = Encoding.ASCII.GetBytes(getFileDescription(uploadFile, i));
                outputStream.Write(bytes, 0, bytes.Length);
                byte[] fileBuffer = File.ReadAllBytes(uploadFile.FullName);
                outputStream.Write(fileBuffer, 0, fileBuffer.Length);
            }
            var bbytes = Encoding.ASCII.GetBytes(getBoundaryEnd());
            outputStream.Write(bbytes, 0, bbytes.Length);
        }

        public bool isStreaming()
        {
            return true;
        }

        protected static string getMimeType(string url)
        {
            return MimeMapping.GetMimeMapping(url);
        }
    }
}