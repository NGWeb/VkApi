
using System.Threading;

namespace Vk.SDK.httpClient
{

    public delegate void CompleteDelegate<T>(object sender, T response) where T : class;

    public delegate void ErrorDelegate(object sender, VKError error);

    /**
     * Class for executing any kind of asynchronous operation
     */
    public abstract class VKAbstractOperation<T> where T : class
    {

        public event CompleteDelegate<T> Complete;
        public event ErrorDelegate Error;

        protected virtual void OnError(VKError error)
        {
            ErrorDelegate handler = Error;
            if (handler != null) handler(this, error);
        }

        protected virtual void OnComplete(T response)
        {
            var handler = Complete;
            if (handler != null) handler(this, response);
        }


        public enum VKOperationState
        {
            Created,
            Ready,
            Executing,
            Paused,
            Finished
        }

        private VKOperationState mState = VKOperationState.Created;
        /**
         * Flag for cancel
         */
        private bool mCanceled = false;


        public VKAbstractOperation()
        {
            setState(VKOperationState.Ready);
        }

        /**
         * Entry point for operation
         */
        public abstract void start();

        /**
         * Cancels current operation and finishes it
         */
        public void cancel()
        {
            mCanceled = true;
            setState(VKOperationState.Finished);
        }


        protected void setState(VKOperationState state)
        {
            mState = state;
            if (mState == VKOperationState.Finished)
            {
                OnComplete(null);
            }
        }
    }
}