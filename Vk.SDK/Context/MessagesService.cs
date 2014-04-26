using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vk.SDK.Http;
using Vk.SDK.Model;

namespace Vk.SDK.Context
{
    public class MessagesService : VKApiBase, IMessagesService
    {
        public MessagesService(IRequestFactory factory)
            : base(factory)
        {
        }

        public VKRequest<Array<Message>> Get(VKParameters parameters)
        {
            return PrepareRequest<Array<Message>>("get", parameters);
        }

        public VKRequest<Array<Message>> GetDialogs(VKParameters parameters = null)
        {
            if (parameters == null)
                parameters = new VKParameters();

            return PrepareRequest<Array<Message>>("getDialogs", parameters);
        }

        public Array<Message> GetById(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Array<Message> Search(VKParameters parameters)
        {
            throw new NotImplementedException();
        }

        public VKRequest<Array<Message>> GetHistory(int userid, VKParameters parameters = null)
        {
            if (parameters == null)
                parameters = new VKParameters();
            if (parameters.ContainsKey(VKApiConst.USER_ID) == false)
                parameters.Add(VKApiConst.USER_ID, userid);

            return PrepareRequest<Array<Message>>("getHistory", parameters);
        }

        public VkJsonRequest Send(Message message, params int[] id)
        {
            var parameters = new VKParameters();

            if (id.Length == 1)
            {
                parameters.Add(VKApiConst.USER_ID, id[0]);
            }
            else
            {
                parameters.Add(VKApiConst.USER_IDS, string.Join(",", id));
            }

            parameters.Add(VKApiConst.MESSAGE, message.body);
            return PrepareJsonRequest("send", parameters, AbstractRequest.HttpMethod.GET);
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
