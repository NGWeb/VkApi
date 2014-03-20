#region usings

using System.Text;
using Newtonsoft.Json.Linq;

#endregion

namespace Vk.SDK.Model
{
    public class VKApiUniversity : VKApiModel, IIdentifiable
    {
        /**
     * University ID, positive number
     */

        /**
     * University chair ID;
     */
        public int chair;

        /**
     * Chair name
     */
        public string chair_name;
        public int city_id;
        public int country_id;

        /**
     * Graduation year
     */

        /**
     * Form of education
     */
        public string education_form;

        /**
     * Status of education
     */
        public string education_status;
        public string faculty;

        /**
     * Faculty name
     */
        public string faculty_name;

        /**
     * Fills a University instance from JObject.
     */

        /**
     * Creates a University instance from Parcel.
     */

        /**
     * Creates empty University instance.
     */

        private string fullName;
        public int graduation;
        public int id;
        public string name;


        public int Id
        {
            get { return id; }
        }

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

        public string ToString()
        {
            if (fullName == null)
            {
                StringBuilder result = new StringBuilder(name);
                result.Append(" \'");
                result.Append(string.Format("{0}", graduation%100));
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


        public int describeContents()
        {
            return 0;
        }
    }
}