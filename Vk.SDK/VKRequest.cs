#region usings

using Vk.SDK.Http;
using Vk.SDK.Model;

#endregion

namespace Vk.SDK
{
    public class VKRequest<T> : AbstractRequest where T : IVKApiModel
    {
        private VKModelOperation<T> mLoadingOperation;

        public VKRequest(string method, IRequestFactory factory)
            : base(method, factory)
        {
        }

        public VKRequest(string method, VKParameters parameters, IRequestFactory factory)
            : base(method, parameters, factory)
        {
        }

        public VKRequest(string method, VKParameters parameters, HttpMethod httpMethod, IRequestFactory factory)
            : base(method, parameters, httpMethod, factory)
        {
        }

        public T GetModel()
        {
            return (T)GetResponse();
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
                OnError(new VKError(VKError.VK_API_CANCELED));
        }
    }
}