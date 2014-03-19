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
            return prepareRequest<VKPostArray>("get", parameters, AbstractRequest.HttpMethod.GET);
        } else {
            return prepareRequest<VKPostArray>("get", parameters);
        }
    }

    public VkJsonRequest savePost(VKParameters parameters) {
        return PrepareJsonRequest("savePost", parameters);
    }


    public VkJsonRequest post(VKParameters parameters) {
        return PrepareJsonRequest("post", parameters, AbstractRequest.HttpMethod.POST);
    }

    public VkJsonRequest repost(VKParameters parameters) {
        return PrepareJsonRequest("repost", parameters);
    }

    public VkJsonRequest getReposts(VKParameters parameters) {
        return PrepareJsonRequest("getReposts", parameters);
    }

    public VkJsonRequest edit(VKParameters parameters) {
        return PrepareJsonRequest("edit", parameters);
    }

    public VkJsonRequest delete(VKParameters parameters) {
        return PrepareJsonRequest("delete", parameters);
    }

    public VkJsonRequest restore(VKParameters parameters) {
        return PrepareJsonRequest("restore", parameters);
    }

    public VKRequest<VKCommentArray> getComments(VKParameters parameters) {
        return prepareRequest<VKCommentArray>("getComments", parameters, AbstractRequest.HttpMethod.GET );
    }

    public VkJsonRequest addComment(VKParameters parameters) {
        return PrepareJsonRequest("addComment", parameters);
    }

    public VkJsonRequest editComment(VKParameters parameters) {
        return PrepareJsonRequest("editComment", parameters);
    }

    public VkJsonRequest deleteComment(VKParameters parameters) {
        return PrepareJsonRequest("deleteComment", parameters);
    }

    public VkJsonRequest restoreComment(VKParameters parameters) {
        return PrepareJsonRequest("restoreComment", parameters);
    }

    public VkJsonRequest reportPost(VKParameters parameters) {
        return PrepareJsonRequest("reportPost", parameters);
    }

    public VkJsonRequest reportComment(VKParameters parameters) {
        return PrepareJsonRequest("reportComment", parameters);
    }
}
