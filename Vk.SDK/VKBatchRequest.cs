using System;
using Vk.SDK.Vk;

namespace Vk.SDK
{
    public delegate void CompleteDelegate(object sender, VKResponse e);
    public delegate void ErrorDelegate(object sender, VKError e);
    public delegate void ProgressDelegate(object sender, EventArgs e);
    public class VKBatchRequest : VKObject
    {
        private readonly VKRequest[] mRequests;
        private readonly VKResponse[] mResponses;
        private bool mCanceled = false;


        public event CompleteDelegate Complete;
        public event ErrorDelegate Error;
        public event ProgressDelegate Progress;

        /**
     * Specify listener for current request
     */

        public VKBatchRequest(params VKRequest[] requests)
        {
            mRequests = requests;
            mResponses = new VKResponse[mRequests.Length];
        }

        public void executeWithListener()
        {
            if (mRequests == null)
            {
                provideError(new VKError(VKError.VK_API_REQUEST_NOT_PREPARED));
                return;
            }

            foreach (VKRequest request in mRequests)
            {
                //         VKRequest.VKRequestListener originalListener = request.requestListener;
                //            request.setRequestListener(new VKRequest.VKRequestListener()
                //            {

                //            public void onComplete(VKResponse response) {
                //if (originalListener != null)
                //originalListener.onComplete(response);
                //provideResponse(response);
                //            }


                //            public
                //            void onError 
                //            (VKError
                //            error)
                //            {
                //                if (originalListener != null)
                //                    originalListener.onError(error);
                //                provideError(error);
                //            }


                //            public
                //            void onProgress 
                //            (VKRequest.VKProgressType progressType, long bytesLoaded, long bytesTotal)
                //            {
                //                if (originalListener != null)
                //                    originalListener.onProgress(progressType, bytesLoaded, bytesTotal);
                //            }
                //        }
                //        )
                //            ;
                //            VKHttpClient.enqueueOperation(request.getOperation());
            }

        }

        /**
     * Cancel current batch request
     */

        public void cancel()
        {
            if (mCanceled) return;
            mCanceled = true;
            foreach (VKRequest request in mRequests)
                request.Cancel();

        }

        protected void provideResponse(VKResponse response)
        {
            mResponses[indexOfRequest(response.request)] = response;
            foreach (VKResponse resp in mResponses)
                if (resp == null) return;

            if (Complete != null)
                Complete(this, response);
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
            if (Error != null)
                Error(this, error);

            cancel();
        }

        /**
     * Extend listeners for requests from that class
     */
    }
}