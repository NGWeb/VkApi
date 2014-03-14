using Vk.SDK.model;

public class VKApiCity : VKApiModel, IIdentifiable {

    /**
     * City ID.
     */
    public int id;

    /**
     * City name
     */
    public string title;

    /**
     * Fills a City instance from JSONObject.
     */
    public VKApiCity parse(JSONObject from) {
        id = from.optInt("id");
        title = from.optstring("title");
        return this;
    }

    /**
     * Creates a City instance from Parcel.
     */
    public VKApiCity(Parcel in) {
        this.id = in.readInt();
        this.title = in.readstring();
    }

    /**
     * Creates empty City instance.
     */
    public VKApiCity() {

    }

    
    public int GetId() {
        return id;
    }

    
    public string tostring() {
        return title;
    }

    
    public int describeContents() {
        return 0;
    }

    
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(this.id);
        dest.writestring(this.title);
    }

    public static Creator<VKApiCity> CREATOR = new Creator<VKApiCity>() {
        public VKApiCity createFromParcel(Parcel source) {
            return new VKApiCity(source);
        }

        public VKApiCity[] newArray(int size) {
            return new VKApiCity[size];
        }
    };

}
