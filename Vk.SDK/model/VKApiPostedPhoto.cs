namespace Vk.SDK.model
{
    public class VKApiPostedPhoto : VKApiPhoto
    {

        /**
     * Fills a PostedPhoto instance from JObject.
     */
        /**
 
          /**
       * Creates empty PostedPhoto instance.
       */
        public VKApiPostedPhoto()
        {

        }


        public string getType()
        {
            return TYPE_POSTED_PHOTO;
        }
    }
}
