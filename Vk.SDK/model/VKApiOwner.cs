namespace Vk.SDK.model
{
    public class VKApiOwner : VKApiModel, IIdentifiable {

        /**
     * User or group ID.
     * If ID is positive, owner is user.
     * If ID is negative, owner is community.
     */
        public int id;

        /**
     * Creates an owner with empty ID.
     */
        public VKApiOwner() {

        }

        /**
     * Fills an owner from JObject
     */
        public VKApiOwner parse(JObject from) {
            id = from.optInt("id");
            return this;
        }

        /**
     * Creates according with given ID.
     */
        public VKApiOwner(int id) {
            this.id = id;
        }

        /**
     * Creates an owner from Parcel.
     */
        public VKApiOwner(Parcel in) {
            this.id = in.readInt();
        }

    
        public int GetId() {
            return id;
        }

    
        public int describeContents() {
            return 0;
        }

    
        public void writeToParcel(Parcel dest, int flags) {
            dest.writeInt(this.id);
        }

        public static Creator<VKApiOwner> CREATOR = new Creator<VKApiOwner>() {
        public VKApiOwner createFromParcel(Parcel source) {
    return new VKApiOwner(source);
        }

        public VKApiOwner[] newArray(int size) {
            return new VKApiOwner[size];
        }
    };
}
}
