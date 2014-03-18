using Newtonsoft.Json.Linq;
using Vk.SDK.httpClient;
using Vk.SDK.Vk;

namespace Vk.SDK.photo
{
    public abstract class VKUploadPhotoBase : VKRequest {
        /**
     * ID of album to upload
     */
        protected long mAlbumId;
        /**
     * ID of group to upload
     */
        protected long mGroupId;
        /**
     * ID of user wall to upload
     */
        protected long mUserId;
        /**
     * Image to upload
     */
        protected byte[] mImage;

        protected abstract VKRequest getServerRequest();

        protected abstract VKRequest getSaveRequest(JObject response);

        public VKUploadPhotoBase() {}

    
        public VKAbstractOperation getOperation() {
            return new VKUploadImageOperation();
        }

        protected class VKUploadImageOperation : VKAbstractOperation<VKResponse> {
        

        
            public void start() {
            VKRequestListener originalListener = VKUploadPhotoBase.this.requestListener;

                VKUploadPhotoBase.this.requestListener = new VKRequestListener() {
                
                public void onComplete(VKResponse response) {
    setState(VKOperationState.Finished);
    response.request = VKUploadPhotoBase.this;
    if (originalListener != null)
    originalListener.onComplete(response);
                }

                
                public void onError(VKError error) {
                    setState(VKOperationState.Finished);
                    error.request = VKUploadPhotoBase.this;
                    if (originalListener != null)
                        originalListener.onError(error);
                }

                
            public void onProgress(VKProgressType progressType, long bytesLoaded,
                long bytesTotal) {
                    if (originalListener != null)
                        originalListener.onProgress(progressType, bytesLoaded, bytesTotal);
                }
            };
                setState(VKOperationState.Executing);

                VKRequest serverRequest = getServerRequest();

                serverRequest.setRequestListener(new VKRequestListener() {
                
                public void onComplete(VKResponse response) {
    try {
    VKJsonOperation postFileRequest = new VKJsonOperation(
    VKHttpClient.fileUploadRequest(response.json.getJObject("response").getstring("upload_url"), mImage));
    postFileRequest.setJsonOperationListener(new VKJSONOperationCompleteListener() {
                            
    public void onComplete(VKJsonOperation operation,
                    JObject response) {

    VKRequest saveRequest = getSaveRequest(response);
    saveRequest.setRequestListener(new VKRequestListener() {
                                    
    public void onComplete(VKResponse response) {
    requestListener.onComplete(response);
    setState(VKOperationState.Finished);
                }

                                    
                public void onError(VKError error) {
                    requestListener.onError(error);
                }
            });
                lastOperation = saveRequest.getOperation();
                VKHttpClient.enqueueOperation(lastOperation);
            }

                            
            public void onError(VKJsonOperation operation, VKError error) {
                requestListener.onError(error);
            }
            });

                lastOperation = postFileRequest;
                VKHttpClient.enqueueOperation(lastOperation);
            } catch (JSONException e) {
                if (VKSdk.DEBUG)
                    e.printStackTrace();
                VKError error = new VKError(VKError.VK_API_JSON_FAILED);
                error.httpError = e;
                error.errorMessage = e.getMessage();
                requestListener.onError(error);
            }
//					postFileRequest.progressBlock = _uploadRequest.progressBlock;
            }

                
            public void onError(VKError error) {
                if (requestListener != null)
                    requestListener.onError(error);
            }
            });
                lastOperation = serverRequest.getOperation();
                VKHttpClient.enqueueOperation(lastOperation);
            }

        
            public void cancel() {
                if (lastOperation != null)
                    lastOperation.cancel();
                super.cancel();
            }

        
            public void finish() {
                super.finish();
                lastOperation = null;
            }
        }


    }
}
