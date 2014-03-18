
using System.Threading;

namespace Vk.SDK.httpClient
{

    public delegate void ErrorDelegate(object sender, VKError error);

    /**
     * Class for executing any kind of asynchronous operation
     */
    public abstract class VKAbstractOperation
    {

        public event ErrorDelegate Error;

        protected virtual void OnError(VKError error)
        {
            ErrorDelegate handler = Error;
            if (handler != null) handler(this, error);
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

        protected VKAbstractOperation()
        {
            SetState(VKOperationState.Ready);
        }

        /**
         * Entry point for operation
         */
        public abstract void Start();

        /**
         * Cancels current operation and finishes it
         */
        public virtual void Cancel()
        {
            SetState(VKOperationState.Finished);
        }


        protected void SetState(VKOperationState state)
        {
            mState = state;
        }
    }
}