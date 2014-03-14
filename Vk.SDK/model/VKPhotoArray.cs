namespace Vk.SDK.model
{
    public class VKPhotoArray : VKList<VKApiPhoto> {
    
        public VKApiModel parse(JSONObject response) {
            fill(response, VKApiPhoto.class);
            return this;
        }
    }
}
