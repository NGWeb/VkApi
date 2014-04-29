using System.Collections.Generic;
using Vk.SDK.Model;

namespace Vk.SDK.Interfaces
{
    public interface IGroupsService
    {
        VkJsonRequest IsMember(VKParameters parameters);
        VKRequest<IList<CommunityFull>> GetById(VKParameters parameters);
        VKRequest<CommunityArray> Get(VKParameters parameters);
        VKRequest<UserArray> GetMembers(int groupId, VKParameters parameters = null);
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