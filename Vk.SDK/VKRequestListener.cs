namespace Vk.SDK
{
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
}