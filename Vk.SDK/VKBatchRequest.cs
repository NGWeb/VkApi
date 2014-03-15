using Vk.SDK.httpClient;
using Vk.SDK.Vk;

namespace Vk.SDK
{
    public class VKBatchRequest : VKObject
    {
        private readonly VKRequest[] mRequests;
        private readonly VKResponse[] mResponses;
        private bool mCanceled = false;

        /**
     * Specify listener for current request
     */
        public VKBatchRequestListener requestListener;

        public VKBatchRequest(params VKRequest[] requests)
        {
            mRequests = requests;
            mResponses = new VKResponse[mRequests.Length];
        }

        public void executeWithListener(VKBatchRequestListener listener)
        {
            if (mRequests == null)
            {
                provideError(new VKError(VKError.VK_API_REQUEST_NOT_PREPARED));
                return;
            }
            this.requestListener = listener;

            foreach (VKRequest request in mRequests)
            {
             VKRequest.VKRequestListener originalListener = request.requestListener;
                request.setRequestListener(new VKRequest.VKRequestListener()
                {
                    
                public void onComplete(VKResponse response) {
    if (originalListener != null)
    originalListener.onComplete(response);
    provideResponse(response);
                }

                
                public
                void onError 
                (VKError
                error)
                {
                    if (originalListener != null)
                        originalListener.onError(error);
                    provideError(error);
                }

                
                public
                void onProgress 
                (VKRequest.VKProgressType progressType, long bytesLoaded, long bytesTotal)
                {
                    if (originalListener != null)
                        originalListener.onProgress(progressType, bytesLoaded, bytesTotal);
                }
            }
            )
                ;
                VKHttpClient.enqueueOperation(request.getOperation());
            }

        }

        /**
     * Cancel current batch request
     */

        public void cancel()
        {
            if (mCanceled) return;
            mCanceled = true;
            for (VKRequest request :
            mRequests)
            request.cancel();

        }

        protected void provideResponse(VKResponse response)
        {
            mResponses[indexOfRequest(response.request)] = response;
            for (VKResponse resp :
            mResponses)
            if (resp == null) return;

            if (requestListener != null)
                requestListener.onComplete(mResponses);
        }

        private int indexOfRequest(VKRequest request)
        {
            for (int i = 0; i < mRequests.length; i++)
                if (mRequests[i].Equals(request)) return i;
            return -1;
        }

        protected void provideError(VKError error)
        {
            if (mCanceled)
                return;
            if (requestListener != null)
                requestListener.onError(error);
            cancel();
        }

        /**
     * Extend listeners for requests from that class
     */

        public abstract class VKBatchRequestListener
        {
            /**
         * Called if there were no HTTP or API errors, returns execution result.
         *
         * @param responses responses from VKRequests in passing order of construction
         */

            public void onComplete(VKResponse[] responses)
            {
            }

            /**
         * Called immediately if there was API error, or after <b>attempts</b> tries if there was an HTTP error
         *
         * @param error error for VKRequest
         */

            public void onError(VKError error)
            {
            }
        }
    }
}