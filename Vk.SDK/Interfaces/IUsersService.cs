using Vk.SDK.Model;

namespace Vk.SDK.Interfaces
{
    public interface IUsersService
    {
        VKRequest<VkModelsList<UserFull>> Get(VKParameters parameters);
        VKRequest<UserArray> Search(VKParameters parameters);
        VkJsonRequest IsAppUser();
        VkJsonRequest IsAppUser(int userID);
        VkJsonRequest GetSubscriptions();
        VkJsonRequest GetSubscriptions(VKParameters parameters);
        VKRequest<UserArray> GetFollowers();
        VKRequest<UserArray> GetFollowers(VKParameters parameters);
        VkJsonRequest Report(VKParameters parameters);
    }
}