namespace Vk.SDK.Vk
{
    public abstract class VKSdkListener {
        /**
	 * Calls when user must perform captcha-check
	 * 
	 * @param captchaError error returned from API. You can load captcha image from
	 * <b>captchaImg</b> property. After user answered current
	 * captcha, call answerCaptcha: method with user entered answer.
	 */
        public abstract void onCaptchaError(VKError captchaError);

        /**
	 * Notifies listener about existing token has expired
	 * 
	 * @param expiredToken old token that has expired
	 */
        public abstract void onTokenExpired(VKAccessToken expiredToken);

        /**
	 * Notifies listener about user authorization cancelation
	 * 
	 * @param authorizationError error that describes authorization error
	 */
        public abstract void onAccessDenied(VKError authorizationError);

        /**
	 * Notifies listener about receiving new access token
	 * 
	 * @param newToken new token for API requests
	 */
        public void onReceiveNewToken(VKAccessToken newToken) {
        }

        /**
	 * Notifies listener about receiving predefined token
	 * 
	 * @param token used token for API requests
	 */
        public void onAcceptUserToken(VKAccessToken token) {
        }

        /**
	 * Notifies listener about renewing access token (for example, user passed validation)
	 *
	 * @param token used token for API requests
	 */
        public void onRenewAccessToken(VKAccessToken token) {
        }

    }
}
