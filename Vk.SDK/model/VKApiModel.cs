using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Vk.SDK.model
{
    public abstract class VKApiModel {

        public JObject fields;
        /**
     * The model's tag.
     */
        private object mTag;

        /**
     * Map used to store model's tags.
     */
        private List<object> mKeyedTags;

        /**
     * Returns this model's tag.
     *
     * @return the object stored in this model as a tag
     *
     * @see #setTag(object)
     * @see #getTag(int)
     */
        public object getTag() {
            return mTag;
        }

        /**
     * Sets the tag associated with this model. A tag can be used to store
     * data within a model without resorting to another data structure.
     *
     * @param tag an object to tag the model with
     *
     * @see #getTag()
     * @see #setTag(int, object)
     */
        public void setTag(object tag) {
            mTag = tag;
        }

        /**
     * Returns the tag associated with this model and the specified key.
     *
     * @param key The key identifying the tag
     *
     * @return the object stored in this model as a tag
     *
     * @see #setTag(int, object)
     * @see #getTag()
     */
        public object getTag(int key) {
            if (mKeyedTags != null) return mKeyedTags.get(key);
            return null;
        }

        /**
     * Sets a tag associated with this model and a key. A tag can be used
     * to store data within a model without resorting to another
     * data structure.
     *
     * @see #setTag(object)
     * @see #getTag(int)
     */
        public void setTag(int key, readonly object tag) {
            if (mKeyedTags == null) {
                mKeyedTags = new SparseArray<object>(2);
            }
            mKeyedTags.put(key, tag);
        }

        /**
     * Parses object from source.
     * @param response server API object.
     * @return this object.
     * @throws JSONException if any critical error occurred while parsing.
     */
        public VKApiModel parse(JObject response) {
            return ParseUtils.parseViaReflection(this, response);
        }
    }
}
