using System.Text;

namespace Vk.SDK.model
{
    public class VKApiAudio : VKApiAttachment, IIdentifiable
    {

        /**
     * Audio ID.
     */
        public int id;

        /**
     * Audio owner ID.
     */
        public int owner_id;

        /**
     * Artist name.
     */
        public string artist;

        /**
     * Audio file title.
     */
        public string title;

        /**
     * Duration (in seconds).
     */
        public int duration;

        /**
     * Link to mp3.
     */
        public string url;

        /**
     * ID of the lyrics (if available) of the audio file.
     */
        public int lyrics_id;

        /**
     * ID of the album containing the audio file (if assigned).
     */
        public int album_id;

        /**
     * Genre ID. See the list of audio genres.
     */
        public int genre;

        /**
     * An access key using for get information about hidden objects.
     */
        public string access_key;

        /**
     * Fills an Audio instance from JObject.
     */


        /**
     * Creates empty Audio instance.
     */
        public VKApiAudio()
        {

        }


        public string ToAttachmentstring()
        {
            StringBuilder result = new StringBuilder(TYPE_AUDIO).Append(owner_id).Append('_').Append(id);
            if (!TextUtils.isEmpty(access_key))
            {
                result.Append('_');
                result.Append(access_key);
            }
            return result.ToString();
        }


        public string GetType()
        {
            return TYPE_AUDIO;
        }


        public int describeContents()
        {
            return 0;
        }



    };

    /**
     * Audio object genres.
     */
    public class Genre
    {

        private Genre() { }

        public readonly static int ROCK = 1;
        public readonly static int POP = 2;
        public readonly static int RAP_AND_HIPHOP = 3;
        public readonly static int EASY_LISTENING = 4;
        public readonly static int DANCE_AND_HOUSE = 5;
        public readonly static int INSTRUMENTAL = 6;
        public readonly static int METAL = 7;
        public readonly static int DUBSTEP = 8;
        public readonly static int JAZZ_AND_BLUES = 9;
        public readonly static int DRUM_AND_BASS = 10;
        public readonly static int TRANCE = 11;
        public readonly static int CHANSON = 12;
        public readonly static int ETHNIC = 13;
        public readonly static int ACOUSTIC_AND_VOCAL = 14;
        public readonly static int REGGAE = 15;
        public readonly static int CLASSICAL = 16;
        public readonly static int INDIE_POP = 17;
        public readonly static int OTHER = 18;
        public readonly static int SPEECH = 19;
        public readonly static int ALTERNATIVE = 21;
        public readonly static int ELECTROPOP_AND_DISCO = 22;
    }

}