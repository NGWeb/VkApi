namespace Vk.SDK.model
{
    public class VKUsersArray : VKList<VKApiUserFull> {
    
        public VKApiModel parse(JSONObject response)  {
            fill(response, VKApiUserFull.class);
            return this;
        }
    }
}
