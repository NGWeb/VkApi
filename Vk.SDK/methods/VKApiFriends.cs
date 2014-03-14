using Vk.SDK.model;

namespace Vk.SDK.methods
{
    public class VKApiFriends : VKApiBase {

        public VKRequest get(VKParameters parameters) {
            if (parameters["fields"] != null) {
                return prepareRequest("get", parameters, VKRequest.HttpMethod.GET, typeof(VKUsersArray));
            } else {
                return prepareRequest("get", parameters);
            }
        }

        public VKRequest getOnline(VKParameters parameters) {
            return prepareRequest("getOnline", parameters);
        }

        public VKRequest getMutual(VKParameters parameters) {
            return prepareRequest("getMutual", parameters);
        }

        public VKRequest getRecent(VKParameters parameters) {
            return prepareRequest("getRecent", parameters);
        }

        public VKRequest getRequests(VKParameters parameters) {
            return prepareRequest("getRequests", parameters);
        }

        public VKRequest add(VKParameters parameters) {
            return prepareRequest("add", parameters);
        }

        public VKRequest edit(VKParameters parameters) {
            return prepareRequest("edit", parameters);
        }

        public VKRequest delete(VKParameters parameters) {
            return prepareRequest("delete", parameters);
        }

        public VKRequest getLists(VKParameters parameters) {
            return prepareRequest("getLists", parameters);
        }

        public VKRequest addList(VKParameters parameters) {
            return prepareRequest("addList", parameters);
        }

        public VKRequest editList(VKParameters parameters) {
            return prepareRequest("editList", parameters);
        }

        public VKRequest deleteList(VKParameters parameters) {
            return prepareRequest("deleteList", parameters);
        }

        public VKRequest getAppUsers(VKParameters parameters) {
            return prepareRequest("getAppUsers", parameters);
        }

        public VKRequest getByPhones(VKParameters parameters) {
            return prepareRequest("getByPhones", parameters, VKRequest.HttpMethod.GET, typeof(VKUsersArray));
        }

        public VKRequest deleteAllRequests(VKParameters parameters) {
            return prepareRequest("deleteAllRequests", parameters);
        }

        public VKRequest getSuggestions(VKParameters parameters) {
            return prepareRequest("getSuggestions", parameters);
        }

        public VKRequest areFriends(VKParameters parameters) {
            return prepareRequest("areFriends", parameters);
        }

    }
}
