#region usings

using Newtonsoft.Json.Linq;

#endregion

namespace Vk.SDK.Model
{
    public class VKApiPlace : VKApiModel, IIdentifiable
    {
        /**
     * Location ID.
     */
        public string address;
        public int checkins;
        public int city_id;
        public int country_id;
        public long created;
        public int id;

        /**
     * Location title.
     */

        /**
     * Geographical latitude, in degrees (from -90 to 90).
     */
        public double latitude;

        /**
     * Geographical longitude, in degrees (from -180 to 180)
     */
        public double longitude;
        public string title;

        /**
     * Date (in Unix time) when the location was added
     */

        /**
     * Date (in Unix time) when the location was last time updated
     */
        public long updated;

        /**
     * ID of the country the place is located in, positive number
     */

        /**
     * Creates a Place instance from Parcel.
     */


        /**
     * Creates empty Place instance.
     */


        public int Id
        {
            get { return id; }
        }

        public VKApiPlace parse(JObject from)
        {
            //id = from.optInt("id");
            //title = from.optstring("title");
            //latitude = from.optDouble("latitude");
            //longitude = from.optDouble("longitude");
            //created = from.optLong("created");
            //checkins = from.optInt("checkins");
            //updated = from.optLong("updated");
            //country_id = from.optInt("country");
            //city_id = from.optInt("city");
            //address = from.optstring("address");
            return this;
        }


        public int describeContents()
        {
            return 0;
        }


        public override string ToString()
        {
            return address;
        }
    }
}