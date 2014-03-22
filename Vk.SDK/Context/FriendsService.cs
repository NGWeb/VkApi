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

        public VKRequest<UserArray> Get(VKParameters parameters)
        {
            if (parameters["fields"] != null)
            {
                return PrepareRequest<UserArray>("get", parameters, AbstractRequest.HttpMethod.GET);
            }
            return PrepareRequest<UserArray>("get", parameters);
        }

        public VKRequest<UserArray> GetOnline(VKParameters parameters)
        {
            return PrepareRequest<UserArray>("getOnline", parameters);
        }

        public VKRequest<UserArray> GetMutual(VKParameters parameters)
        {
            return PrepareRequest<UserArray>("getMutual", parameters);
        }

        public VKRequest<UserArray> GetRecent(VKParameters parameters)
        {
            return PrepareRequest<UserArray>("getRecent", parameters);
        }

        public VKRequest<UserArray> GetRequests(VKParameters parameters)
        {
            return PrepareRequest<UserArray>("getRequests", parameters);
        }

        public VKRequest<UserArray> Add(VKParameters parameters)
        {
            return PrepareRequest<UserArray>("add", parameters);
        }

        public VKRequest<UserArray> Edit(VKParameters parameters)
        {
            return PrepareRequest<UserArray>("edit", parameters);
        }

        public VKRequest<UserArray> Delete(VKParameters parameters)
        {
            return PrepareRequest<UserArray>("delete", parameters);
        }

        public VKRequest<UserArray> GetLists(VKParameters parameters)
        {
            return PrepareRequest<UserArray>("getLists", parameters);
        }

        public VKRequest<UserArray> AddList(VKParameters parameters)
        {
            return PrepareRequest<UserArray>("addList", parameters);
        }

        public VKRequest<UserArray> EditList(VKParameters parameters)
        {
            return PrepareRequest<UserArray>("editList", parameters);
        }

        public VKRequest<UserArray> DeleteList(VKParameters parameters)
        {
            return PrepareRequest<UserArray>("deleteList", parameters);
        }

        public VKRequest<UserArray> GetAppUsers(VKParameters parameters)
        {
            return PrepareRequest<UserArray>("getAppUsers", parameters);
        }

        public VKRequest<UserArray> GetByPhones(VKParameters parameters)
        {
            return PrepareRequest<UserArray>("getByPhones", parameters, AbstractRequest.HttpMethod.GET);
        }

        public VKRequest<UserArray> DeleteAllRequests(VKParameters parameters)
        {
            return PrepareRequest<UserArray>("deleteAllRequests", parameters);
        }

        public VKRequest<UserArray> GetSuggestions(VKParameters parameters)
        {
            return PrepareRequest<UserArray>("getSuggestions", parameters);
        }

        public VkJsonRequest AreFriends(VKParameters parameters)
        {
            return PrepareJsonRequest("areFriends", parameters);
        }
    }
}