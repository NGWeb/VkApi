namespace Vk.SDK.Model
{
    public class City : IVKApiModel, IIdentifiable
    {
        /**
     * City ID.
     */
        public int id;

        /**
     * City name
     */
        public string title;

        /**
     * Fills a City instance from JObject.
     */
        //public VKApiCity parse(JObject from) {
        //    id = from.optInt("id");
        //    title = from.optstring("title");
        //    return this;
        //}
        /**
     * Creates empty City instance.
     */


        public int Id
        {
            get { return id; }
        }


        public string tostring()
        {
            return title;
        }


        public int describeContents()
        {
            return 0;
        }

        public City[] newArray(int size)
        {
            return new City[size];
        }
    };
}