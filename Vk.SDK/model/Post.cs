#region usings

using System.Text;
using Newtonsoft.Json.Linq;

#endregion

namespace Vk.SDK.Model
{
    public class Post : Attachment
    {
        /**
     * Post ID on the wall, positive number
     */

        /**
     * Date (in Unix time) the post was added.
     */
        public VkAttachments attachments = new VkAttachments();
        public bool can_like;
        public bool can_post_comment;
        public bool can_publish;
        public int comments_count;
        public VkList<Post> copy_history;
        public long date;

        /**
     * Text of the post.
     */

        /**
     * True, if the post was created with "Friends only" option.
     */
        public bool friends_only;
        public int from_id;
        public Place geo;
        public int id;

        /**
     * Number of comments.
     */

        /**
     * Number of users who liked the post.
     */
        public int likes_count;

        /**
     * Whether the user liked the post (false — not liked, true — liked)
     */

        /**
     * PublicType of the post, can be: post, copy, reply, postpone, suggest.
     */
        public string post_type;
        public int reply_owner_id;

        /**
     * ID of the wall post to which the reply is addressed (if the post is a reply to another wall post).
     */
        public int reply_post_id;
        public int reposts_count;

        /**
     * Information about attachments to the post (photos, links, etc.), if any;
     */

        /**
     * ID of the author (if the post was published by a community and signed by a user).
     */
        public int signer_id;
        public string text;
        public int to_id;
        public bool user_likes;
        public bool user_reposted;
        public override int Id { get; set; }

        /**
     * List of history of the reposts.
     */

        /**
     * Fills a Post instance from JObject.
     */

        public Post parse(JObject source)
        {
            //id = source.optInt("id");
            //to_id = source.optInt("to_id");
            //from_id = source.optInt("from_id");
            //date = source.optLong("date");
            //text = source.optstring("text");
            //reply_owner_id = source.optInt("reply_owner_id");
            //reply_post_id = source.optInt("reply_post_id");
            //friends_only = ParseUtils.parsebool(source, "friends_only");
            //JObject comments = source.optJObject("comments");
            //if(comments != null) {
            //    comments_count = comments.optInt("count");
            //    can_post_comment = ParseUtils.parsebool(comments, "can_post");
            //}
            //JObject likes = source.optJObject("likes");
            //if(likes != null) {
            //    likes_count = likes.optInt("count");
            //    user_likes = ParseUtils.parsebool(likes, "user_likes");
            //    can_like = ParseUtils.parsebool(likes, "can_like");
            //    can_publish = ParseUtils.parsebool(likes, "can_publish");
            //}
            //JObject reposts = source.optJObject("reposts");
            //if(reposts != null) {
            //    reposts_count = reposts.optInt("count");
            //    user_reposted = ParseUtils.parsebool(reposts, "user_reposted");
            //}
            //post_type = source.optstring("post_type");
            //attachments.fill(source.optJSONArray("attachments"));
            //JObject geo = source.optJObject("geo");
            //if(geo != null) {
            //    this.geo = new VKApiPlace().parse(geo);
            //}
            //signer_id = source.optInt("signer_id");
            //copy_history = new VKList<VKApiPost>(source.optJSONArray("copy_history"), typeof(VKApiPost));
            return this;
        }

        /**
     * Creates a Post instance from Parcel.
     */


        public override string GetType()
        {
            return AttachmentType.TYPE_POST;
        }


        public override string ToAttachmentString()
        {
            return new StringBuilder(AttachmentType.TYPE_POST).Append(to_id).Append('_').Append(id).ToString();
        }


        public string getType()
        {
            return AttachmentType.TYPE_POST;
        }


        public int describeContents()
        {
            return 0;
        }


        public Post[] newArray(int size)
        {
            return new Post[size];
        }
    };
}