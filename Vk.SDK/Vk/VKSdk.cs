using System;
using System.Collections.Generic;

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
    public void initialize(string appId) {
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
    public static void initialize(string appId, VKAccessToken token) {
        sInstance.mAccessToken = token;
        sInstance.performTokenCheck(token, true);
    }

    /**
     * Starts authorization process. If VKapp is available in system, it will opens and requests access from user.
     * Otherwise UIWebView with standard UINavigationBar will be opened for access request.
     *
     * @param scope array of permissions for your applications. All permissions you can
     */
    public static void authorize(params string[] scope) {
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
