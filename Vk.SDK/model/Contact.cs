namespace Vk.SDK.Model
{
    public class Contact : IVKApiModel, IIdentifiable
    {
        public string desc;
        public string email;
        public IvkApiUser user;
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