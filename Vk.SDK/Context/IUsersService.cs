using Vk.SDK.Model;

namespace Vk.SDK.Context
{
    public interface IUsersService
    {
        VKRequest<VKApiUser> Get(VKParameters parameters);
        VKRequest<VKUsersArray> Search(VKParameters parameters);
        VkJsonRequest IsAppUser();
        VkJsonRequest IsAppUser(int userID);
        VkJsonRequest GetSubscriptions();
        VkJsonRequest GetSubscriptions(VKParameters parameters);
        VKRequest<VKUsersArray> GetFollowers();
        VKRequest<VKUsersArray> GetFollowers(VKParameters parameters);
        VkJsonRequest Report(VKParameters parameters);
    }
}