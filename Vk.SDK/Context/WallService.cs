#region usings

using System.Linq;
using Vk.SDK.Http;
using Vk.SDK.Interfaces;
using Vk.SDK.Model;

#endregion

namespace Vk.SDK.Context
{
    public class WallService : VKApiBase, IWallService
    {
        public WallService(IRequestFactory factory)
            : base(factory)
        {
        }

        public VKRequest<PostArray> Get(VKParameters parameters)
        {
            if (parameters.ContainsKey("extended") && ((int)parameters["extended"]) == 1)
            {
                return PrepareRequest<PostArray>("get", parameters, AbstractRequest.HttpMethod.GET);
            }
            return PrepareRequest<PostArray>("get", parameters);
        }

        public VKRequest<PostArray> GetById(int extended, int copyHistoryDepth, params string[] posts)
        {
            var parameters = new VKParameters
            {
                { VKApiConst.EXTENDED, extended }, 
                { VKApiConst.COPY_HISTORY_DEPTH, copyHistoryDepth }, 
                { VKApiConst.POSTS, string.Join(",", posts) }
            };
            
            return extended == 1 ? 
                PrepareRequest<PostArray>("getById", parameters, AbstractRequest.HttpMethod.GET) : 
                PrepareRequest<PostArray>("getById", parameters);
        }

        public VkJsonRequest SavePost(VKParameters parameters)
        {
            return PrepareJsonRequest("savePost", parameters);
        }

        public VkJsonRequest Post(string ownerId, int fromGroup, string message)
        {
            var parameters = new VKParameters
            {
                {VKApiConst.OWNER_ID, ownerId},
                {VKApiConst.FROM_GROUP, fromGroup},
                {VKApiConst.MESSAGE, message}
            };

            return PrepareJsonRequest("post", parameters);
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

        public VKRequest<VkCommentArray> GetComments(VKParameters parameters)
        {
            return PrepareRequest<VkCommentArray>("getComments", parameters, AbstractRequest.HttpMethod.GET);
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