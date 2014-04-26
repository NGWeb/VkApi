using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.SDK.Http;
using Vk.SDK.Model;

namespace Vk.SDK.Context
{
    public class MessagesService:VKApiBase,IMessagesService
    {
        public MessagesService(IRequestFactory factory) : base(factory)
        {
        }

        public VKRequest<Array<Message>> Get(VKParameters parameters)
        {
            return PrepareRequest<Array<Message>>("get", parameters);
        }

        public Array<Chat> GetDialogs(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Array<Message> GetById(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Array<Message> Search(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Array<Message> GetHistory(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public VkJsonRequest Send(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public VkJsonRequest Delete(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public VkJsonRequest DeleteDialog(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public VkJsonRequest Restore(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public VkJsonRequest MarkAsRead(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public VkJsonRequest MarkAsImportant(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public VkJsonRequest GetLongPollServer(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public VkJsonRequest GetLongPollHistory(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public VkJsonRequest GetChat(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public VkJsonRequest CreateChat(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public VkJsonRequest EditChat(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public VkJsonRequest GetChatUsers(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public VkJsonRequest SetActivity(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public VkJsonRequest SearchDialogs(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public VkJsonRequest AddChatUser(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public VkJsonRequest RemoveChatUser(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public VkJsonRequest GetLastActivity(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public VkJsonRequest SetChatPhoto(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public VkJsonRequest DeleteChatPhoto(VKParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
