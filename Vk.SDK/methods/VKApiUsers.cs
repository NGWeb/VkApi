using Vk.SDK.model;

namespace Vk.SDK.methods
{
    public class VKApiUsers : VKApiBase {
        /**
     * Returns basic information about current user
     *
     * @return Request for load
     */
        public VKRequest get() {
            return get(null);
        }

        /**
     * https://vk.com/dev/users.get
     *
     * @param params use parameters from description with VKApiConst class
     * @return Request for load
     */
        public VKRequest<VKApiUser> get(VKParameters parameters)
        {
            return prepareRequest<VKApiUser>("get", parameters, VKRequest.HttpMethod.GET);
        }

        /**
     * https://vk.com/dev/users.search
     *
     * @param params use parameters from description with VKApiConst class
     * @return Request for load
     */
        public VKRequest search(VKParameters parameters) {
            return prepareRequest("search", parameters, VKRequest.HttpMethod.GET, typeof(VKUsersArray));
        }

        /**
     * https://vk.com/dev/users.isAppUser
     *
     * @return Request for load
     */
        public VKRequest isAppUser() {
            return prepareRequest("isAppUser", null);
        }

        /**
     * https://vk.com/dev/users.isAppUser
     *
     * @param userID ID of user to check
     * @return Request for load
     */
        public VKRequest isAppUser(int userID) {
            return prepareRequest("isAppUser",
                new VKParameters() {{VKApiConst.USER_ID, userID}});
        }

        /**
     * https://vk.com/dev/users.getSubscriptions
     *
     * @return Request for load
     */
        public VKRequest getSubscriptions() {
            return getSubscriptions(null);
        }

        /**
     * https://vk.com/dev/users.getSubscriptions
     *
     * @param params use parameters from description with VKApiConst class
     * @return Request for load
     */
        public VKRequest getSubscriptions(VKParameters parameters) {
            return prepareRequest("getSubscriptions", parameters);
        }

        /**
     * https://vk.com/dev/users.getFollowers
     *
     * @return Request for load
     */
        public VKRequest getFollowers() {
            return getFollowers(null);
        }

        /**
     * https://vk.com/dev/users.getFollowers
     *
     * @param params use parameters from description with VKApiConst class
     * @return Request for load
     */
        public VKRequest getFollowers(VKParameters parameters) {
            return prepareRequest("getFollowers", parameters);
        }

        /**
     * https://vk.com/dev/users.report
     * Created on 29.01.14.
     *
     * @param params use parameters from description with VKApiConst class
     * @return Request for load
     */
        public VKRequest report(VKParameters parameters) {
            return prepareRequest("report", parameters);
        }
    }
}
