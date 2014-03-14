using System.Collections.Generic;
using Vk.SDK.model;
using Vk.SDK.Vk;

public abstract class VKApiArray<T> : VKApiModel where T:VKApiModel {
    private List<T> items;
    private int count;

    
    public VKApiModel parse(JSONObject object) {
        try {
            JSONArray jsonArray;
            if ((jsonArray = object.optJSONArray("response")) == null)
            {
                object    = object.getJSONObject("response");
                count     = object.getInt("count");
                jsonArray = object.getJSONArray("items");
            }
            parse(jsonArray);

        } catch (JSONException e) {
            if (VKSdk.DEBUG)
                e.printStackTrace();
        }
        fields = object;
        return this;
    }
    public void parse(JSONArray jsonArray) {
        items = new List<T>(jsonArray.length());
        for (int i = 0; i < jsonArray.length(); i++) {
            try {
                items.add(parseNextObject(jsonArray.getJSONObject(i)));
            } catch (JSONException e) {
                if (VKSdk.DEBUG)
                    e.printStackTrace();
            }
        }
        if (count == 0)
            count = items.size();
    }

    protected T parseNextObject(JSONObject object) {
        try {
            T model = createObject();
            model.parse(object);
            return model;
        } catch (Exception ignored)
        {
            return null;
        }
    }
    protected abstract T createObject();

    public T get(int index) {
        if (items == null) return null;
        return items.get(index);
    }

    public int size() { return count; }
}
