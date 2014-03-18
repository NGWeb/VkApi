using Vk.SDK;
using Vk.SDK.methods;
using Vk.SDK.model;

public class VKApiWall : VKApiBase {

    public VKRequest<VKPostArray> get(VKParameters parameters) {
        if (((int) parameters["extended"]) == 1) {
            return prepareRequest<VKPostArray>("get", parameters, VKRequest.HttpMethod.GET);
        } else {
            return prepareRequest<VKPostArray>("get", parameters);
        }
    }

    public VKRequest<VKPostArray> getById(VKParameters parameters) {
        if (((int) parameters["extended"]) == 1) {
            return prepareRequest<VKPostArray>("get", parameters, VKRequest.HttpMethod.GET);
        } else {
            return prepareRequest("get", parameters);
        }
    }

    public VKRequest savePost(VKParameters parameters) {
        return prepareRequest("savePost", parameters);
    }


    public VKRequest post(VKParameters parameters) {
        return prepareRequest("post", parameters, VKRequest.HttpMethod.POST);
    }

    public VKRequest repost(VKParameters parameters) {
        return prepareRequest("repost", parameters);
    }

    public VKRequest getReposts(VKParameters parameters) {
        return prepareRequest("getReposts", parameters);
    }

    public VKRequest edit(VKParameters parameters) {
        return prepareRequest("edit", parameters);
    }

    public VKRequest delete(VKParameters parameters) {
        return prepareRequest("delete", parameters);
    }

    public VKRequest restore(VKParameters parameters) {
        return prepareRequest("restore", parameters);
    }

    public VKRequest getComments(VKParameters parameters) {
        return prepareRequest("getComments", parameters, VKRequest.HttpMethod.GET, typeof(VKCommentArray));
    }

    public VKRequest addComment(VKParameters parameters) {
        return prepareRequest("addComment", parameters);
    }

    public VKRequest editComment(VKParameters parameters) {
        return prepareRequest("editComment", parameters);
    }

    public VKRequest deleteComment(VKParameters parameters) {
        return prepareRequest("deleteComment", parameters);
    }

    public VKRequest restoreComment(VKParameters parameters) {
        return prepareRequest("restoreComment", parameters);
    }

    public VKRequest reportPost(VKParameters parameters) {
        return prepareRequest("reportPost", parameters);
    }

    public VKRequest reportComment(VKParameters parameters) {
        return prepareRequest("reportComment", parameters);
    }
}
