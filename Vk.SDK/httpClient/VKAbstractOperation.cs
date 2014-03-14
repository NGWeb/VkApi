
using System.Threading;

namespace Vk.SDK.httpClient
{

    /**
     * Class for executing any kind of asynchronous operation
     */
    public abstract class VKAbstractOperation
    {

        public enum VKOperationState
        {
            Created,
            Ready,
            Executing,
            Paused,
            Finished
        }

        /**
         * Listener called after operation finished
         */
        private VKOperationCompleteListener mCompleteListener;
        /**
         * Current operation state. Checked by stateTransitionIsValid function
         */
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

        /**
         * Finishes current operation. Will call onComplete() function for completeListener
         */
        public void finish()
        {

            if (mCompleteListener != null)
            {
                new Thread(x => mCompleteListener.onComplete()).Start();

            }
        }

        /**
         * Set complete listener for current operation
         *
         * @param listener Complete listener
         */
        protected void setCompleteListener(VKOperationCompleteListener listener)
        {
            mCompleteListener = listener;
        }

        /**
         * Sets operation state. Checks validity of state transition
         *
         * @param state New operation state
         */
        protected void setState(VKOperationState state)
        {
            mState = state;
            if (mState == VKOperationState.Finished)
            {
                finish();
            }
        }


        public interface VKOperationCompleteListener
        {
            void onComplete();
        }

        public abstract class VKAbstractCompleteListener<OperationType, ResponseType>
        {
            public abstract void onComplete(OperationType operation, ResponseType response);
            public abstract void onError(OperationType operation, VKError error);
        }
    }
}