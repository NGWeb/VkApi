#region usings

using System.Collections.Generic;
using Vk.SDK.Http;
using Vk.SDK.Model;

#endregion

namespace Vk.SDK.Context
{
    public class UsersService : VKApiBase, IUsersService
    {
        /**
     * Returns basic information about current user
     *
     * @return Request for load
     */

        /**
     * https://vk.com/dev/users.get
     *
     * @param params use parameters from description with VKApiConst class
     * @return Request for load
     */

        public UsersService(IRequestFactory factory) : base(factory)
        {
        }

        public VKRequest<VkModelsList<User>> Get(VKParameters parameters)
        {
            return PrepareRequest<VkModelsList<User>>("get", parameters, AbstractRequest.HttpMethod.GET);
        }

        /**
     * https://vk.com/dev/users.search
     *
     * @param params use parameters from description with VKApiConst class
     * @return Request for load
     */

        public VKRequest<UserArray> Search(VKParameters parameters)
        {
            return PrepareRequest<UserArray>("search", parameters, AbstractRequest.HttpMethod.GET);
        }

        /**
     * https://vk.com/dev/users.isAppUser
     *
     * @return Request for load
     */

        public VkJsonRequest IsAppUser()
        {
            return PrepareJsonRequest("isAppUser", null);
        }

        /**
     * https://vk.com/dev/users.isAppUser
     *
     * @param userID ID of user to check
     * @return Request for load
     */

        public VkJsonRequest IsAppUser(int userID)
        {
            return PrepareJsonRequest("isAppUser", new VKParameters {{VKApiConst.USER_ID, userID}});
        }

        /**
     * https://vk.com/dev/users.getSubscriptions
     *
     * @return Request for load
     */

        public VkJsonRequest GetSubscriptions()
        {
            return GetSubscriptions(null);
        }

        /**
     * https://vk.com/dev/users.getSubscriptions
     *
     * @param params use parameters from description with VKApiConst class
     * @return Request for load
     */

        public VkJsonRequest GetSubscriptions(VKParameters parameters)
        {
            return PrepareJsonRequest("getSubscriptions", parameters);
        }

        /**
     * https://vk.com/dev/users.getFollowers
     *
     * @return Request for load
     */

        public VKRequest<UserArray> GetFollowers()
        {
            return GetFollowers(null);
        }

        /**
     * https://vk.com/dev/users.getFollowers
     *
     * @param params use parameters from description with VKApiConst class
     * @return Request for load
     */

        public VKRequest<UserArray> GetFollowers(VKParameters parameters)
        {
            return PrepareRequest<UserArray>("getFollowers", parameters);
        }

        /**
     * https://vk.com/dev/users.report
     * Created on 29.01.14.
     *
     * @param params use parameters from description with VKApiConst class
     * @return Request for load
     */

        public VkJsonRequest Report(VKParameters parameters)
        {
            return PrepareJsonRequest("report", parameters);
        }
    }
}