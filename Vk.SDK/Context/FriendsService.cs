#region usings

using Vk.SDK.Http;
using Vk.SDK.Model;

#endregion

namespace Vk.SDK.Context
{
    public class FriendsService : VKApiBase, IFriendsService
    {
        public FriendsService(IRequestFactory factory) : base(factory)
        {
        }

        public VKRequest<VKUsersArray> Get(VKParameters parameters)
        {
            if (parameters["fields"] != null)
            {
                return PrepareRequest<VKUsersArray>("get", parameters, AbstractRequest.HttpMethod.GET);
            }
            return PrepareRequest<VKUsersArray>("get", parameters);
        }

        public VKRequest<VKUsersArray> GetOnline(VKParameters parameters)
        {
            return PrepareRequest<VKUsersArray>("getOnline", parameters);
        }

        public VKRequest<VKUsersArray> GetMutual(VKParameters parameters)
        {
            return PrepareRequest<VKUsersArray>("getMutual", parameters);
        }

        public VKRequest<VKUsersArray> GetRecent(VKParameters parameters)
        {
            return PrepareRequest<VKUsersArray>("getRecent", parameters);
        }

        public VKRequest<VKUsersArray> GetRequests(VKParameters parameters)
        {
            return PrepareRequest<VKUsersArray>("getRequests", parameters);
        }

        public VKRequest<VKUsersArray> Add(VKParameters parameters)
        {
            return PrepareRequest<VKUsersArray>("add", parameters);
        }

        public VKRequest<VKUsersArray> Edit(VKParameters parameters)
        {
            return PrepareRequest<VKUsersArray>("edit", parameters);
        }

        public VKRequest<VKUsersArray> Delete(VKParameters parameters)
        {
            return PrepareRequest<VKUsersArray>("delete", parameters);
        }

        public VKRequest<VKUsersArray> GetLists(VKParameters parameters)
        {
            return PrepareRequest<VKUsersArray>("getLists", parameters);
        }

        public VKRequest<VKUsersArray> AddList(VKParameters parameters)
        {
            return PrepareRequest<VKUsersArray>("addList", parameters);
        }

        public VKRequest<VKUsersArray> EditList(VKParameters parameters)
        {
            return PrepareRequest<VKUsersArray>("editList", parameters);
        }

        public VKRequest<VKUsersArray> DeleteList(VKParameters parameters)
        {
            return PrepareRequest<VKUsersArray>("deleteList", parameters);
        }

        public VKRequest<VKUsersArray> GetAppUsers(VKParameters parameters)
        {
            return PrepareRequest<VKUsersArray>("getAppUsers", parameters);
        }

        public VKRequest<VKUsersArray> GetByPhones(VKParameters parameters)
        {
            return PrepareRequest<VKUsersArray>("getByPhones", parameters, AbstractRequest.HttpMethod.GET);
        }

        public VKRequest<VKUsersArray> DeleteAllRequests(VKParameters parameters)
        {
            return PrepareRequest<VKUsersArray>("deleteAllRequests", parameters);
        }

        public VKRequest<VKUsersArray> GetSuggestions(VKParameters parameters)
        {
            return PrepareRequest<VKUsersArray>("getSuggestions", parameters);
        }

        public VkJsonRequest AreFriends(VKParameters parameters)
        {
            return PrepareJsonRequest("areFriends", parameters);
        }
    }
}