#region usings

using Vk.SDK.Model;

#endregion

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

    public class WallService : VKApiBase, IWallService
    {
        public VKRequest<VKPostArray> Get(VKParameters parameters)
        {
            if (((int) parameters["extended"]) == 1)
            {
                return PrepareRequest<VKPostArray>("get", parameters, AbstractRequest.HttpMethod.GET);
            }
            return PrepareRequest<VKPostArray>("get", parameters);
        }

        public VKRequest<VKPostArray> GetById(VKParameters parameters)
        {
            if (((int) parameters["extended"]) == 1)
            {
                return PrepareRequest<VKPostArray>("get", parameters, AbstractRequest.HttpMethod.GET);
            }
            return PrepareRequest<VKPostArray>("get", parameters);
        }

        public VkJsonRequest SavePost(VKParameters parameters)
        {
            return PrepareJsonRequest("savePost", parameters);
        }


        public VkJsonRequest Post(VKParameters parameters)
        {
            return PrepareJsonRequest("post", parameters, AbstractRequest.HttpMethod.POST);
        }

        public VkJsonRequest Repost(VKParameters parameters)
        {
            return PrepareJsonRequest("repost", parameters);
        }

        public VkJsonRequest GetReposts(VKParameters parameters)
        {
            return PrepareJsonRequest("getReposts", parameters);
        }

        public VkJsonRequest Edit(VKParameters parameters)
        {
            return PrepareJsonRequest("edit", parameters);
        }

        public VkJsonRequest Delete(VKParameters parameters)
        {
            return PrepareJsonRequest("delete", parameters);
        }

        public VkJsonRequest Restore(VKParameters parameters)
        {
            return PrepareJsonRequest("restore", parameters);
        }

        public VKRequest<VKCommentArray> GetComments(VKParameters parameters)
        {
            return PrepareRequest<VKCommentArray>("getComments", parameters, AbstractRequest.HttpMethod.GET);
        }

        public VkJsonRequest AddComment(VKParameters parameters)
        {
            return PrepareJsonRequest("addComment", parameters);
        }

        public VkJsonRequest EditComment(VKParameters parameters)
        {
            return PrepareJsonRequest("editComment", parameters);
        }

        public VkJsonRequest DeleteComment(VKParameters parameters)
        {
            return PrepareJsonRequest("deleteComment", parameters);
        }

        public VkJsonRequest RestoreComment(VKParameters parameters)
        {
            return PrepareJsonRequest("restoreComment", parameters);
        }

        public VkJsonRequest ReportPost(VKParameters parameters)
        {
            return PrepareJsonRequest("reportPost", parameters);
        }

        public VkJsonRequest ReportComment(VKParameters parameters)
        {
            return PrepareJsonRequest("reportComment", parameters);
        }
    }
}