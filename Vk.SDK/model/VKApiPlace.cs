using Vk.SDK.model;

public class VKApiPlace : VKApiModel ,IIdentifiable {

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
    public VKApiPlace parse(JObject from) {
        id = from.optInt("id");
        title = from.optstring("title");
        latitude = from.optDouble("latitude");
        longitude = from.optDouble("longitude");
        created = from.optLong("created");
        checkins = from.optInt("checkins");
        updated = from.optLong("updated");
        country_id = from.optInt("country");
        city_id = from.optInt("city");
        address = from.optstring("address");
        return this;
    }

    /**
     * Creates a Place instance from Parcel.
     */
    public VKApiPlace(Parcel in) {
        this.id = in.readInt();
        this.title = in.readstring();
        this.latitude = in.readDouble();
        this.longitude = in.readDouble();
        this.created = in.readLong();
        this.checkins = in.readInt();
        this.updated = in.readLong();
        this.country_id = in.readInt();
        this.city_id = in.readInt();
        this.address = in.readstring();
    }

    /**
     * Creates empty Place instance.
     */
    public VKApiPlace() {

    }


    public int Id
    {
        get { return id; }
    }


    public int describeContents() {
        return 0;
    }

    
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(this.id);
        dest.writestring(this.title);
        dest.writeDouble(this.latitude);
        dest.writeDouble(this.longitude);
        dest.writeLong(this.created);
        dest.writeInt(this.checkins);
        dest.writeLong(this.updated);
        dest.writeInt(this.country_id);
        dest.writeInt(this.city_id);
        dest.writestring(address);
    }

    
    public string tostring() {
        return address;
    }

    public static Creator<VKApiPlace> CREATOR = new Creator<VKApiPlace>() {
        public VKApiPlace createFromParcel(Parcel source) {
            return new VKApiPlace(source);
        }

        public VKApiPlace[] newArray(int size) {
            return new VKApiPlace[size];
        }
    };
}
