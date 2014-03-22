using System.Collections.Generic;
using Vk.SDK.Model;

namespace Vk.SDK.Context
{
    public interface IUsersService
    {
        VKRequest<VkModelsList<IvkApiUser>> Get(VKParameters parameters);
        VKRequest<VkUsersArray> Search(VKParameters parameters);
        VkJsonRequest IsAppUser();
        VkJsonRequest IsAppUser(int userID);
        VkJsonRequest GetSubscriptions();
        VkJsonRequest GetSubscriptions(VKParameters parameters);
        VKRequest<VkUsersArray> GetFollowers();
        VKRequest<VkUsersArray> GetFollowers(VKParameters parameters);
        VkJsonRequest Report(VKParameters parameters);
    }
}