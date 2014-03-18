using System.Text;

namespace Vk.SDK.model
{
    public class VKApiSchool : VKApiModel, IIdentifiable
    {

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
        ////public VKApiSchool parse(JObject from) {
        ////    id = from.optInt("id");
        ////    country_id = from.optInt("country_id");
        ////    city_id = from.optInt("city_id");
        ////    name = from.optstring("name");
        ////    year_from = from.optInt("year_from");
        ////    year_to = from.optInt("year_to");
        ////    year_graduated = from.optInt("year_graduated");
        ////    clazz = from.optstring("class");
        ////    speciality = from.optstring("speciality");
        ////    return this;
        ////}

        /**
     * Creates a School instance from Parcel.
     */


        /**
     * Creates empty School instance.
     */
        public VKApiSchool()
        {

        }


        public int Id
        {
            get { return id; }
        }

        private string fullName;


        public string ToString()
        {
            if (fullName == null)
            {
                StringBuilder builder = new StringBuilder(name);
                if (year_graduated != 0)
                {
                    builder.Append(" \'");
                    builder.AppendFormat("{0}", year_graduated % 100);
                }
                if (year_from != 0 && year_to != 0)
                {
                    builder.Append(", ");
                    builder.Append(year_from);
                    builder.Append('-');
                    builder.Append(year_to);
                }
                if (!isEmpty(clazz))
                {
                    builder.Append('(');
                    builder.Append(clazz);
                    builder.Append(')');
                }
                if (!isEmpty(speciality))
                {
                    builder.Append(", ");
                    builder.Append(speciality);
                }
                fullName = builder.ToString();
            }
            return fullName;
        }


        public int describeContents()
        {
            return 0;
        }
    }
}
