namespace Vk.SDK.Model
{
    public class Country : IVKApiModel, IIdentifiable
    {
        /**
     * Country ID.
     */
        public int id;

        /**
     * Country name
     */
        public string title;

        /**
     * Fills a Country instance from JObject.
     */
        //public VKApiCountry parse(JObject from)
        //{
        //    id = from.optInt("id");
        //    title = from.optstring("title");
        //    return this;
        //}

        /**
     * Creates a Country instance from Parcel.
     */
        /**
         * Creates empty Country instance.
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

        public Country[] newArray(int size)
        {
            return new Country[size];
        }
    };
}