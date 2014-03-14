using Vk.SDK;

public class VKModelOperation : VKJsonOperation {
	protected readonly VKParser mParser;
    public object parsedModel;

    /**
     * Create new model operation
     * @param uriRequest Prepared request
     * @param modelClass Model for parsing response
     */
    public VKModelOperation(HttpUriRequest uriRequest,System.Type modelClass) {
        super(uriRequest);
        mParser = new VKDefaultParser(modelClass);
    }
    /**
     * Create new model operation
     * @param uriRequest Prepared request
     * @param parser Parser for create response
     */
    public VKModelOperation(HttpUriRequest uriRequest, VKParser parser) {
        super(uriRequest);
        mParser = parser;
    }

    
    protected bool postExecution() {
        if (!super.postExecution())
            return false;

        if (mParser != null) {
            try {
                JObject response = getResponseJson();
                parsedModel = mParser.createModel(response);
                return true;
            } catch (Exception e) {
                if (VKSdk.DEBUG)
                    e.printStackTrace();
            }
        }
        return false;
    }
}
