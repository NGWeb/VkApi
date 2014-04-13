#region usings

using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

#endregion

namespace Vk.SDK.Util
{
    public class VKJsonHelper
    {
        /**
         * Converts object to JSON object, if possible
         *
         * @param object object to ToString to json
         * @return Completed json object
         * @throws JSONException
         */

        public static JObject toJSON(object mapobject)
        {
            return new JObject(mapobject);
            //if (mapobject is Dictionary<object,object>) {
            //    JObject json = new JObject();
            //    Dictionary<object,object> map = (Dictionary<object,object>) mapobject;
            //    foreach (var key in  map) {
            //        json.Add(key.Key.ToString(), toJSON(key.Value));
            //    }
            //    return json;
            //} else if (mapobject is IEnumerable<object>) {
            //    JArray json = new JArray();
            //    foreach (object value in mapobject as IEnumerable<object>) {
            //        json.Add(value);
            //    }
            //    return json;
            //} else {
            //    return null;
            //}
        }

        /**
         * Check if json object is empty
         *
         * @param object object to check
         * @return true if object is empty
         */

        public static bool isEmptyObject(JObject jobject)
        {
            return jobject == null;
        }

        /**
         * Converts field in key to map
         *
         * @param object target object
         * @param key    target key
         * @return Map of field by passed key
         * @throws JSONException
         */

        public static Dictionary<String, Object> toMap(JObject jobject)
        {
            var map = new Dictionary<string, object>();

            foreach (var jo in jobject)
            {
                String key = jo.Key;
                map.Add(key, jo.Value);
            }
            return map;
        }

        /**
         * Converts json-array to list
         *
         * @param array json-array to convert
         * @return converted array
         * @throws JSONException
         */
        //@SuppressWarnings("unchecked")
        //public static List toList(JSONArray array) throws JSONException {
        //    List list = new ArrayList();
        //    for (int i = 0; i < array.length(); i++) {
        //        list.add(fromJson(array.get(i)));
        //    }
        //    return list;
        //}

        //public static Object toArray(JSONArray array, Class arrayClass)
        //{
        //    Object ret = Array.newInstance(arrayClass.getComponentType(), array.length());
        //    Class<?> subType = arrayClass.getComponentType();

        //    for (int i = 0; i < array.length(); i++)
        //    {
        //        try
        //        {
        //            Object jsonItem = array.get(i);
        //            Object objItem = subType.newInstance();
        //            if (jsonItem instanceof JSONObject)
        //            {
        //                JSONObject jsonItem2 = (JSONObject) jsonItem;
        //                if (objItem instanceof VKApiModel)
        //                {
        //                    VKApiModel objItem2 = (VKApiModel) objItem;
        //                    ((VKApiModel) objItem).parse(jsonItem2);
        //                    Array.set(ret, i, objItem2);
        //                }
        //            }
        //        }
        //        catch (JSONException e)
        //        {
        //            if (VKSdk.DEBUG)
        //                e.printStackTrace();
        //        }
        //        catch (InstantiationException e)
        //        {
        //            if (VKSdk.DEBUG)
        //                e.printStackTrace();
        //        }
        //        catch (IllegalAccessException e)
        //        {
        //            if (VKSdk.DEBUG)
        //                e.printStackTrace();
        //        }
        //    }
        //    return ret;
        //}

        /**
         * Converts object from json to java object
         *
         * @param json object from jsonobject or jsonarray
         * @return converted object
         * @throws JSONException
         */

        private static object fromJson(JObject json)
        {
            return json;
        }
    }
}