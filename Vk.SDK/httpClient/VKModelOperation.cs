using System.Net;
using Newtonsoft.Json.Linq;
using Vk.SDK.model;

namespace Vk.SDK.httpClient
{
    public class VKModelOperation<T> : VKAbstractOperation<T> where T:VKApiModel 
    {
        protected readonly VKParser mParser;
        public object parsedModel;

        /**
     * Create new model operation
     * @param uriRequest Prepared request
     * @param modelClass Model for parsing response
     */
        public VKModelOperation(WebRequest uriRequest)
        {
            mParser = new VKDefaultParser<T>();
        }
        /**
     * Create new model operation
     * @param uriRequest Prepared request
     * @param parser Parser for create response
     */
        public VKModelOperation(WebRequest uriRequest, VKParser parser)
        {
            mParser = parser;
        }


        protected bool postExecution()
        {
            if (!base.postExecution())
                return false;

            if (mParser != null)
            {
                JObject response = getResponseJson();
                parsedModel = mParser.CreateModel(response);
                return true;
            }
            return false;
        }

        public override void start()
        {
            throw new System.NotImplementedException();
        }
    }
}
