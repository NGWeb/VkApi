using Vk.SDK.Model;

namespace Vk.SDK.Interfaces
{
    public interface IMessagesService
    {
        VKRequest<Array<Message>> Get(VKParameters parameters);
        VKRequest<Array<Message>> GetDialogs(VKParameters parameters);
        Array<Message> GetById(VKParameters parameters);
        Array<Message> Search(VKParameters parameters);
        VKRequest<Array<Message>> GetHistory(int userid, VKParameters parameters=null);
        VkJsonRequest Send(Message message, params int[] id);
        VkJsonRequest Delete(VKParameters parameters);
        VkJsonRequest DeleteDialog(VKParameters parameters);
        VkJsonRequest Restore(VKParameters parameters);
        VkJsonRequest MarkAsRead(VKParameters parameters);
        VkJsonRequest MarkAsImportant(VKParameters parameters);
        VkJsonRequest GetLongPollServer(VKParameters parameters);
        VkJsonRequest GetLongPollHistory(VKParameters parameters);
        VkJsonRequest GetChat(VKParameters parameters);
        VkJsonRequest CreateChat(VKParameters parameters);
        VkJsonRequest EditChat(VKParameters parameters);
        VkJsonRequest GetChatUsers(VKParameters parameters);
        VkJsonRequest SetActivity(VKParameters parameters);
        VkJsonRequest SearchDialogs(VKParameters parameters);
        VkJsonRequest AddChatUser(VKParameters parameters);
        VkJsonRequest RemoveChatUser(VKParameters parameters);
        VkJsonRequest GetLastActivity(VKParameters parameters);
        VkJsonRequest SetChatPhoto(VKParameters parameters);
        VkJsonRequest DeleteChatPhoto(VKParameters parameters);
    }
}
