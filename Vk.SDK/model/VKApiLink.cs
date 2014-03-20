namespace Vk.SDK.Model
{
    public class VKApiLink : VKApiAttachment
    {
        /**
     * Link URL
     */

        /**
     * Link description;
     */
        public string description;

        /**
     * Image preview URL for the link (if any).
     */
        public string image_src;

        /**
     * ID wiki page with content for the preview of the page contents
     * ID is returned as "ownerid_pageid".
     */
        public string preview_page;
        public string title;
        public string url;

        /**
     * Creates link attachment to attach it to the post
     * @param url full URL of link
     */

        public VKApiLink(string url)
        {
            this.url = url;
        }

        /**
     * Fills a Link instance from JObject.
     */
        //public VKApiLink parse(JObject source)
        //{
        //    url = source.optstring("url");
        //    title = source.optstring("title");
        //    description = source.optstring("description");
        //    image_src = source.optstring("image_src");
        //    preview_page = source.optstring("preview_page");
        //    return this;
        //}

        /**
     * Creates a Link instance from Parcel.
     */

        public VKApiLink()
        {
        }

        public override int Id { get; set; }

        public override string ToAttachmentString()
        {
            return url;
        }

        public override string GetType()
        {
            return AttachmentType.TYPE_LINK;
        }


        public int describeContents()
        {
            return 0;
        }

        public VKApiLink[] newArray(int size)
        {
            return new VKApiLink[size];
        }

        public int GetId()
        {
            return 0;
        }
    };
}