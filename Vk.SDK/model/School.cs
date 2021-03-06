#region usings

using System.Text;

#endregion

namespace Vk.SDK.Model
{
    public class School : IVKApiModel, IIdentifiable
    {
        /**
     * School ID, positive number
     */

        /**
     * ID of the city the school is located in, positive number
     */
        public int city_id;
        public string clazz;
        public int country_id;
        private string fullName;
        public int id;

        /**
     * School name
     */
        public string name;
        public string speciality;

        /**
     * Year the user started to study
     */
        public int year_from;

        /**
     * Year the user finished to study
     */

        /**
     * Graduation year
     */
        public int year_graduated;
        public int year_to;

        /**
     * School class letter
     */

        public int Id
        {
            get { return id; }
        }


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
                if (!string.IsNullOrEmpty(clazz))
                {
                    builder.Append('(');
                    builder.Append(clazz);
                    builder.Append(')');
                }
                if (!string.IsNullOrEmpty(speciality))
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