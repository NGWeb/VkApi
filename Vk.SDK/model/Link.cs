namespace Vk.SDK.Model
{
    public class Link : VKApiModel, IIdentifiable
    {
        public string desc;
        public string name;
        public VKPhotoSizes photo = new VKPhotoSizes();
        public string url;

        public int Id
        {
            get { return 0; }
        }
    }
}