using Vk.SDK.Model;

namespace Vk.SDK.Interfaces
{
    public interface IWallService
    {
        VKRequest<PostArray> Get(VKParameters parameters);
        VKRequest<PostArray> GetById(int extended = 1, int copyHistoryDepth = 1, params string[] posts);
        VkJsonRequest SavePost(VKParameters parameters);
        VkJsonRequest Post(string ownerId, int fromGroup, string message);
        VkJsonRequest Repost(VKParameters parameters);
        VkJsonRequest GetReposts(VKParameters parameters);
        VkJsonRequest Edit(VKParameters parameters);
        VkJsonRequest Delete(VKParameters parameters);
        VkJsonRequest Restore(VKParameters parameters);
        VKRequest<VkCommentArray> GetComments(VKParameters parameters);
        VkJsonRequest AddComment(VKParameters parameters);
        VkJsonRequest EditComment(VKParameters parameters);
        VkJsonRequest DeleteComment(VKParameters parameters);
        VkJsonRequest RestoreComment(VKParameters parameters);
        VkJsonRequest ReportPost(VKParameters parameters);
        VkJsonRequest ReportComment(VKParameters parameters);
    }
}