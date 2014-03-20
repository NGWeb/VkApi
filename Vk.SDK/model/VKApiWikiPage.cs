#region usings

using System.Text;
using Newtonsoft.Json.Linq;

#endregion

namespace Vk.SDK.Model
{
    public class VKApiWikiPage : VKApiAttachment
    {
        /**
     * Wiki page ID;
     */

        /**
     * ID of the page creator.
     */
        public long created;
        public int creator_id;

        /**
     * Wiki page name.
     */

        /**
     * Whether a user can edit page text (false — cannot, true — can).
     */
        public bool current_user_can_edit;

        /**
     * Whether a user can edit page access permissions (false — cannot, true — can).
     */
        public bool current_user_can_edit_access;

        /**
     * Who can view the wiki page(0 — only community managers, 1 — only community members, 2 — all users).
     */

        /**
     * Date of the last change.
     */
        public long edited;
        public int editor_id;
        public int group_id;
        public int id;

        /**
     * Page creation date.
     */

        /**
     * Title of the parent page for navigation, if any.
     */
        public string parent;

        /**
     * Title of the second parent page for navigation, if any.
     */
        public string parent2;
        public string source;
        public string title;
        public int who_can_edit;
        public int who_can_view;
        public override int Id { get; set; }

        /**
     * Fills a WikiPage instance from JObject.
     */

        public VKApiWikiPage parse(JObject source)
        {
            //id = source.optInt("id");
            //group_id = source.optInt("group_id");
            //creator_id = source.optInt("creator_id");
            //title = source.optstring("title");
            //this.source = source.optstring("source");
            //current_user_can_edit = ParseUtils.parsebool(source, "current_user_can_edit");
            //current_user_can_edit_access = ParseUtils.parsebool(source, "current_user_can_edit_access");
            //who_can_view = source.optInt("who_can_view");
            //who_can_edit = source.optInt("who_can_edit");
            //editor_id = source.optInt("editor_id");
            //edited = source.optLong("edited");
            //created = source.optLong("created");
            //parent = source.optstring("parent");
            //parent2 = source.optstring("parent2");
            return this;
        }

        /**
     * Creates a WikiPage instance from Parcel.
     */

        /**
     * Creates empty WikiPage instance.
     */


        public override string ToAttachmentString()
        {
            return new StringBuilder(AttachmentType.TYPE_WIKI_PAGE).Append(group_id).Append('_').Append(id).ToString();
        }


        public override string GetType()
        {
            return AttachmentType.TYPE_WIKI_PAGE;
        }


        public int describeContents()
        {
            return 0;
        }
    }
}