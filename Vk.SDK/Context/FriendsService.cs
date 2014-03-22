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

        public VKRequest<VkUsersArray> Get(VKParameters parameters)
        {
            if (parameters["fields"] != null)
            {
                return PrepareRequest<VkUsersArray>("get", parameters, AbstractRequest.HttpMethod.GET);
            }
            return PrepareRequest<VkUsersArray>("get", parameters);
        }

        public VKRequest<VkUsersArray> GetOnline(VKParameters parameters)
        {
            return PrepareRequest<VkUsersArray>("getOnline", parameters);
        }

        public VKRequest<VkUsersArray> GetMutual(VKParameters parameters)
        {
            return PrepareRequest<VkUsersArray>("getMutual", parameters);
        }

        public VKRequest<VkUsersArray> GetRecent(VKParameters parameters)
        {
            return PrepareRequest<VkUsersArray>("getRecent", parameters);
        }

        public VKRequest<VkUsersArray> GetRequests(VKParameters parameters)
        {
            return PrepareRequest<VkUsersArray>("getRequests", parameters);
        }

        public VKRequest<VkUsersArray> Add(VKParameters parameters)
        {
            return PrepareRequest<VkUsersArray>("add", parameters);
        }

        public VKRequest<VkUsersArray> Edit(VKParameters parameters)
        {
            return PrepareRequest<VkUsersArray>("edit", parameters);
        }

        public VKRequest<VkUsersArray> Delete(VKParameters parameters)
        {
            return PrepareRequest<VkUsersArray>("delete", parameters);
        }

        public VKRequest<VkUsersArray> GetLists(VKParameters parameters)
        {
            return PrepareRequest<VkUsersArray>("getLists", parameters);
        }

        public VKRequest<VkUsersArray> AddList(VKParameters parameters)
        {
            return PrepareRequest<VkUsersArray>("addList", parameters);
        }

        public VKRequest<VkUsersArray> EditList(VKParameters parameters)
        {
            return PrepareRequest<VkUsersArray>("editList", parameters);
        }

        public VKRequest<VkUsersArray> DeleteList(VKParameters parameters)
        {
            return PrepareRequest<VkUsersArray>("deleteList", parameters);
        }

        public VKRequest<VkUsersArray> GetAppUsers(VKParameters parameters)
        {
            return PrepareRequest<VkUsersArray>("getAppUsers", parameters);
        }

        public VKRequest<VkUsersArray> GetByPhones(VKParameters parameters)
        {
            return PrepareRequest<VkUsersArray>("getByPhones", parameters, AbstractRequest.HttpMethod.GET);
        }

        public VKRequest<VkUsersArray> DeleteAllRequests(VKParameters parameters)
        {
            return PrepareRequest<VkUsersArray>("deleteAllRequests", parameters);
        }

        public VKRequest<VkUsersArray> GetSuggestions(VKParameters parameters)
        {
            return PrepareRequest<VkUsersArray>("getSuggestions", parameters);
        }

        public VkJsonRequest AreFriends(VKParameters parameters)
        {
            return PrepareJsonRequest("areFriends", parameters);
        }
    }
}