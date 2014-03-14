using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Vk.SDK.Vk;

namespace Vk.SDK.model
{
    public class VKList<T> : VKApiModel, IList<T>{

     private readonly static int NO_COUNT = -1;

        /**
     * Decorated list
     */
        private List<T> items = new List<T>();

        /**
     * Field {@code count} which returned by server.
     */
        private int count = NO_COUNT;

        /**
     * Creates empty list.
     */
        public VKList() {

        }

        /**
     * Creates list and fills it according with given data.
     */
        public VKList(IEnumerable<T> data) {
          items = new List<T>(data);
        }

        /**
     * Creates list and fills it according with data in {@code from}.
     * @param from an object that represents a list adopted in accordance with VK API format. You can use null.
     * @param clazz class represents a model that has a public constructor with {@link org.json.JSONObject} argument.
     */
        public VKList(JSONObject from, System.Type clazz) {
            fill(from, clazz);
        }

        /**
     * Creates list and fills it according with data in {@code from}.
     * @param from an array of items in the list. You can use null.
     * @param clazz class represents a model that has a public constructor with {@link org.json.JSONObject} argument.
     */
        public VKList(JSONArray from, Class<? : T> clazz) {
            fill(from, clazz);
        }

        /**
     * Creates list and fills it according with data in {@code from}.
     * @param from an object that represents a list adopted in accordance with VK API format. You can use null.
     * @param creator interface implementation to parse objects.
     */
        public VKList(JSONObject from, Parser<T> creator) {

            fill(from, creator);
        }

        /**
     * Creates list and fills it according with data in {@code from}.
     * @param from an array of items in the list. You can use null.
     * @param creator interface implementation to parse objects.
     */
        public VKList(JSONArray from, Parser<T> creator) {

            fill(from, creator);
        }

        /**
     * Fills list according with data in {@code from}.
     * @param from an object that represents a list adopted in accordance with VK API format. You can use null.
     * @param clazz class represents a model that has a public constructor with {@link org.json.JSONObject} argument.
     */
        public void fill(JSONObject from, System.Type clazz) {
            if (from.has("response")) {
                JSONArray array = from.optJSONArray("response");
                if (array != null) {
                    fill(array, clazz);
                }
                else {
                    fill(from.optJSONObject("response"), clazz);
                }
            } else {
                fill(from, new ReflectParser<T>(clazz));
            }
        }

        /**
     * Creates list and fills it according with data in {@code from}.
     * @param from an array of items in the list. You can use null.
     * @param clazz class represents a model that has a public constructor with {@link org.json.JSONObject} argument.
     */
        public void fill(JArray from, System.Type clazz) {
            fill(from, new ReflectParser<T>(clazz));
        }

        /**
     * Fills list according with data in {@code from}.
     * @param from an object that represents a list adopted in accordance with VK API format. You can use null.
     * @param creator interface implementation to parse objects.
     */
        public void fill(JObject from,Func<JObject> creator) {
            if(from != null) {
                fill(from.optJSONArray("items"), creator);
                count = from.optInt("count", count);
            }
        }

        /**
     * Fills list according with data in {@code from}.
     * @param from an array of items in the list. You can use null.
     * @param creator interface implementation to parse objects.
     */
        public void fill(JArray from, Func<JObject,VKList<T>> creator) {
            if(from != null) {
                foreach (var jo in from)
                {
                  
}
                for(int i = 0; i < from.length(); i++) {
                    try {
                        T object = creator.parseObject(from.getJSONObject(i));
                        if(object != null) {
                            items.add(object);
                        }
                    } catch (Exception e) {
                        if (VKSdk.DEBUG)
                            e.printStackTrace();
                    }
                }
            }
        }

        /**
     * Adds the element before the element with the specified id.
     * If an element with the specified id is not found, adds an element to the end of the list.
     * @param id element identifier to add element before it.
     * @param data element to add
     */
        public void addBefore(int id, T data) {
            int size = size();
            for(int i = 0; i < size; i++)  {
                if(get(i).getId() > id || i == size - 1) {
                    add(i, data);
                    break;
                }
            }
        }

        /**
     * Adds the element after the element with the specified id.
     * If an element with the specified id is not found, adds an element to the end of the list.
     * @param id element identifier to add element after it.
     * @param data element to add
     */
        public void addAfter(int id, T data) {
            int size = size();
            for(int i = 0; i < size; i++)  {
                if(get(i).getId() > id || i == size - 1) {
                    add(i + 1, data);
                    break;
                }
            }
        }

        /**
     * Returns element according with id.
     * If nothing found, returns null.
     */
        public T getById(int id) {
            for(T item: this) {
                if(item.getId() == id) {
                    return item;
                }
            }
            return null;
        }

        /**
     * Searches through the list of available items. <br />
     * <br />
     * The search will be carried out not by the content of characters per line, and the content of them in separate words. <br />
     * <br />
     * Search is not case sensitive.  <br />
     * <br />
     * To support search class {@code T} must have overridden method {@link #tostring()},
     * search will be carried out exactly according to the result of calling this method. <br />
     * <br />
     * <br />
     * Suppose there are elements in the list of contents:
     * <code><pre>
     * - Hello world
     * - Hello test
     * </pre></code>
     * In this case, the matches will be on search phrases {@code 'Hel'}, {@code 'Hello'}, {@code 'test'}, but not on {@code 'llo'}, {@code 'llo world'}
     *
     * @param query search query can not be equal to {@code null}, but can be an empty string.
     * @return created based on the search results new list. If no matches are found, the list will be empty.
     */
        public VKList<T> search(string query) {
            VKList<T> result = new VKList<T>();
            readonly Pattern pattern = Pattern.compile("(?i).*\\b" + query + ".*");
            for (T item : this) {
                if (pattern.matcher(item.tostring()).find()) {
                    result.add(item);
                }
            }
            return result;
        }

        /**
     * Returns the return value of the field VK API {@code count}, if it has been returned, and the size of the list, if not.
     */
        public int getCount() {
            return count != NO_COUNT ? count : size();
        }

    
        public void add(int location, T object) {
            items.add(location, object);
        }

    
        public bool add(T object) {
            return items.add(object);
        }

    
        public bool addAll(int location, Collection<? : T> collection) {
            return items.addAll(location, collection);
        }

    
        public bool addAll(Collection<? : T> collection) {
            return items.addAll(collection);
        }

    
        public void clear() {
            items.clear();
        }

    
        public bool contains(object object) {
            return items.contains(object);
        }

    
        public bool containsAll(Collection<?> collection) {
            assert collection != null;
            return items.containsAll(collection);
        }

    
        public bool equals(object object) {
            return ((object) this).getClass().equals(object.getClass()) && items.equals(object);
        }

    
        public T get(int location) {
            return items.get(location);
        }

    
        public int indexOf(object object) {
            return items.indexOf(object);
        }

    
        public bool isEmpty() {
            return items.isEmpty();
        }

    
        public Iterator<T> iterator() {
            return items.iterator();
        }

    
        public int lastIndexOf(object object) {
            return items.lastIndexOf(object);
        }


    
        public ListIterator<T> listIterator() {
            return items.listIterator();
        }

    
        public ListIterator<T> listIterator(int location) {
            return items.listIterator(location);
        }

    
        public T remove(int location) {
            return items.remove(location);
        }

    
        public bool remove(object object) {
            return items.remove(object);
        }

    
        public bool removeAll(Collection<?> collection) {
            assert collection != null;
            return items.removeAll(collection);
        }

    
        public bool retainAll(Collection<?> collection) {
            return items.retainAll(collection);
        }

    
        public T set(int location, T object) {
            return items.set(location, object);
        }

    
        public int size() {
            return items.size();
        }

    
        public java.util.List<T> subList(int start, int end) {
            return items.subList(start, end);
        }

    
        public object[] toArray() {
            return items.toArray();
        }

    
        public <T1> T1[] toArray(T1[] array) {
            assert array != null;
            return items.toArray(array);
        }

    
        public int describeContents() {
            return 0;
        }

    
        public void writeToParcel(Parcel dest, int flags) {
            dest.writeInt(items.size());
            for(T item: this) {
                dest.writeParcelable(item, flags);
            }
            dest.writeInt(this.count);
        }

        /**
     * Creates list from Parcel
     */
        public VKList(Parcel in) {
            int size = in.readInt();
            for(int i = 0; i < size; i++) {
                items.add( ((T) in.readParcelable(((object) this).getClass().getClassLoader())));
            }
            this.count = in.readInt();
        }

        public static Creator<VKList> CREATOR = new Creator<VKList>() {
        public VKList createFromParcel(Parcel source) {
    return new VKList(source);
        }

        public VKList[] newArray(int size) {
            return new VKList[size];
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public int Count { get; private set; }
        public bool IsReadOnly { get; private set; }
        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    };

    /**
     * Used when parsing the list objects as interator created from {@link org.json.JSONArray} a instances of items of the list.
     * @param <D> list item type.
     */
    public static interface Parser<D> {

        /**
         * Creates a list item of its representation return VK API from {@link org.json.JSONArray}
         * @param source representation of the object in the format returned by VK API.
         * @return created element to add to the list.
         * @throws Exception if the exception is thrown, the element iterated this method will not be added to the list.
         */
        D parseObject(JSONObject source);
    }

    /**
     * Parser list items using reflection mechanism.
     * To use an object class must have a public constructor that accepts {@link org.json.JSONObject}.
     * If, during the creation of the object constructor will throw any exception, the element will not be added to the list.
     * @param <D> list item type.
     */
    public readonly static class ReflectParser<D : VKApiModel> implements Parser<D> {

        private readonly Class<? : D> clazz;

        public ReflectParser(Class<? : D> clazz) {
            this.clazz = clazz;
        }

        
        public D parseObject(JSONObject source)  {
            return (D) clazz.newInstance().parse(source);
        }
    }

    
    public VKApiModel parse(JSONObject response) {
    throw new JSONException("Operation is not supported while class is generic");
}
    }
}