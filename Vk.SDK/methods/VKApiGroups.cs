using Vk.SDK.model;

namespace Vk.SDK.methods
{
    public class VKApiGroups : VKApiBase
    {

        public VKRequest isMember(VKParameters parameters)
        {
            return prepareRequest("isMember", parameters);
        }

        public VKRequest getById(VKParameters parameters)
        {
            return prepareRequest("getById", parameters, VKRequest.HttpMethod.GET, typeof(VKApiCommunityArray));
        }

        public VKRequest get(VKParameters parameters)
        {
            if (((int)parameters["extended"]) == 1)
            {
                return prepareRequest("get", parameters, VKRequest.HttpMethod.GET, typeof(VKApiCommunityArray));
            }
            else
            {
                return prepareRequest("get", parameters);
            }
        }

        public VKRequest getMembers(VKParameters parameters)
        {
            return prepareRequest("getMembers", parameters);
        }

        public VKRequest join(VKParameters parameters)
        {
            return prepareRequest("join", parameters);
        }

        public VKRequest leave(VKParameters parameters)
        {
            return prepareRequest("leave", parameters);
        }

        public VKRequest leave(int group_id)
        {
            return prepareRequest("leave", new VKParameters() { { VKApiConst.GROUP_ID, group_id } });
        }

        public VKRequest search(VKParameters parameters)
        {
            return prepareRequest("search", parameters, VKRequest.HttpMethod.GET, typeof(VKApiCommunityArray));
        }

        public VKRequest getInvites(VKParameters parameters)
        {
            return prepareRequest("getInvites", parameters, VKRequest.HttpMethod.GET, typeof(VKApiCommunityArray));
        }

        public VKRequest banUser(VKParameters parameters)
        {
            return prepareRequest("banUser", parameters);
        }

        public VKRequest unbanUser(VKParameters parameters)
        {
            return prepareRequest("unbanUser", parameters);
        }

        public VKRequest getBanned(VKParameters parameters)
        {
            return prepareRequest("getBanned", parameters, VKRequest.HttpMethod.GET, typeof(VKUsersArray));
        }
    }
}
