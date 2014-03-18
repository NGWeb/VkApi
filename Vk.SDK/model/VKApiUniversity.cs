using System.Text;
using Vk.SDK.model;

public class VKApiUniversity : VKApiModel, IIdentifiable
{

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
     * Fills a University instance from JObject.
     */
    public VKApiUniversity parse(JObject from)
    {
        //id = from.optInt("id");
        //country_id = from.optInt("country_id");
        //city_id = from.optInt("city_id");
        //name = from.optstring("name");
        //faculty = from.optstring("faculty");
        //faculty_name = from.optstring("faculty_name");
        //chair = from.optInt("chair");
        //chair_name = from.optstring("chair_name");
        //graduation = from.optInt("graduation");
        //education_form = from.optstring("education_form");
        //education_status = from.optstring("education_status");
        return this;
    }

    /**
     * Creates a University instance from Parcel.
     */

    /**
     * Creates empty University instance.
     */
    public VKApiUniversity()
    {

    }

    private string fullName;


    public string ToString()
    {
        if (fullName == null)
        {
            StringBuilder result = new StringBuilder(name);
            result.Append(" \'");
            result.Append(string.Format("{0}", graduation % 100));
            if (!string.IsNullOrEmpty(faculty_name))
            {
                result.Append(", ");
                result.Append(faculty_name);
            }
            if (!string.IsNullOrEmpty(chair_name))
            {
                result.Append(", ");
                result.Append(chair_name);
            }
            fullName = result.ToString();
        }
        return fullName;
    }


    public int Id
    {
        get { return id; }
    }


    public int describeContents()
    {
        return 0;
    }
}
