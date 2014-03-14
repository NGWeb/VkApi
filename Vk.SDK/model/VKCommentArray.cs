namespace Vk.SDK.model
{
    public class VKCommentArray : VKList<VKApiComment> {
    
        public VKApiModel parse(JSONObject response)  {
            fill(response, VKApiComment.class);
            return this;
        }
    }
}
