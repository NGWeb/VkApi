using Vk.SDK;
using Vk.SDK.httpClient;
using Vk.SDK.model;

namespace Vk.SDK
{
    public class VKRequest<T> : AbstractRequest where T : VKApiModel
    {
        private VKModelOperation<T> mLoadingOperation;

        public VKRequest(string method)
            : base(method)
        {
        }

        public VKRequest(string method, VKParameters parameters)
            : base(method, parameters)
        {
        }

        public VKRequest(string method, VKParameters parameters, HttpMethod httpMethod)
            : base(method, parameters, httpMethod)
        {

        }

        public override object GetResponse()
        {
            var operation = new VKModelOperation<T>(GetPreparedRequest());
            operation.Start();

            foreach (var request in PostRequestsQueue)
            {
                request.GetResponse();

            }
            return operation.parsedModel;
        }

        //mLoadingOperation.Complete += (operation, response) =>
        //        {
        //        };
        //    }
        //        ((VKJsonOperation) mLoadingOperation).setJsonOperationListener( (operation,response)=> {

        //            if (response.GetValue("error")!=null) {
        //                     VKError error = JsonConvert.DeserializeObject<VKError>(response.GetValue("error").ToString());
        //            return;
        //    }
        //        provideResponse(response,
        //            mLoadingOperation instanceof VKModelOperation ?
        //                ((VKModelOperation) mLoadingOperation).parsedModel :null);
        //    }


        //    public void onError(VKJsonOperation operation, VKError error) {
        //        if (error.errorCode != VKError.VK_API_ERROR &&
        //            operation != null && operation.response != null &&
        //            operation.response.getStatusLine().getStatusCode() == 200) {
        //                provideResponse(operation.getResponseJson(), null);
        //                return;
        //            }
        //        if (attempts == 0 || ++mAttemptsUsed < attempts) {
        //            if (requestListener != null)
        //                requestListener.attemptFailed(VKRequest.this, mAttemptsUsed, attempts);
        //            VKAbstractOperation.postInMainQueueDelayed(new Runnable() {

        //            public void run() {
        //GetResponse();
        //            }
        //        });
        //            return;
        //        }
        //        provideError(error);
        //    }
        //    });
        //        return mLoadingOperation;
        //    }


        public override void Cancel()
        {
            if (mLoadingOperation != null)
                mLoadingOperation.Cancel();
            else
                OnError( new VKError(VKError.VK_API_CANCELED));
        }
    }

}


public abstract class VKRequestListener
{

    /**
    * Called when request has failed attempt, and ready to do next attempt
    *
    * @param request       Failed request
    * @param attemptNumber Number of failed attempt, started from 1
    * @param totalAttempts Total request attempts defined for request
    */
    public void attemptFailed(AbstractRequest request, int attemptNumber, int totalAttempts)
    {
    }

    /**
     * Called immediately if there was API error, or after <b>attempts</b> tries if there was an HTTP error
     *
     * @param error error for VKRequest
     */

    /**
     * Specify progress for uploading or downloading. Useless for text requests (because gzip encoding bytesTotal will always return -1)
     *
     * @param progressType type of progress (upload or download)
     * @param bytesLoaded  total bytes loaded
     * @param bytesTotal   total bytes suppose to be loaded
     */
    public void onProgress(VKProgressType progressType, long bytesLoaded, long bytesTotal)
    {
    }
}