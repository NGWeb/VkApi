using System;
using Vk.SDK.model;

namespace Vk.SDK.methods
{
    public class VKApiBase {
        /**
     * Selected methods group
     */
        private string mMethodGroup;

        public VKApiBase() {
            string className = this.getClass().getSimpleName();
            if (className == null) {
                throw new ClassCastException("Enclosing classes denied");
            }
            mMethodGroup = className.substring("VKApi".length()).toLowerCase();
        }

      protected  VKRequest prepareRequest(string methodName, VKParameters methodParameters) {
            return prepareRequest(methodName, methodParameters, VKRequest.HttpMethod.GET);
        }

      protected  VKRequest prepareRequest(string methodName, VKParameters methodParameters,
            VKRequest.HttpMethod httpMethod) {
            return prepareRequest(methodName, methodParameters, httpMethod, (VKParser)null);
            }

       protected VKRequest prepareRequest(string methodName, VKParameters methodParameters,VKRequest.HttpMethod httpMethod,System.Type type) {
                return new VKRequest(string.format(Locale.US, "%s.%s", mMethodGroup, methodName),
                    methodParameters, httpMethod, modelClass);
            }
      protected  VKRequest prepareRequest(string methodName, VKParameters methodParameters,VKRequest.HttpMethod httpMethod,Func<JSONObject> responseParser) {
     
    VKRequest result = new VKRequest(string.format(Locale.US, "%s.%s", mMethodGroup, methodName),
                methodParameters, httpMethod);
            result.setResponseParser(responseParser);
           
    return result;
            }
    }
}
