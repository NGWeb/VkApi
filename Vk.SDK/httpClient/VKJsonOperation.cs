using System.Net;
using Vk.SDK.httpClient;

public class VKJsonOperation : VKHttpOperation {
	private JSONObject mResponseJson;

    /**
     * Create new operation with request
     * @param uriRequest Request prepared manually or with VKHttpClient
     */
    public VKJsonOperation(WebRequest uriRequest):base(uriRequest) {}
    

    /**
     * Generate JSON-response for current operation
     * @return Parsed JSON object from response string
     */
    public JSONObject getResponseJson() {
        if (mResponseJson == null) {
            string response = getResponsestring();
            if (response == null)
                return null;
            try {
                mResponseJson = new JSONObject(response);
            } catch (Exception e) {
                mLastException = e;
            }
        }
        return mResponseJson;
    }

    
    protected bool postExecution() {
        if (!super.postExecution())
            return false;
        mResponseJson = getResponseJson();
        return true;
    }

    /**
     * Not available for JSONOperation
     * @deprecated This method is deprecated for this class
     * @param listener Listener subclasses VKHTTPOperationCompleteListener
     */
    
    public void setHttpOperationListener(VKHTTPOperationCompleteListener listener) {
        throw new UnsupportedOperationException("This operation is now available for this class");
    }

    /**
     * Sets that json operation listener
     * @param listener Listener object for that operation
     */
    public void setJsonOperationListener(readonly VKJSONOperationCompleteListener listener) {
        if (listener == null) {
            super.setCompleteListener(null);
            return;
        }

        this.setCompleteListener(new VKOperationCompleteListener() {
            
            public void onComplete() {
                if (mLastException != null) {
                    listener.onError(VKJsonOperation.this, generateError(mLastException));
                } else {
                    listener.onComplete(VKJsonOperation.this, mResponseJson);
                }
            }
        });
    }

    /**
     * Class representing operation listener for VKJsonOperation
     */
    public static abstract class VKJSONOperationCompleteListener : VKAbstractCompleteListener<VKJsonOperation, JSONObject> {
        public void onComplete(VKJsonOperation operation, JSONObject response) {
        }

        public void onError(VKJsonOperation operation, VKError error) {
        }
    }
}
