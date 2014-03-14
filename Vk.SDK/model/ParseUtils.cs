using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Vk.SDK.model
{
    class ParseUtils {

        private ParseUtils() {
        }

        /**
     * Parse bool from server response.
     *
     * @param from server response like this format: {@code response: 1}
     * @throws JSONException if server response is not valid
     */
        public static bool parsebool(string from)  {
            return new JObject(from).optInt("response", 0) == 1;
        }

        /**
     * Parse bool from JObject with given name.
     *
     * @param from server response like this format: {@code field: 1}
     * @param name name of field to read
     */
        public static bool parsebool(JObject from, string name) {
            return from != null && from.optInt(name, 0) == 1;
        }

        /**
     * Parse int from JObject with given name.
     *
     * @param from server response like this format: {@code field: 34}
     * @param name name of field to read
     */
        public static int parseInt(JObject from, string name) {
            if (from == null) return 0;
            return from.optInt(name, 0);
        }

        /**
     * Parse int from server response.
     *
     * @param from server response like this format: {@code response: 34}
     * @throws JSONException if server response is not valid
     */
        public static int parseInt(string from)  {
            if (from == null) return 0;
            return new JObject(from).optInt("response");
        }

        /**
     * Parse long from JObject with given name.
     *
     * @param from server response like this format: {@code field: 34}
     * @param name name of field to read
     */
        public static long parseLong(JObject from, string name) {
            if (from == null) return 0;
            return from.optLong(name, 0);
        }

        /**
     * Parse int array from JObject with given name.
     *
     * @param from int JSON array like this one {@code {11, 34, 42}}
     */
        public static int[] parseIntArray(JSONArray from) {
            int[] result = new int[from.length()];
            for (int i = 0; i < result.length; i++) {
                result[i] = from.optInt(i);
            }
            return result;
        }

        /**
     * Returns root JObject from server response
     *
     * @param source standart VK server response
     * @throws JSONException if source is not valid
     */
        public static JObject rootJObject(string source) {
            return new JObject(source).getJObject("response");
        }

        /**
     * Returns root JSONArray from server response
     *
     * @param source standart VK server response
     * @throws JSONException if source is not valid
     */
        public static JSONArray rootJSONArray(string source) {
            return new JObject(source).getJSONArray("response");
        }

        /**
     * Parses object with follow rules:
     *
     * 1. All fields should had a public access.
     * 2. The name of the filed should be fully equal to name of JObject key.
     * 3. Supports parse of all Java primitives, all {@link java.lang.string},
     *  arrays of primitive types, {@link java.lang.string}s and {@link com.vk.sdk.api.model.VKApiModel}s,
     *  list implementation line {@link com.vk.sdk.api.model.VKList}, {@link com.vk.sdk.api.model.VKAttachments.VKAttachment} or {@link com.vk.sdk.api.model.VKPhotoSizes},
     *  {@link com.vk.sdk.api.model.VKApiModel}s.
     *
     * 4. bool fields defines by vk_int == 1 expression.
     *
     * @param object object to initialize
     * @param source data to read values
     * @param <T> type of result
     * @return initialized according with given data object
     * @throws JSONException if source object structure is invalid
     */
  
        public T parseViaReflection(T tobject, JObject source){
            if (source.TryGetValue("response")) {
                source = source.optJObject("response");
            }
            if (source == null) {
                return tobject;
            }
            foreach (FieldInfo field in tobject.GetType().getFields()) {
                field.setAccessible(true);
                string fieldName = field.getName();
                Class<?> fieldType = field.getType();

                object value = source.opt(fieldName);
                if (value == null) {
                    continue;
                }
                try {
                    if (fieldType.isPrimitive() && value instanceof Number) {
                        Number number = (Number) value;
                        if (fieldType.Equals(int.class)) {
                            field.setInt(object, number.intValue());
                        } else if (fieldType.Equals(long.class)) {
                            field.setLong(object, number.longValue());
                        } else if (fieldType.Equals(float.class)) {
                            field.setFloat(object, number.floatValue());
                        } else if (fieldType.Equals(double.class)) {
                            field.setDouble(object, number.doubleValue());
                        } else if (fieldType.Equals(bool.class)) {
                            field.setbool(object, number.intValue() == 1);
                        } else if (fieldType.Equals(short.class)) {
                            field.setShort(object, number.shortValue());
                        } else if (fieldType.Equals(byte.class)) {
                            field.setByte(object, number.byteValue());
                        }
                    } else {
                        object result = field.get(object);
                        if (value.getClass().Equals(fieldType)) {
                            result = value;
                        } else if (fieldType.isArray() && value instanceof JSONArray) {
                            result = parseArrayViaReflection((JSONArray) value, fieldType);
                        }  else if(VKPhotoSizes.class.isAssignableFrom(fieldType) && value instanceof JSONArray) {
                            Constructor<?> constructor = fieldType.getConstructor(JSONArray.class);
                            result = constructor.newInstance((JSONArray) value);
                        } else if(VKAttachments.class.isAssignableFrom(fieldType) && value instanceof JSONArray) {
                            Constructor<?> constructor = fieldType.getConstructor(JSONArray.class);
                            result = constructor.newInstance((JSONArray) value);
                        } else if(VKList.class.Equals(fieldType)) {
                            ParameterizedType genericTypes = (ParameterizedType) field.getGenericType();
                            Class<?> genericType = (Class<?>) genericTypes.getActualTypeArguments()[0];
                            if(VKApiModel.class.isAssignableFrom(genericType) && Parcelable.class.isAssignableFrom(genericType) && Identifiable.class.isAssignableFrom(genericType)) {
                                if(value instanceof JSONArray) {
                                    result = new VKList((JSONArray) value, genericType);
                                } else if(value instanceof JObject) {
                                    result = new VKList((JObject) value, genericType);
                                }
                            }
                        } else if (VKApiModel.class.isAssignableFrom(fieldType) && value instanceof JObject) {
                            result = ((VKApiModel) fieldType.newInstance()).parse((JObject) value);
                        }
                        field.set(object, result);
                    }
                } catch (InstantiationException e) {
                    throw new JSONException(e.getMessage());
                } catch (IllegalAccessException e) {
                    throw new JSONException(e.getMessage());
                } catch (NoSuchMethodException e) {
                    throw new JSONException(e.getMessage());
                } catch (InvocationTargetException e) {
                    throw new JSONException(e.getMessage());
                } catch (NoSuchMethodError e) {
                    // Примечание Виталия:
                    // Вы не поверите, но у некоторых вендоров getFields() вызывает ВОТ ЭТО.
                    // Иногда я всерьез задумываюсь, правильно ли я поступил, выбрав Android в качестве платформы разработки.
                    throw new JSONException(e.getMessage());
                }
            }
            return object;
        }

        /**
     * Parses array from given JSONArray.
     * Supports parsing of primitive types and {@link com.vk.sdk.api.model.VKApiModel} instances.
     * @param array JSONArray to parse
     * @param arrayClass type of array field in class.
     * @return object to set to array field in class
     * @throws JSONException if given array have incompatible type with given field.
     */
        private static object parseArrayViaReflection(JSONArray array, Class arrayClass)  {
            object result = Array.newInstance(arrayClass.getComponentType(), array.length());
            Class<?> subType = arrayClass.getComponentType();
            for (int i = 0; i < array.length(); i++) {
                try {
                    object item = array.opt(i);
                    if(VKApiModel.class.isAssignableFrom(subType) && item instanceof JObject) {
                        VKApiModel model = (VKApiModel) subType.newInstance();
                        item = model.parse((JObject) item);
                    }
                    Array.set(result, i, item);
                } catch (InstantiationException e) {
                    throw new JSONException(e.getMessage());
                } catch (IllegalAccessException e) {
                    throw new JSONException(e.getMessage());
                } catch (IllegalArgumentException e) {
                    throw new JSONException(e.getMessage());
                }
            }
            return result;
        }
    }
}
