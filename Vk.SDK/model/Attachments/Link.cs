namespace Vk.SDK.Model
{
    public class Link : IVKApiModel
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
        private string url;

        /**
     * Creates link attachment to attach it to the post
     * @param url full URL of link
     */

        public Link(string url)
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

        public Link()
        {
        }


        public int Id { get; set; }

        public string ToAttachmentString()
        {
            return url;
        }

        public string GetType()
        {
            return AttachmentType.TYPE_LINK;
        }


        public int describeContents()
        {
            return 0;
        }

        public Link[] newArray(int size)
        {
            return new Link[size];
        }

        public int GetId()
        {
            return 0;
        }
    };
}