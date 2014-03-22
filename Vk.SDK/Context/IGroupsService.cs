using Vk.SDK.Model;

namespace Vk.SDK.Context
{
    public interface IGroupsService
    {
        VkJsonRequest IsMember(VKParameters parameters);
        VKRequest<CommunityArray> GetById(VKParameters parameters);
        VKRequest<CommunityArray> Get(VKParameters parameters);
        VKRequest<UserArray> GetMembers(VKParameters parameters);
        VkJsonRequest Join(VKParameters parameters);
        VkJsonRequest Leave(VKParameters parameters);
        VkJsonRequest Leave(int group_id);
        VKRequest<CommunityArray> Search(VKParameters parameters);
        VKRequest<CommunityArray> GetInvites(VKParameters parameters);
        VkJsonRequest BanUser(VKParameters parameters);
        VkJsonRequest UnbanUser(VKParameters parameters);
        VKRequest<UserArray> GetBanned(VKParameters parameters);
    }
}