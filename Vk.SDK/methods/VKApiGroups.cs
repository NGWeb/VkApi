using Vk.SDK.model;

namespace Vk.SDK.methods
{
    public class VKApiGroups : VKApiBase
    {

        public VkJsonRequest isMember(VKParameters parameters)
        {
            return PrepareJsonRequest("isMember", parameters);
        }

        public VKRequest<VKApiCommunityArray> getById(VKParameters parameters)
        {
            return prepareRequest<VKApiCommunityArray>("getById", parameters, AbstractRequest.HttpMethod.GET);
        }

        public VKRequest<VKApiCommunityArray> get(VKParameters parameters)
        {
            if (((int)parameters["extended"]) == 1)
            {
                return prepareRequest<VKApiCommunityArray>("get", parameters, AbstractRequest.HttpMethod.GET);
            }
            else
            {
                return prepareRequest<VKApiCommunityArray>("get", parameters);
            }
        }

        public VKRequest<VKUsersArray> getMembers(VKParameters parameters)
        {
            return prepareRequest<VKUsersArray>("getMembers", parameters);
        }

        public VkJsonRequest join(VKParameters parameters)
        {
            return PrepareJsonRequest("join", parameters);
        }

        public VkJsonRequest leave(VKParameters parameters)
        {
            return PrepareJsonRequest("leave", parameters);
        }

        public VkJsonRequest leave(int group_id)
        {
            return PrepareJsonRequest("leave", new VKParameters() { { VKApiConst.GROUP_ID, group_id } });
        }

        public VKRequest<VKApiCommunityArray> search(VKParameters parameters)
        {
            return prepareRequest<VKApiCommunityArray>("search", parameters, AbstractRequest.HttpMethod.GET);
        }

        public VKRequest<VKApiCommunityArray> getInvites(VKParameters parameters)
        {
            return prepareRequest<VKApiCommunityArray>("getInvites", parameters, AbstractRequest.HttpMethod.GET);
        }

        public VkJsonRequest banUser(VKParameters parameters)
        {
            return PrepareJsonRequest("banUser", parameters);
        }

        public VkJsonRequest unbanUser(VKParameters parameters)
        {
            return PrepareJsonRequest("unbanUser", parameters);
        }

        public VKRequest<VKUsersArray> getBanned(VKParameters parameters)
        {
            return prepareRequest<VKUsersArray>("getBanned", parameters, AbstractRequest.HttpMethod.GET);
        }
    }
}
