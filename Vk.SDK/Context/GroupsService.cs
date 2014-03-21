#region usings

using Vk.SDK.Model;

#endregion

namespace Vk.SDK.Context
{
    public class GroupsService : VKApiBase, IGroupsService
    {
        public VkJsonRequest IsMember(VKParameters parameters)
        {
            return PrepareJsonRequest("isMember", parameters);
        }

        public VKRequest<VKApiCommunityArray> GetById(VKParameters parameters)
        {
            return PrepareRequest<VKApiCommunityArray>("getById", parameters, AbstractRequest.HttpMethod.GET);
        }

        public VKRequest<VKApiCommunityArray> Get(VKParameters parameters)
        {
            if (((int)parameters["extended"]) == 1)
            {
                return PrepareRequest<VKApiCommunityArray>("get", parameters, AbstractRequest.HttpMethod.GET);
            }
            return PrepareRequest<VKApiCommunityArray>("get", parameters);
        }

        public VKRequest<VKUsersArray> GetMembers(VKParameters parameters)
        {
            return PrepareRequest<VKUsersArray>("getMembers", parameters);
        }

        public VkJsonRequest Join(VKParameters parameters)
        {
            return PrepareJsonRequest("join", parameters);
        }

        public VkJsonRequest Leave(VKParameters parameters)
        {
            return PrepareJsonRequest("leave", parameters);
        }

        public VkJsonRequest Leave(int group_id)
        {
            return PrepareJsonRequest("leave", new VKParameters { { VKApiConst.GROUP_ID, group_id } });
        }

        public VKRequest<VKApiCommunityArray> Search(VKParameters parameters)
        {
            return PrepareRequest<VKApiCommunityArray>("search", parameters, AbstractRequest.HttpMethod.GET);
        }

        public VKRequest<VKApiCommunityArray> GetInvites(VKParameters parameters)
        {
            return PrepareRequest<VKApiCommunityArray>("getInvites", parameters, AbstractRequest.HttpMethod.GET);
        }

        public VkJsonRequest BanUser(VKParameters parameters)
        {
            return PrepareJsonRequest("banUser", parameters);
        }

        public VkJsonRequest UnbanUser(VKParameters parameters)
        {
            return PrepareJsonRequest("unbanUser", parameters);
        }

        public VKRequest<VKUsersArray> GetBanned(VKParameters parameters)
        {
            return PrepareRequest<VKUsersArray>("GetBanned", parameters, AbstractRequest.HttpMethod.GET);
        }
    }
}