#region usings

using System.Linq;
using Vk.SDK.Vk;

#endregion

namespace Vk.SDK
{
    public class VKBatchRequest : VKObject
    {
        private readonly AbstractRequest[] mRequests;
        private readonly VKResponse[] mResponses;
        private bool mCanceled;

        public VKBatchRequest(params AbstractRequest[] requests)
        {
            mRequests = requests;
            mResponses = new VKResponse[mRequests.Length];
        }


        public event CompleteDelegate Complete;
        public event ErrorDelegate Error;
        public event ProgressDelegate Progress;

        /**
     * Specify listener for current request
     */

        public void executeWithListener()
        {
            if (mRequests == null)
            {
                provideError(new VKError(VKError.VK_API_REQUEST_NOT_PREPARED));
                return;
            }

            foreach (AbstractRequest request in mRequests)
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
                //            RequestFactory.enqueueOperation(request.getOperation());
            }
        }

        /**
     * Cancel current batch request
     */

        public void cancel()
        {
            if (mCanceled) return;
            mCanceled = true;
            foreach (AbstractRequest request in mRequests)
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

        private int indexOfRequest(AbstractRequest request)
        {
            for (int i = 0; i < mRequests.Count(); i++)
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