#region usings

using System.Text;

#endregion

namespace Vk.SDK.Model
{
    public class VKApiAudio : VKApiAttachment, IIdentifiable
    {
        /**
     * Audio ID.
     */
        public string access_key;
        public int album_id;
        public string artist;
        public int duration;
        public int genre;
        public int id;
        public int lyrics_id;

        /**
     * Audio owner ID.
     */
        public int owner_id;

        /**
     * Artist name.
     */

        /**
     * Audio file title.
     */
        public string title;

        /**
     * Duration (in seconds).
     */

        /**
     * Link to mp3.
     */
        public string url;
        public override int Id { get; set; }

        /**
     * ID of the lyrics (if available) of the audio file.
     */

        /**
     * Fills an Audio instance from JObject.
     */


        /**
     * Creates empty Audio instance.
     */


        public override string ToAttachmentString()
        {
            StringBuilder result = new StringBuilder(AttachmentType.TYPE_AUDIO).Append(owner_id).Append('_').Append(id);
            if (!string.IsNullOrEmpty(access_key))
            {
                result.Append('_');
                result.Append(access_key);
            }
            return result.ToString();
        }


        public override string GetType()
        {
            return AttachmentType.TYPE_AUDIO;
        }


        public int describeContents()
        {
            return 0;
        }
    };

    /**
     * Audio object genres.
     */
}