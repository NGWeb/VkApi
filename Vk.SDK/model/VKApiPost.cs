using System;
using System.Text;

namespace Vk.SDK.model
{
    public class VKApiPost : VKApiAttachment, IIdentifiable {

        /**
     * Post ID on the wall, positive number
     */
        public int id;

        /**
     * Wall owner ID.
     */
        public int to_id;

        /**
     * ID of the user who posted.
     */
        public int from_id;

        /**
     * Date (in Unix time) the post was added.
     */
        public long date;

        /**
     * Text of the post.
     */
        public string text;

        /**
     * ID of the wall owner the post to which the reply is addressed (if the post is a reply to another wall post).
     */
        public int reply_owner_id;

        /**
     * ID of the wall post to which the reply is addressed (if the post is a reply to another wall post).
     */
        public int reply_post_id;

        /**
     * True, if the post was created with "Friends only" option.
     */
        public bool friends_only;

        /**
     * Number of comments.
     */
        public int comments_count;

        /**
     * Whether the current user can leave comments to the post (false — cannot, true — can)
     */
        public bool can_post_comment;

        /**
     * Number of users who liked the post.
     */
        public int likes_count;

        /**
     * Whether the user liked the post (false — not liked, true — liked)
     */
        public bool user_likes;

        /**
     * Whether the user can like the post (false — cannot, true — can).
     */
        public bool can_like;

        /**
     * Whether the user can repost (false — cannot, true — can).
     */
        public bool can_publish;

        /**
     * Number of users who copied the post.
     */
        public int reposts_count;

        /**
     * Whether the user reposted the post (false — not reposted, true — reposted).
     */
        public bool user_reposted;

        /**
     * Type of the post, can be: post, copy, reply, postpone, suggest.
     */
        public string post_type;

        /**
     * Information about attachments to the post (photos, links, etc.), if any;
     */
        public VKAttachments attachments = new VKAttachments();

        /**
     * Information about location.
     */
        public VKApiPlace geo;

        /**
     * ID of the author (if the post was published by a community and signed by a user).
     */
        public int signer_id;

        /**
     * List of history of the reposts.
     */
        public VKList<VKApiPost> copy_history;

        /**
     * Fills a Post instance from JObject.
     */
        public VKApiPost parse(JObject source) {
            id = source.optInt("id");
            to_id = source.optInt("to_id");
            from_id = source.optInt("from_id");
            date = source.optLong("date");
            text = source.optstring("text");
            reply_owner_id = source.optInt("reply_owner_id");
            reply_post_id = source.optInt("reply_post_id");
            friends_only = ParseUtils.parsebool(source, "friends_only");
            JObject comments = source.optJObject("comments");
            if(comments != null) {
                comments_count = comments.optInt("count");
                can_post_comment = ParseUtils.parsebool(comments, "can_post");
            }
            JObject likes = source.optJObject("likes");
            if(likes != null) {
                likes_count = likes.optInt("count");
                user_likes = ParseUtils.parsebool(likes, "user_likes");
                can_like = ParseUtils.parsebool(likes, "can_like");
                can_publish = ParseUtils.parsebool(likes, "can_publish");
            }
            JObject reposts = source.optJObject("reposts");
            if(reposts != null) {
                reposts_count = reposts.optInt("count");
                user_reposted = ParseUtils.parsebool(reposts, "user_reposted");
            }
            post_type = source.optstring("post_type");
            attachments.fill(source.optJSONArray("attachments"));
            JObject geo = source.optJObject("geo");
            if(geo != null) {
                this.geo = new VKApiPlace().parse(geo);
            }
            signer_id = source.optInt("signer_id");
            copy_history = new VKList<VKApiPost>(source.optJSONArray("copy_history"), typeof(VKApiPost));
            return this;
        }

        /**
     * Creates a Post instance from Parcel.
     */
   
        public VKApiPost() {

        }


        public int Id
        {
            get { return id; }
        }


        public string toAttachmentstring() {
            return new StringBuilder(VKAttachments.TYPE_POST).Append(to_id).Append('_').Append(id);
        }

    
        public string getType() {
            return VKAttachments.TYPE_POST;
        }

    
        public int describeContents() {
            return 0;
        }

  
        public VKApiPost[] newArray(int size) {
            return new VKApiPost[size];
        }
    };
}

}
