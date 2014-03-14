namespace Vk.SDK.model
{
    public class VKApiSchool : VKApiModel , IIdentifiable {

        /**
     * School ID, positive number
     */
        public int id;

        /**
     * ID of the country the school is located in, positive number
     */
        public int country_id;

        /**
     * ID of the city the school is located in, positive number
     */
        public int city_id;

        /**
     * School name
     */
        public string name;

        /**
     * Year the user started to study
     */
        public int year_from;

        /**
     * Year the user finished to study
     */
        public int year_to;

        /**
     * Graduation year
     */
        public int year_graduated;

        /**
     * School class letter
     */
        public string clazz;

        /**
     * Speciality
     */
        public string speciality;

        /**
     * Fills a School instance from JObject.
     */
        public VKApiSchool parse(JObject from) {
            id = from.optInt("id");
            country_id = from.optInt("country_id");
            city_id = from.optInt("city_id");
            name = from.optstring("name");
            year_from = from.optInt("year_from");
            year_to = from.optInt("year_to");
            year_graduated = from.optInt("year_graduated");
            clazz = from.optstring("class");
            speciality = from.optstring("speciality");
            return this;
        }

        /**
     * Creates a School instance from Parcel.
     */
        public VKApiSchool(Parcel in) {
            this.id = in.readInt();
            this.country_id = in.readInt();
            this.city_id = in.readInt();
            this.name = in.readstring();
            this.year_from = in.readInt();
            this.year_to = in.readInt();
            this.year_graduated = in.readInt();
            this.clazz = in.readstring();
            this.speciality = in.readstring();
        }

        /**
     * Creates empty School instance.
     */
        public VKApiSchool() {

        }


        public int Id
        {
            get { return id; }
        }

        private string fullName;

    
        public string tostring() {
            if(fullName == null) {
                stringBuilder builder = new stringBuilder(name);
                if(year_graduated != 0) {
                    builder.append(" \'");
                    builder.append(string.format("%02d", year_graduated % 100));
                }
                if(year_from != 0 && year_to != 0) {
                    builder.append(", ");
                    builder.append(year_from);
                    builder.append('-');
                    builder.append(year_to);
                }
                if(!isEmpty(clazz)) {
                    builder.append('(');
                    builder.append(clazz);
                    builder.append(')');
                }
                if(!isEmpty(speciality)) {
                    builder.append(", ");
                    builder.append(speciality);
                }
                fullName = builder.tostring();
            }
            return fullName;
        }

    
        public int describeContents() {
            return 0;
        }

    
        public void writeToParcel(Parcel dest, int flags) {
            dest.writeInt(this.id);
            dest.writeInt(this.country_id);
            dest.writeInt(this.city_id);
            dest.writestring(this.name);
            dest.writeInt(this.year_from);
            dest.writeInt(this.year_to);
            dest.writeInt(this.year_graduated);
            dest.writestring(this.clazz);
            dest.writestring(this.speciality);
        }

        public static Creator<VKApiSchool> CREATOR = new Creator<VKApiSchool>() {
        public VKApiSchool createFromParcel(Parcel source) {
    return new VKApiSchool(source);
        }

        public VKApiSchool[] newArray(int size) {
            return new VKApiSchool[size];
        }
    };
}

}
