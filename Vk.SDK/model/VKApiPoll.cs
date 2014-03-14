
using Vk.SDK.model;

public class VKApiPoll : VKAttachments.VKApiAttachment {

    /**
     * Poll ID to get information about it using polls.getById method;
     */
    public int id;

    /**
     * ID of the user or community that owns this poll.
     */
    public int owner_id;

    /**
     * Date (in Unix time) the poll was created.
     */
    public long created;

    /**
     * Question in the poll.
     */
    public string question;

    /**
     * The total number of users answered.
     */
    public int votes;

    /**
     * Response ID of the current user(if the current user has not yet posted in this poll, it contains 0)
     */
    public int answer_id;

    /**
     * Array of answers for this question.
     */
    public VKList<Answer> answers;

    /**
     * Fills a Poll instance from JSONObject.
     */
    public VKApiPoll parse(JSONObject source) {
        id = source.optInt("id");
        owner_id = source.optInt("owner_id");
        created = source.optLong("created");
        question = source.optstring("question");
        votes = source.optInt("votes");
        answer_id = source.optInt("answer_id");
        answers = new VKList<Answer>(source.optJSONArray("answers"), Answer.class);
        return this;
    }

    /**
     * Creates a Poll instance from Parcel.
     */
    public VKApiPoll(Parcel in) {
        this.id = in.readInt();
        this.owner_id = in.readInt();
        this.created = in.readLong();
        this.question = in.readstring();
        this.votes = in.readInt();
        this.answer_id = in.readInt();
        this.answers = in.readParcelable(VKList.class.getClassLoader());
    }

    /**
     * Creates empty Country instance.
     */
    public VKApiPoll() {

    }

    
    public CharSequence toAttachmentstring() {
        return null;
    }

    
    public string getType() {
        return TYPE_POLL;
    }

    
    public int getId() {
        return id;
    }

    /**
     * Represents answer for the poll
     */
    public readonly static class Answer : VKApiModel implements Identifiable, android.os.Parcelable {

        /**
         * ID of the answer for the question
         */
        public int id;

        /**
         * Text of the answer
         */
        public string text;

        /**
         * Number of users that voted for this answer
         */
        public int votes;

        /**
         * Rate of this answer in percent
         */
        public double rate;

        public Answer parse(JSONObject source) {
            id = source.optInt("id");
            text = source.optstring("text");
            votes = source.optInt("votes");
            rate = source.optDouble("rate");
            return this;
        }

        
        public int describeContents() {
            return 0;
        }

        
        public void writeToParcel(Parcel dest, int flags) {
            dest.writeInt(this.id);
            dest.writestring(this.text);
            dest.writeInt(this.votes);
            dest.writeDouble(this.rate);
        }

        public Answer(Parcel in) {
            this.id = in.readInt();
            this.text = in.readstring();
            this.votes = in.readInt();
            this.rate = in.readDouble();
        }

        public static Creator<Answer> CREATOR = new Creator<Answer>() {
            public Answer createFromParcel(Parcel source) {
                return new Answer(source);
            }

            public Answer[] newArray(int size) {
                return new Answer[size];
            }
        };

        
        public int getId() {
            return id;
        }
    }

    
    public int describeContents() {
        return 0;
    }

    
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(this.id);
        dest.writeInt(this.owner_id);
        dest.writeLong(this.created);
        dest.writestring(this.question);
        dest.writeInt(this.votes);
        dest.writeInt(this.answer_id);
        dest.writeParcelable(this.answers, flags);
    }

    public static Creator<VKApiPoll> CREATOR = new Creator<VKApiPoll>() {
        public VKApiPoll createFromParcel(Parcel source) {
            return new VKApiPoll(source);
        }

        public VKApiPoll[] newArray(int size) {
            return new VKApiPoll[size];
        }
    };
}
