using System;

namespace Vk.SDK.Vk
{
    public class VKSdk {

        public static readonly bool DEBUG = true;
        /**
     * Start SDK activity for result with that request code
     */
        public static readonly int VK_SDK_REQUEST_CODE = 0xf228;

        /**
     * Instance of SDK
     */
        private static volatile VKSdk sInstance;

        private static readonly string VK_SDK_ACCESS_TOKEN_PREF_KEY = "VK_SDK_ACCESS_TOKEN_PLEASE_DONT_TOUCH";

        /**
     * Responder for global SDK events
     */
        private VKSdkListener mListener;

        /**
     * Access token for API-requests
     */
        private VKAccessToken mAccessToken;

        /**
     * App id for current application
     */
        private string mCurrentAppId;
        
        private VKSdk() {

        }



        //Context getContext() {
        //    return VKUIHelper.getTopActivity();
        //}

  public static VKSdk instance() {
        return sInstance;
    }

    /**
     * Initialize SDK with responder for global SDK events
     *
     * @param listener responder for global SDK events
     * @param appId    your application id (if you haven't, you can create standalone application here https://vk.com/editapp?act=create )
     */
    public void initialize(VKSdkListener listener, string appId) {
        if (listener == null) {
            throw new Exception("VK SDK listener cannot be null");
        }

        if (appId == null) {
            throw new Exception("Application ID cannot be null");
        }

        // Double checked locking singleton, for thread safety VKSdk.initialize() calls
        if (sInstance == null) {
            lock (this)
            {
                  if (sInstance == null) {
                    sInstance = new VKSdk();
                }
            }
        }

        sInstance.mListener = listener;
        sInstance.mCurrentAppId = appId;
    }

    /**
     * Initialize SDK with responder for global SDK events and custom token key
     * (e.g., saved from other source or for some test reasons)
     *
     * @param listener responder for global SDK events
     * @param appId    your application id (if you haven't, you can create standalone application here https://vk.com/editapp?act=create )
     * @param token    custom-created access token
     */
    public static void initialize(VKSdkListener listener, string appId, VKAccessToken token) {
        initialize(listener, appId);
        sInstance.mAccessToken = token;
        sInstance.performTokenCheck(token, true);
    }

    /**
     * Starts authorization process. If VKapp is available in system, it will opens and requests access from user.
     * Otherwise UIWebView with standard UINavigationBar will be opened for access request.
     *
     * @param scope array of permissions for your applications. All permissions you can
     */
    public static void authorize(string... scope) {
        authorize(scope, false, false);
    }

    /**
     * Defines true VK application fingerprint
     */
    private static readonly string VK_APP_FINGERPRINT = "48761EEF50EE53AFC4CC9C5F10E6BDE7F8F5B82F";
    private static readonly string VK_APP_PACKAGE_ID = "com.vkontakte.android";
    private static readonly string VK_APP_AUTH_ACTION = "com.vkontakte.android.action.SDK_AUTH";

    /**
     * Starts authorization process. If VKapp is available in system, it will opens and requests access from user.
     * Otherwise UIWebView with standard UINavigationBar will be opened for access request.
     *
     * @param scope array of permissions for your applications. All permissions you can
     * @param revoke      if true, user will allow logout (to change user)
     * @param forceOAuth  sdk will use only oauth authorization, through uiwebview
     */
    public static void authorize(string[] scope, bool revoke, bool forceOAuth) {
        try {
            checkConditions();
        } catch (Exception e) {
            if (VKSdk.DEBUG)
                e.printStackTrace();
            return;
        }

        if (scope == null) {
            scope = new string[]{};
        }

        string[] fingerprints = VKUtil.getCertificateFingerprint(sInstance.getContext(),
                VK_APP_PACKAGE_ID);

        readonly Intent intent;

        if (!forceOAuth
                && VKUtil.isAppInstalled(sInstance.getContext(),VK_APP_PACKAGE_ID)
                && VKUtil.isIntentAvailable(sInstance.getContext(), VK_APP_AUTH_ACTION)
                && fingerprints[0].equals(VK_APP_FINGERPRINT)) {
            intent = new Intent(VK_APP_AUTH_ACTION, null);
        } else {
            intent = new Intent(sInstance.getContext(), VKOpenAuthActivity.class);
        }

        intent.putExtra(VKOpenAuthActivity.VK_EXTRA_API_VERSION, VKSdkVersion.API_VERSION);
        intent.putExtra(VKOpenAuthActivity.VK_EXTRA_CLIENT_ID, Integer.parseInt(sInstance.mCurrentAppId));

        if (revoke) {
            intent.putExtra(VKOpenAuthActivity.VK_EXTRA_REVOKE, true);
        }

        intent.putExtra(VKOpenAuthActivity.VK_EXTRA_SCOPE, VKstringJoiner.join(scope, ","));

        if (VKUIHelper.getTopActivity() != null) {
            VKUIHelper.getTopActivity().startActivityForResult(intent, VK_SDK_REQUEST_CODE);
        }
    }

    /**
     * Returns current VK SDK listener
     *
     * @return Current sdk listener
     */
    public VKSdkListener sdkListener() {
        return sInstance.mListener;
    }

    /**
     * Sets current VK SDK listener
     *
     * @param newListener listener for SDK
     */
    public void setSdkListener(VKSdkListener newListener) {
        sInstance.mListener = newListener;
    }

    /**
     * Pass data of onActivityResult() function here
     *
     * @param resultCode result code of activity result
     * @param result     intent passed by activity
     * @return If SDK parsed activity result properly, returns true. You can return from onActivityResult(). Otherwise, returns false.
     */
    public static bool processActivityResult(int resultCode, Intent result) {
        if (result != null && resultCode == Activity.RESULT_OK) {
            if (VKOpenAuthActivity.VK_RESULT_INTENT_NAME.equals(result.getAction())) {
                if (result.hasExtra(VKOpenAuthActivity.VK_EXTRA_TOKEN_DATA)) {
                    string tokenInfo = result.getstringExtra(VKOpenAuthActivity.VK_EXTRA_TOKEN_DATA);
                    Dictionary<string, string> tokenParams = VKUtil.explodeQuerystring(tokenInfo);
	                bool renew = result.getboolExtra(VKOpenAuthActivity.VK_EXTRA_VALIDATION_URL, false);
                    checkAndSetToken(tokenParams, renew);
                } else if (result.getExtras() != null) {
                    setAccessTokenError(new VKError(VKError.VK_API_CANCELED));
                }
                return true;
            }

            if (result.getExtras() != null) {
                Dictionary<string, string> tokenParams = new Dictionary<string, string>();

                for (string key : result.getExtras().keySet()) {
                    tokenParams.put(key, string.valueOf(result.getExtras().get(key)));
                }

                checkAndSetToken(tokenParams, false);
            }
        }

        return false;
    }

	/**
	 * Check new access token and sets it as working token
	 * @param tokenParams params of token
	 * @param renew flag indicates token renewal
	 */
    private static void checkAndSetToken(Dictionary<string, string> tokenParams, bool renew) {
        VKAccessToken token = VKAccessToken.tokenFromParameters(tokenParams);
        if (token == null || token.accessToken == null) {
            VKError error = new VKError(tokenParams);
            setAccessTokenError(error);
        } else {
            setAccessToken(token, renew);
        }
    }

    /**
     * Set API token to passed
     *
     * @param token token must be used for API requests
     * @param renew flag indicates token renewal
     */
    public static void setAccessToken(VKAccessToken token, bool renew) {
        sInstance.mAccessToken = token;

        if (sInstance.mListener != null) {
	        if (!renew) {
                sInstance.mListener.onReceiveNewToken(token);
            } else {
		        sInstance.mListener.onRenewAccessToken(token);
            }
        }
        sInstance.mAccessToken.saveTokenToSharedPreferences(VKUIHelper.getTopActivity(), VK_SDK_ACCESS_TOKEN_PREF_KEY);
    }

    /**
     * Returns token for API requests
     *
     * @return Received access token or null, if user not yet authorized
     */
    public static VKAccessToken getAccessToken() {
        if (sInstance.mAccessToken != null) {
            if (sInstance.mAccessToken.isExpired() && sInstance.mListener != null) {
                sInstance.mListener.onTokenExpired(sInstance.mAccessToken);
            }
            return sInstance.mAccessToken;
        }

        return null;
    }

    /**
     * Notify SDK that user denied login
     *
     * @param error description of error while authorizing user
     */
    public static void setAccessTokenError(VKError error) {
        sInstance.mAccessToken = null;

        if (sInstance.mListener != null) {
            sInstance.mListener.onAccessDenied(error);
        }
    }
    private bool performTokenCheck(VKAccessToken token, bool isUserToken) {
        if (token != null) {
            if (token.isExpired()) {
                mListener.onTokenExpired(token);
            }
            else if (token.accessToken != null) {
                if (isUserToken) mListener.onAcceptUserToken(token);
                return true;
            }
            else {
                VKError error = new VKError(VKError.VK_API_CANCELED);
                error.errorMessage = "User token is invalid";
                    mListener.onAccessDenied(error);
            }
        }
        return false;
    }
    public static bool wakeUpSession() {
        VKAccessToken token = VKAccessToken.tokenFromSharedPreferences(VKUIHelper.getTopActivity(),
                VK_SDK_ACCESS_TOKEN_PREF_KEY);

        if (sInstance.performTokenCheck(token, false)) {
            sInstance.mAccessToken = token;
            return true;
        }
        return false;
    }

    public static void logout() {
        CookieSyncManager.createInstance(VKUIHelper.getTopActivity());
        CookieManager cookieManager = CookieManager.getInstance();
        cookieManager.removeAllCookie();

        sInstance.mAccessToken = null;
        VKAccessToken.removeTokenAtKey(VKUIHelper.getTopActivity(), VK_SDK_ACCESS_TOKEN_PREF_KEY);
    }
    public static bool isLoggedIn() {
        return sInstance.mAccessToken != null && !sInstance.mAccessToken.isExpired();
    }
}
