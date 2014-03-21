#region usings

using Vk.SDK.Model;

#endregion

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

        public VKRequest<VKApiUser> Get(VKParameters parameters)
        {
            return PrepareRequest<VKApiUser>("get", parameters, AbstractRequest.HttpMethod.GET);
        }

        /**
     * https://vk.com/dev/users.search
     *
     * @param params use parameters from description with VKApiConst class
     * @return Request for load
     */

        public VKRequest<VKUsersArray> Search(VKParameters parameters)
        {
            return PrepareRequest<VKUsersArray>("search", parameters, AbstractRequest.HttpMethod.GET);
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

        public VKRequest<VKUsersArray> GetFollowers()
        {
            return GetFollowers(null);
        }

        /**
     * https://vk.com/dev/users.getFollowers
     *
     * @param params use parameters from description with VKApiConst class
     * @return Request for load
     */

        public VKRequest<VKUsersArray> GetFollowers(VKParameters parameters)
        {
            return PrepareRequest<VKUsersArray>("getFollowers", parameters);
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