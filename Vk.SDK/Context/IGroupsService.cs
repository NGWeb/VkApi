using Vk.SDK.Model;

namespace Vk.SDK.Context
{
    public interface IGroupsService
    {
        VkJsonRequest IsMember(VKParameters parameters);
        VKRequest<VKApiCommunityArray> GetById(VKParameters parameters);
        VKRequest<VKApiCommunityArray> Get(VKParameters parameters);
        VKRequest<VKUsersArray> GetMembers(VKParameters parameters);
        VkJsonRequest Join(VKParameters parameters);
        VkJsonRequest Leave(VKParameters parameters);
        VkJsonRequest Leave(int group_id);
        VKRequest<VKApiCommunityArray> Search(VKParameters parameters);
        VKRequest<VKApiCommunityArray> GetInvites(VKParameters parameters);
        VkJsonRequest BanUser(VKParameters parameters);
        VkJsonRequest UnbanUser(VKParameters parameters);
        VKRequest<VKUsersArray> GetBanned(VKParameters parameters);
    }
}