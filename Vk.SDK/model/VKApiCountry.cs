namespace Vk.SDK.model
{
    public class VKApiCountry : VKApiModel,IIdentifiable {

        /**
     * Country ID.
     */
        public int id;

        /**
     * Country name
     */
        public string title;

        /**
     * Fills a Country instance from JSONObject.
     */
        public VKApiCountry parse(JSONObject from) {
            id = from.optInt("id");
            title = from.optstring("title");
            return this;
        }

        /**
     * Creates a Country instance from Parcel.
     */
        public VKApiCountry(Parcel in) {
            this.id = in.readInt();
            this.title = in.readstring();
        }

        /**
     * Creates empty Country instance.
     */
        public VKApiCountry() {

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

        public static Creator<VKApiCountry> CREATOR = new Creator<VKApiCountry>() {
        public VKApiCountry createFromParcel(Parcel source) {
    return new VKApiCountry(source);
        }

        public VKApiCountry[] newArray(int size) {
            return new VKApiCountry[size];
        }
    };
}

}
