using Newtonsoft.Json.Linq;
using Vk.SDK.model;

public class VKApiPlace : VKApiModel, IIdentifiable
{

    /**
     * Location ID.
     */
    public int id;

    /**
     * Location title.
     */
    public string title;

    /**
     * Geographical latitude, in degrees (from -90 to 90).
     */
    public double latitude;

    /**
     * Geographical longitude, in degrees (from -180 to 180)
     */
    public double longitude;

    /**
     * Date (in Unix time) when the location was added
     */
    public long created;

    /**
     * Numbers of checkins in this place
     */
    public int checkins;

    /**
     * Date (in Unix time) when the location was last time updated
     */
    public long updated;

    /**
     * ID of the country the place is located in, positive number
     */
    public int country_id;

    /**
     * ID of the city the place is located in, positive number
     */
    public int city_id;

    /**
     * Location address.
     */
    public string address;

    /**
     * Fills a Place instance from JObject.
     */
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

    /**
     * Creates a Place instance from Parcel.
     */


    /**
     * Creates empty Place instance.
     */
    public VKApiPlace()
    {

    }


    public int Id
    {
        get { return id; }
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
