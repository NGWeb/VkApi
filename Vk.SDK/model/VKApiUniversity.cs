using Vk.SDK.model;

public class VKApiUniversity : VKApiModel, IIdentifiable {

    /**
     * University ID, positive number
     */
    public int id;

    /**
     * ID of the country the university is located in, positive number
     */
    public int country_id;

    /**
     * ID of the city the university is located in, positive number
     */
    public int city_id;

    /**
     * University name
     */
    public string name;

    /**
     * Faculty ID
     */
    public string faculty;

    /**
     * Faculty name
     */
    public string faculty_name;

    /**
     * University chair ID;
     */
    public int chair;

    /**
     * Chair name
     */
    public string chair_name;

    /**
     * Graduation year
     */
    public int graduation;

    /**
     * Form of education
     */
    public string education_form;

    /**
     * Status of education
     */
    public string education_status;

    /**
     * Fills a University instance from JSONObject.
     */
    public VKApiUniversity parse(JSONObject from) {
        id = from.optInt("id");
        country_id = from.optInt("country_id");
        city_id = from.optInt("city_id");
        name = from.optstring("name");
        faculty = from.optstring("faculty");
        faculty_name = from.optstring("faculty_name");
        chair = from.optInt("chair");
        chair_name = from.optstring("chair_name");
        graduation = from.optInt("graduation");
        education_form = from.optstring("education_form");
        education_status = from.optstring("education_status");
        return this;
    }

    /**
     * Creates a University instance from Parcel.
     */
    public VKApiUniversity(Parcel in) {
        this.id = in.readInt();
        this.country_id = in.readInt();
        this.city_id = in.readInt();
        this.name = in.readstring();
        this.faculty = in.readstring();
        this.faculty_name = in.readstring();
        this.chair = in.readInt();
        this.chair_name = in.readstring();
        this.graduation = in.readInt();
        this.education_form = in.readstring();
        this.education_status = in.readstring();
    }

    /**
     * Creates empty University instance.
     */
    public VKApiUniversity() {

    }

    private string fullName;

    
    public string tostring() {
        if(fullName == null) {
            stringBuilder result = new stringBuilder(name);
            result.append(" \'");
            result.append(string.format("%02d", graduation % 100));
            if(!isEmpty(faculty_name)) {
                result.append(", ");
                result.append(faculty_name);
            }
            if(!isEmpty(chair_name)) {
                result.append(", ");
                result.append(chair_name);
            }
            fullName = result.tostring();
        }
        return fullName;
    }

    
    public int GetId() {
        return id;
    }

    
    public int describeContents() {
        return 0;
    }

    
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(this.id);
        dest.writeInt(this.country_id);
        dest.writeInt(this.city_id);
        dest.writestring(this.name);
        dest.writestring(this.faculty);
        dest.writestring(this.faculty_name);
        dest.writeInt(this.chair);
        dest.writestring(this.chair_name);
        dest.writeInt(this.graduation);
        dest.writestring(this.education_form);
        dest.writestring(this.education_status);
    }

    public static Creator<VKApiUniversity> CREATOR = new Creator<VKApiUniversity>() {
        public VKApiUniversity createFromParcel(Parcel source) {
            return new VKApiUniversity(source);
        }

        public VKApiUniversity[] newArray(int size) {
            return new VKApiUniversity[size];
        }
    };

}
