using Vk.SDK.Model;

namespace Vk.SDK.Interfaces
{
    public interface IFriendsService
    {
        VKRequest<UserArray> Get(VKParameters parameters);
        VKRequest<UserArray> GetOnline(VKParameters parameters);
        VKRequest<UserArray> GetMutual(VKParameters parameters);
        VKRequest<UserArray> GetRecent(VKParameters parameters);
        VKRequest<UserArray> GetRequests(VKParameters parameters);
        VkJsonRequest Add(int userid,string greeting=null, VKParameters parameters = null);
        VKRequest<UserArray> Edit(VKParameters parameters);
        VKRequest<UserArray> Delete(VKParameters parameters);
        VKRequest<UserArray> GetLists(VKParameters parameters);
        VKRequest<UserArray> AddList(VKParameters parameters);
        VKRequest<UserArray> EditList(VKParameters parameters);
        VKRequest<UserArray> DeleteList(VKParameters parameters);
        VKRequest<UserArray> GetAppUsers(VKParameters parameters);
        VKRequest<UserArray> GetByPhones(VKParameters parameters);
        VKRequest<UserArray> DeleteAllRequests(VKParameters parameters);
        VKRequest<UserArray> GetSuggestions(VKParameters parameters);
        VkJsonRequest AreFriends(VKParameters parameters);
    }
}