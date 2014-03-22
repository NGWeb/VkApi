using Vk.SDK.Model;

namespace Vk.SDK.Context
{
    public interface IFriendsService
    {
        VKRequest<VkUsersArray> Get(VKParameters parameters);
        VKRequest<VkUsersArray> GetOnline(VKParameters parameters);
        VKRequest<VkUsersArray> GetMutual(VKParameters parameters);
        VKRequest<VkUsersArray> GetRecent(VKParameters parameters);
        VKRequest<VkUsersArray> GetRequests(VKParameters parameters);
        VKRequest<VkUsersArray> Add(VKParameters parameters);
        VKRequest<VkUsersArray> Edit(VKParameters parameters);
        VKRequest<VkUsersArray> Delete(VKParameters parameters);
        VKRequest<VkUsersArray> GetLists(VKParameters parameters);
        VKRequest<VkUsersArray> AddList(VKParameters parameters);
        VKRequest<VkUsersArray> EditList(VKParameters parameters);
        VKRequest<VkUsersArray> DeleteList(VKParameters parameters);
        VKRequest<VkUsersArray> GetAppUsers(VKParameters parameters);
        VKRequest<VkUsersArray> GetByPhones(VKParameters parameters);
        VKRequest<VkUsersArray> DeleteAllRequests(VKParameters parameters);
        VKRequest<VkUsersArray> GetSuggestions(VKParameters parameters);
        VkJsonRequest AreFriends(VKParameters parameters);
    }
}