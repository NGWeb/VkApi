using Vk.SDK.Model;

namespace Vk.SDK.Context
{
    public interface IWallService
    {
        VKRequest<VKPostArray> Get(VKParameters parameters);
        VKRequest<VKPostArray> GetById(VKParameters parameters);
        VkJsonRequest SavePost(VKParameters parameters);
        VkJsonRequest Post(VKParameters parameters);
        VkJsonRequest Repost(VKParameters parameters);
        VkJsonRequest GetReposts(VKParameters parameters);
        VkJsonRequest Edit(VKParameters parameters);
        VkJsonRequest Delete(VKParameters parameters);
        VkJsonRequest Restore(VKParameters parameters);
        VKRequest<VKCommentArray> GetComments(VKParameters parameters);
        VkJsonRequest AddComment(VKParameters parameters);
        VkJsonRequest EditComment(VKParameters parameters);
        VkJsonRequest DeleteComment(VKParameters parameters);
        VkJsonRequest RestoreComment(VKParameters parameters);
        VkJsonRequest ReportPost(VKParameters parameters);
        VkJsonRequest ReportComment(VKParameters parameters);
    }
}