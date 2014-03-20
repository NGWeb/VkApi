#region usings

using System.Collections;
using System.Collections.Generic;

#endregion

namespace Vk.SDK.Model
{
    public class VKList<T> : VKApiModel, IList<T> where T : VKApiModel
    {
        private static readonly int NO_COUNT = -1;

        /**
     * Decorated list
     */
        private readonly List<T> _items = new List<T>();

        /**
     * Field {@code count} which returned by server.
     */
        private int count = NO_COUNT;

        /**
     * Creates empty list.
     */

        public VKList()
        {
        }

        /**
     * Creates list and fills it according with given data.
     */

        public VKList(IEnumerable<T> data)
        {
            _items = new List<T>(data);
        }

        /**
     * Creates list and fills it according with data in {@code from}.
     * @param from an object that represents a list adopted in accordance with VK API format. You can use null.
     * @param clazz class represents a model that has a public constructor with {@link org.json.JObject} argument.
     */

        //   public VKList(JObject from)
        //   {
        //       fill(from);
        //   }

        //   /**
        //* Creates list and fills it according with data in {@code from}.
        //* @param from an array of items in the list. You can use null.
        //* @param clazz class represents a model that has a public constructor with {@link org.json.JObject} argument.
        //*/

        //   public VKList(JSONArray from, System.Type clazz)
        //   {
        //       fill(from, clazz);
        //   }

        //   /**
        //* Creates list and fills it according with data in {@code from}.
        //* @param from an object that represents a list adopted in accordance with VK API format. You can use null.
        //* @param creator interface implementation to parse objects.
        //*/

        //   public VKList(JObject from, Parser<T> creator)
        //   {

        //       fill(from, creator);
        //   }

        //   /**
        //* Creates list and fills it according with data in {@code from}.
        //* @param from an array of items in the list. You can use null.
        //* @param creator interface implementation to parse objects.
        //*/

        //   public VKList(JSONArray from, Parser<T> creator)
        //   {

        //       fill(from, creator);
        //   }

        //   /**
        //* Fills list according with data in {@code from}.
        //* @param from an object that represents a list adopted in accordance with VK API format. You can use null.
        //* @param clazz class represents a model that has a public constructor with {@link org.json.JObject} argument.
        //*/

        //   public void fill(JObject from, Type clazz)
        //   {
        //       if (from.has("response"))
        //       {
        //           JSONArray array = from.optJSONArray("response");
        //           if (array != null)
        //           {
        //               fill(array, clazz);
        //           }
        //           else
        //           {
        //               fill(from.optJObject("response"), clazz);
        //           }
        //       }
        //       else
        //       {
        //           fill(from, new ReflectParser<T>(clazz));
        //       }
        //   }

        //   /**
        //* Creates list and fills it according with data in {@code from}.
        //* @param from an array of items in the list. You can use null.
        //* @param clazz class represents a model that has a public constructor with {@link org.json.JObject} argument.
        //*/

        //   public void fill(JArray from, System.Type clazz)
        //   {
        //       fill(from, new ReflectParser<T>(clazz));
        //   }

        //   /**
        //* Fills list according with data in {@code from}.
        //* @param from an object that represents a list adopted in accordance with VK API format. You can use null.
        //* @param creator interface implementation to parse objects.
        //*/

        //   public void fill(JObject from, Func<JObject> creator)
        //   {
        //       if (from != null)
        //       {
        //           fill(from.GetValue("items"), creator);
        //           count = from.optInt("count", count);
        //       }
        //   }

        //   /**
        //* Fills list according with data in {@code from}.
        //* @param from an array of items in the list. You can use null.
        //* @param creator interface implementation to parse objects.
        //*/

        //   public void fill(JArray from, Func<JObject, VKList<T>> creator)
        //   {
        //       if (from != null)
        //       {
        //           foreach (var jo in from)
        //           {

        //               for (int i = 0; i < from.length(); i++)
        //               {
        //                   try
        //                   {
        //                       T tobject =
        //                       creator.parseObject(from.getJObject(i));
        //                       if (tobject !=
        //                       null)
        //                       {
        //                           items.Add(tobject);
        //                       }
        //                   }
        //                   catch (Exception e)
        //                   {
        //                       if (VKSdk.DEBUG)
        //                           e.printStackTrace();
        //                   }
        //               }
        //           }
        //       }

        //   }
        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _items.Remove(item);
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public int IndexOf(T item)
        {
            return _items.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _items.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _items.RemoveAt(index);
        }

        public T this[int index]
        {
            get { return _items[index]; }
            set { _items[index] = value; }
        }
    }
}