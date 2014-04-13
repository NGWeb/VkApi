namespace Vk.SDK.Model
{
    public class Owner : IVKApiModel, IIdentifiable
    {
        /**
     * User or group ID.
     * If ID is positive, owner is user.
     * If ID is negative, owner is community.
     */
        public int id;

        /**
     * Creates an owner with empty ID.
     */

        public Owner()
        {
        }

        /**
     * Fills an owner from JObject
     */
        //public VKApiOwner parse(JObject from)
        //{
        //    id = from.optInt("id");
        //    return this;
        //}

        /**
     * Creates according with given ID.
     */

        public Owner(int id)
        {
            this.id = id;
        }

        /**
     * Creates an owner from Parcel.
     */

        public int Id
        {
            get { return id; }
        }


        public int describeContents()
        {
            return 0;
        }
    }
}