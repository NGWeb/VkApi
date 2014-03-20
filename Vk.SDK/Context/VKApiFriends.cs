#region usings

using Vk.SDK.Model;

#endregion

namespace Vk.SDK.Context
{
    public class VKApiFriends : VKApiBase
    {
        public VKRequest<VKUsersArray> get(VKParameters parameters)
        {
            if (parameters["fields"] != null)
            {
                return prepareRequest<VKUsersArray>("get", parameters, AbstractRequest.HttpMethod.GET);
            }
            return prepareRequest<VKUsersArray>("get", parameters);
        }

        public VKRequest<VKUsersArray> getOnline(VKParameters parameters)
        {
            return prepareRequest<VKUsersArray>("getOnline", parameters);
        }

        public VKRequest<VKUsersArray> getMutual(VKParameters parameters)
        {
            return prepareRequest<VKUsersArray>("getMutual", parameters);
        }

        public VKRequest<VKUsersArray> getRecent(VKParameters parameters)
        {
            return prepareRequest<VKUsersArray>("getRecent", parameters);
        }

        public VKRequest<VKUsersArray> getRequests(VKParameters parameters)
        {
            return prepareRequest<VKUsersArray>("getRequests", parameters);
        }

        public VKRequest<VKUsersArray> add(VKParameters parameters)
        {
            return prepareRequest<VKUsersArray>("add", parameters);
        }

        public VKRequest<VKUsersArray> edit(VKParameters parameters)
        {
            return prepareRequest<VKUsersArray>("edit", parameters);
        }

        public VKRequest<VKUsersArray> delete(VKParameters parameters)
        {
            return prepareRequest<VKUsersArray>("delete", parameters);
        }

        public VKRequest<VKUsersArray> getLists(VKParameters parameters)
        {
            return prepareRequest<VKUsersArray>("getLists", parameters);
        }

        public VKRequest<VKUsersArray> addList(VKParameters parameters)
        {
            return prepareRequest<VKUsersArray>("addList", parameters);
        }

        public VKRequest<VKUsersArray> editList(VKParameters parameters)
        {
            return prepareRequest<VKUsersArray>("editList", parameters);
        }

        public VKRequest<VKUsersArray> deleteList(VKParameters parameters)
        {
            return prepareRequest<VKUsersArray>("deleteList", parameters);
        }

        public VKRequest<VKUsersArray> getAppUsers(VKParameters parameters)
        {
            return prepareRequest<VKUsersArray>("getAppUsers", parameters);
        }

        public VKRequest<VKUsersArray> getByPhones(VKParameters parameters)
        {
            return prepareRequest<VKUsersArray>("getByPhones", parameters, AbstractRequest.HttpMethod.GET);
        }

        public VKRequest<VKUsersArray> deleteAllRequests(VKParameters parameters)
        {
            return prepareRequest<VKUsersArray>("deleteAllRequests", parameters);
        }

        public VKRequest<VKUsersArray> getSuggestions(VKParameters parameters)
        {
            return prepareRequest<VKUsersArray>("getSuggestions", parameters);
        }

        public VKRequest<VKUsersArray> areFriends(VKParameters parameters)
        {
            return prepareRequest<VKUsersArray>("areFriends", parameters);
        }
    }
}