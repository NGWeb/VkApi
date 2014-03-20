#region usings

using Vk.SDK.Model;

#endregion

namespace Vk.SDK.Context
{
    public class VKApiUsers : VKApiBase
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

        public VKRequest<VKApiUser> get(VKParameters parameters)
        {
            return prepareRequest<VKApiUser>("get", parameters, AbstractRequest.HttpMethod.GET);
        }

        /**
     * https://vk.com/dev/users.search
     *
     * @param params use parameters from description with VKApiConst class
     * @return Request for load
     */

        public VKRequest<VKUsersArray> search(VKParameters parameters)
        {
            return prepareRequest<VKUsersArray>("search", parameters, AbstractRequest.HttpMethod.GET);
        }

        /**
     * https://vk.com/dev/users.isAppUser
     *
     * @return Request for load
     */

        public VkJsonRequest isAppUser()
        {
            return PrepareJsonRequest("isAppUser", null);
        }

        /**
     * https://vk.com/dev/users.isAppUser
     *
     * @param userID ID of user to check
     * @return Request for load
     */

        public VkJsonRequest isAppUser(int userID)
        {
            return PrepareJsonRequest("isAppUser", new VKParameters {{VKApiConst.USER_ID, userID}});
        }

        /**
     * https://vk.com/dev/users.getSubscriptions
     *
     * @return Request for load
     */

        public VkJsonRequest getSubscriptions()
        {
            return getSubscriptions(null);
        }

        /**
     * https://vk.com/dev/users.getSubscriptions
     *
     * @param params use parameters from description with VKApiConst class
     * @return Request for load
     */

        public VkJsonRequest getSubscriptions(VKParameters parameters)
        {
            return PrepareJsonRequest("getSubscriptions", parameters);
        }

        /**
     * https://vk.com/dev/users.getFollowers
     *
     * @return Request for load
     */

        public VKRequest<VKUsersArray> getFollowers()
        {
            return getFollowers(null);
        }

        /**
     * https://vk.com/dev/users.getFollowers
     *
     * @param params use parameters from description with VKApiConst class
     * @return Request for load
     */

        public VKRequest<VKUsersArray> getFollowers(VKParameters parameters)
        {
            return prepareRequest<VKUsersArray>("getFollowers", parameters);
        }

        /**
     * https://vk.com/dev/users.report
     * Created on 29.01.14.
     *
     * @param params use parameters from description with VKApiConst class
     * @return Request for load
     */

        public VkJsonRequest report(VKParameters parameters)
        {
            return PrepareJsonRequest("report", parameters);
        }
    }
}