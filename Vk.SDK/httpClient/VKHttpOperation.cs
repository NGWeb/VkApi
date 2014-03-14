using System;
using System.IO;
using System.Net;

namespace Vk.SDK.httpClient
{
    public class VKHttpOperation : VKAbstractOperation {
        /**
     * Request initialized this object
     */
        private readonly WebRequest request;
        /**
     * Last exception throws while loading or parsing
     */
        protected Exception mLastException;
        /**
     * Bytes of HTTP response
     */
        private byte[] mResponseBytes;

        /**
     * Stream for output result of HTTP loading
     */
        public MemoryStream outputStream;
        /**
     * Standard HTTP response
     */
        public WebResponse response;

        /**
     * string representation of response
     */
        private string mResponsestring;

        /**
     * Create new operation for loading prepared Http request. Requests may be prepared in VKHttpClient
     *
     * @param uriRequest Prepared request
     */
        public VKHttpOperation(WebRequest uriRequest) {
            request = uriRequest;
        }


        /**
     * Start current prepared http-operation for result
     */
    
        public void start() {
            setState(VKOperationState.Executing);
            try
            {
                response = request.GetResponse();

                var stream = response.GetResponseStream();
                
                if (outputStream == null) {
                    outputStream = new MemoryStream();
                }

                stream.CopyTo(outputStream);


             
                outputStream.Flush();
                mResponseBytes = outputStream.ToArray();
                outputStream.close();
            } catch (Exception e) {
                mLastException = e;
            }
            finish();
        }

    
        public void finish() {
            postExecution();
            super.finish();
        }

        /**
     * Calls before providing result, but after response loads
     * @return true is post execution succeed
     */
        protected bool postExecution() {
            return true;
        }

        /**
     * Cancel current operation execution
     */
    
        public void cancel() {
            request.abort();
            super.cancel();
        }

        /**
     * Get operation response data
     * @return Bytes of response
     */
        public byte[] getResponseData() {
            return mResponseBytes;
        }

        /**
     * Get operation response string, if possible
     * @return Encoded string from response data bytes
     */
        public string getResponsestring() {
     
           throw new NotImplementedException();
        }

        /**
     * Generates VKError about that request fails
     * @param e Exception for error
     * @return New generated error
     */
        protected VKError generateError(Exception e) {
            VKError error = new VKError(VKError.VK_API_REQUEST_HTTP_FAILED);
            error.errorMessage = e.getMessage();
            if (error.errorMessage == null)
                error.errorMessage = e.tostring();
            error.httpError = e;
            return error;
        }

        /**
     * Set listener for current operation
     * @param listener Listener subclasses VKHTTPOperationCompleteListener
     */
        public void setHttpOperationListener(readonly VKHTTPOperationCompleteListener listener) {
            this.setCompleteListener(new VKOperationCompleteListener() {
            
            public void onComplete() {
    if (mLastException != null) {
    listener.onError(VKHttpOperation.this, generateError(mLastException));
            } else {
                listener.onComplete(VKHttpOperation.this, mResponseBytes);
            }
        }
        });
        }

        /**
     * Class representing operation listener for VKHttpOperation
     */
        public static abstract class VKHTTPOperationCompleteListener : VKAbstractCompleteListener<VKHttpOperation, byte[]>
        {
        
            public void onComplete(VKHttpOperation operation, byte[] response) {
            }

        
            public void onError(VKHttpOperation operation, VKError error) {
            }
        }
    }
}
