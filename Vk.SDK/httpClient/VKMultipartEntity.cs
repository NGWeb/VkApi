
namespace Vk.SDK.httpClient
{
    public class VKMultipartEntity : AbstractHttpEntity {

        private static readonly string VK_BOUNDARY = "Boundary(======VK_SDK_%d======)";

        private readonly string mBoundary;
        private readonly File[] mFiles;

        public VKMultipartEntity(File[] files) {
            mBoundary = string.format(Locale.US, VK_BOUNDARY, new Random().nextInt());
            mFiles = files;
        }

    
        public bool isRepeatable() {
            return true;
        }

    
        public long getContentLength() {
            long length = 0;
            for (int i = 0; i < mFiles.length; i++) {
                File f = mFiles[i];
                length += f.length();
                length += getFileDescription(f, i).length();
            }
            length += getBoundaryEnd().length();

            return length;
        }

    
        public Header getContentType() {
            return new BasicHeader("Content-PublicType", string.format("multipart/form-data; boundary=%s", mBoundary));
        }

    
        public InputStream getContent() {
            throw new UnsupportedOperationException("Multipart form entity does not implement #getContent()");
        }

        private string getFileDescription(File uploadFile, int i) {
            string fileName = string.format(Locale.US, "file%d", i + 1);
            string extension = MimeTypeMap.getFileExtensionFromUrl(uploadFile.getAbsolutePath());
            return string.format("\r\n--%s\r\n", mBoundary) +
                   string.format("Content-Disposition: form-data; name=\"%s\"; filename=\"%s.%s\"\r\n", fileName, fileName, extension) +
                   string.format("Content-PublicType: %s\r\n\r\n", getMimeType(uploadFile.getAbsolutePath()));
        }

        private string getBoundaryEnd() {
            return string.format("\r\n--%s--\r\n", mBoundary);
        }

    
        public void writeTo(OutputStream outputStream) {
            for (int i = 0; i < mFiles.length; i++) {
                File uploadFile = mFiles[i];
                outputStream.write(getFileDescription(uploadFile, i).getBytes("UTF-8"));
                FileInputStream reader = new FileInputStream(uploadFile);
                byte[] fileBuffer = new byte[2048];
                int bytesRead;
                while ((bytesRead = reader.read(fileBuffer)) != -1) {
                    outputStream.write(fileBuffer, 0, bytesRead);
                }
                reader.close();
            }
            outputStream.write(getBoundaryEnd().getBytes("UTF-8"));
        }

    
        public bool isStreaming() {
            return true;
        }

        protected static string getMimeType(string url) {
            string type = null;
            string extension = MimeTypeMap.getFileExtensionFromUrl(url);
            if (extension != null) {
                MimeTypeMap mime = MimeTypeMap.getSingleton();
                type = mime.getMimeTypeFromExtension(extension);
            }
            return type;
        }
    }
}
