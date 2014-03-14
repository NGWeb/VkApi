using System;
using Vk.SDK.model;
using Vk.SDK.Vk;

namespace Vk.SDK
{
    public class VKDefaultParser : VKParser {
        private readonly Class<? : VKApiModel> mModelClass;
        public VKDefaultParser(Class<? : VKApiModel> objectModel) {
            mModelClass = objectModel;
        }
    
        public object createModel(JObject jsobject) {
            try {
                VKApiModel model = mModelClass.newInstance();
                model.parse(jsobject);
                return model;
            } catch (Exception e) {
                if (VKSdk.DEBUG)
                    e.printStackTrace();
            }
            return null;
        }
    }
}
