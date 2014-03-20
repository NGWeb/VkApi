namespace Vk.SDK.Http
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

        private VKOperationState mState = VKOperationState.Created;
        /**
         * Flag for cancel
         */

        protected VKAbstractOperation()
        {
            SetState(VKOperationState.Ready);
        }

        public event ErrorDelegate Error;

        protected virtual void OnError(VKError error)
        {
            ErrorDelegate handler = Error;
            if (handler != null) handler(this, error);
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