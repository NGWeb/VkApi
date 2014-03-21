using Vk.SDK.Model;

namespace Vk.SDK.Context
{
    public interface IFriendsService
    {
        VKRequest<VKUsersArray> Get(VKParameters parameters);
        VKRequest<VKUsersArray> GetOnline(VKParameters parameters);
        VKRequest<VKUsersArray> GetMutual(VKParameters parameters);
        VKRequest<VKUsersArray> GetRecent(VKParameters parameters);
        VKRequest<VKUsersArray> GetRequests(VKParameters parameters);
        VKRequest<VKUsersArray> Add(VKParameters parameters);
        VKRequest<VKUsersArray> Edit(VKParameters parameters);
        VKRequest<VKUsersArray> Delete(VKParameters parameters);
        VKRequest<VKUsersArray> GetLists(VKParameters parameters);
        VKRequest<VKUsersArray> AddList(VKParameters parameters);
        VKRequest<VKUsersArray> EditList(VKParameters parameters);
        VKRequest<VKUsersArray> DeleteList(VKParameters parameters);
        VKRequest<VKUsersArray> GetAppUsers(VKParameters parameters);
        VKRequest<VKUsersArray> GetByPhones(VKParameters parameters);
        VKRequest<VKUsersArray> DeleteAllRequests(VKParameters parameters);
        VKRequest<VKUsersArray> GetSuggestions(VKParameters parameters);
        VkJsonRequest AreFriends(VKParameters parameters);
    }
}