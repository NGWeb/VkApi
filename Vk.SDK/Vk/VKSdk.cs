#region usings

using System;
using System.Collections.Generic;

#endregion

namespace Vk.SDK.Vk
{
    public class VKSdk
    {
        public static readonly bool DEBUG = true;

        private static readonly Lazy<VKSdk> sInstance = new Lazy<VKSdk>(() => new VKSdk());

        private VKAccessToken mAccessToken;

        private VKSdkListener mListener;

        private VKSdk()
        {
        }

        public static VKSdk instance()
        {
            return sInstance.Value;
        }

        /**
     * Initialize SDK with responder for global SDK events
     *
     * @param listener responder for global SDK events
     * @param appId    your application id (if you haven't, you can create standalone application here https://vk.com/editapp?act=create )
     */

        public static void initialize(string appId)
        {
            if (appId == null)
            {
                throw new Exception("Application ID cannot be null");
            }
        }

        /**
     * Initialize SDK with responder for global SDK events and custom token key
     * (e.g., saved from other source or for some test reasons)
     *
     * @param listener responder for global SDK events
     * @param appId    your application id (if you haven't, you can create standalone application here https://vk.com/editapp?act=create )
     * @param token    custom-created access token
     */

        public static void initialize(string appId, VKAccessToken token)
        {
            initialize(appId);
            sInstance.Value.mAccessToken = token;
            sInstance.Value.performTokenCheck(token, true);
        }

        /**
     * Returns current VK SDK listener
     *
     * @return Current sdk listener
     */

        public VKSdkListener sdkListener()
        {
            return sInstance.Value.mListener;
        }

        /**
     * Sets current VK SDK listener
     *
     * @param newListener listener for SDK
     */

        public void setSdkListener(VKSdkListener newListener)
        {
            sInstance.Value.mListener = newListener;
        }

        /**
     * Pass data of onActivityResult() function here
     *
     * @param resultCode result code of activity result
     * @param result     intent passed by activity
     * @return If SDK parsed activity result properly, returns true. You can return from onActivityResult(). Otherwise, returns false.
     */

        private static void checkAndSetToken(Dictionary<string, string> tokenParams, bool renew)
        {
            VKAccessToken token = VKAccessToken.TokenFromParameters(tokenParams);
            if (token == null || token.accessToken == null)
            {
                VKError error = new VKError(tokenParams);
                setAccessTokenError(error);
            }
            else
            {
                setAccessToken(token, renew);
            }
        }

        /**
     * Set API token to passed
     *
     * @param token token must be used for API requests
     * @param renew flag indicates token renewal
     */

        public static void setAccessToken(VKAccessToken token, bool renew)
        {
            sInstance.Value.mAccessToken = token;

            if (sInstance.Value.mListener != null)
            {
                if (!renew)
                {
                    sInstance.Value.mListener.onReceiveNewToken(token);
                }
                else
                {
                    sInstance.Value.mListener.onRenewAccessToken(token);
                }
            }
        }

        /**
     * Returns token for API requests
     *
     * @return Received access token or null, if user not yet authorized
     */

        public static VKAccessToken getAccessToken()
        {
            if (sInstance.Value.mAccessToken != null)
            {
                if (sInstance.Value.mAccessToken.IsExpired() && sInstance.Value.mListener != null)
                {
                    sInstance.Value.mListener.onTokenExpired(sInstance.Value.mAccessToken);
                }
                return sInstance.Value.mAccessToken;
            }

            return null;
        }

        /**
     * Notify SDK that user denied login
     *
     * @param error description of error while authorizing user
     */

        public static void setAccessTokenError(VKError error)
        {
            sInstance.Value.mAccessToken = null;

            if (sInstance.Value.mListener != null)
            {
                sInstance.Value.mListener.onAccessDenied(error);
            }
        }

        private bool performTokenCheck(VKAccessToken token, bool isUserToken)
        {
            if (token != null)
            {
                if (token.IsExpired())
                {
                    mListener.onTokenExpired(token);
                }
                else if (token.accessToken != null)
                {
                    //           if (isUserToken) mListener.onAcceptUserToken(token);
                    return true;
                }
                else
                {
                    VKError error = new VKError(VKError.VK_API_CANCELED);
                    error.errorMessage = "User token is invalid";
                    mListener.onAccessDenied(error);
                }
            }
            return false;
        }

        public static bool wakeUpSession(VKAccessToken token)
        {
            if (sInstance.Value.performTokenCheck(token, false))
            {
                sInstance.Value.mAccessToken = token;
                return true;
            }
            return false;
        }

        public static void logout()
        {
            throw new NotImplementedException();
            //CookieSyncManager.createInstance(VKUIHelper.getTopActivity());
            //CookieManager cookieManager = CookieManager.getInstance();
            //cookieManager.removeAllCookie();

            //sInstance.mAccessToken = null;
            //VKAccessToken.removeTokenAtKey(VKUIHelper.getTopActivity(), VK_SDK_ACCESS_TOKEN_PREF_KEY);
        }

        public static bool isLoggedIn()
        {
            return sInstance.Value.mAccessToken != null && !sInstance.Value.mAccessToken.IsExpired();
        }
    }
}