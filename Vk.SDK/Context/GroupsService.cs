#region usings

using System.Collections.Generic;
using System.Linq;
using Vk.SDK.Http;
using Vk.SDK.Interfaces;
using Vk.SDK.Model;

#endregion

namespace Vk.SDK.Context
{
    public class GroupsService : VKApiBase, IGroupsService
    {
        public GroupsService(IRequestFactory factory)
            : base(factory)
        {
        }

        public VkJsonRequest IsMember(VKParameters parameters)
        {
            return PrepareJsonRequest("isMember", parameters);
        }

        public VKRequest<IList<CommunityFull>> GetById(VKParameters parameters)
        {
            return PrepareRequest<IList<CommunityFull>>("getById", parameters, AbstractRequest.HttpMethod.GET);
        }

        public VKRequest<CommunityArray> Get(VKParameters parameters)
        {
            if ((parameters.ContainsKey("extended") && ((int)parameters["extended"]) == 1))
            {
                return PrepareRequest<CommunityArray>("get", parameters, AbstractRequest.HttpMethod.GET);
            }
            return PrepareRequest<CommunityArray>("get", parameters);
        }

        public VKRequest<UserArray> GetMembers(int groupId, VKParameters parameters = null)
        {
            if (parameters == null)
                parameters = new VKParameters();

            if (!parameters.Keys.Contains(VKApiConst.GROUP_ID))
                parameters.Add(VKApiConst.GROUP_ID, groupId);

            if (!parameters.ContainsKey(VKApiConst.VERSION))
                parameters.Add(VKApiConst.VERSION, "5.9");

            return PrepareRequest<UserArray>("getMembers", parameters);
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

        public VKRequest<CommunityArray> Search(VKParameters parameters)
        {
            return PrepareRequest<CommunityArray>("search", parameters, AbstractRequest.HttpMethod.GET);
        }

        public VKRequest<CommunityArray> GetInvites(VKParameters parameters)
        {
            return PrepareRequest<CommunityArray>("getInvites", parameters, AbstractRequest.HttpMethod.GET);
        }

        public VkJsonRequest BanUser(VKParameters parameters)
        {
            return PrepareJsonRequest("banUser", parameters);
        }

        public VkJsonRequest UnbanUser(VKParameters parameters)
        {
            return PrepareJsonRequest("unbanUser", parameters);
        }

        public VKRequest<UserArray> GetBanned(VKParameters parameters)
        {
            return PrepareRequest<UserArray>("GetBanned", parameters, AbstractRequest.HttpMethod.GET);
        }
    }
}