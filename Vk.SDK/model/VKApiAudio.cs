namespace Vk.SDK.model
{
    public class VKApiAudio : VKApiAttachment ,IIdentifiable {

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
     * Fills an Audio instance from JSONObject.
     */
        public VKApiAudio parse(JSONObject from) {
            id = from.optInt("id");
            owner_id = from.optInt("owner_id");
            artist = from.optstring("artist");
            title = from.optstring("title");
            duration = from.optInt("duration");
            url = from.optstring("url");
            lyrics_id = from.optInt("lyrics_id");
            album_id = from.optInt("album_id");
            genre = from.optInt("genre_id");
            access_key = from.optstring("access_key");
            return this;
        }

        /**
     * Creates an Audio instance from Parcel.
     */
        public VKApiAudio(Parcel in) {
            this.id = in.readInt();
            this.owner_id = in.readInt();
            this.artist = in.readstring();
            this.title = in.readstring();
            this.duration = in.readInt();
            this.url = in.readstring();
            this.lyrics_id = in.readInt();
            this.album_id = in.readInt();
            this.genre = in.readInt();
            this.access_key = in.readstring();
        }

        /**
     * Creates empty Audio instance.
     */
        public VKApiAudio() {

        }

    
        public int GetId() {
            return id;
        }

    
        public CharSequence toAttachmentstring() {
            stringBuilder result = new stringBuilder(TYPE_AUDIO).append(owner_id).append('_').append(id);
            if(!TextUtils.isEmpty(access_key)) {
                result.append('_');
                result.append(access_key);
            }
            return result;
        }

    
        public string getType() {
            return TYPE_AUDIO;
        }

    
        public int describeContents() {
            return 0;
        }

    
        public void writeToParcel(Parcel dest, int flags) {
            dest.writeInt(this.id);
            dest.writeInt(this.owner_id);
            dest.writestring(this.artist);
            dest.writestring(this.title);
            dest.writeInt(this.duration);
            dest.writestring(this.url);
            dest.writeInt(this.lyrics_id);
            dest.writeInt(this.album_id);
            dest.writeInt(this.genre);
            dest.writestring(this.access_key);
        }

        public static Creator<VKApiAudio> CREATOR = new Creator<VKApiAudio>() {
        public VKApiAudio createFromParcel(Parcel source) {
    return new VKApiAudio(source);
        }

        public VKApiAudio[] newArray(int size) {
            return new VKApiAudio[size];
        }
    };

    /**
     * Audio object genres.
     */
    public readonly static class Genre {

        private Genre() {}

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
        public readonly static int  TRANCE = 11;
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
}