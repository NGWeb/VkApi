namespace Vk.SDK.Model
{
    public class Contact : VKApiModel, IIdentifiable
    {
        public string desc;
        public string email;
        public VKApiUser user;
        public int user_id;


        public int Id
        {
            get { return user_id; }
        }

        public int describeContents()
        {
            return 0;
        }
    }
}