using System;
using System.Collections.Generic;
using Vk.SDK;
using Vk.SDK.Vk;

namespace Vk.SDK
{
    public class VKError : VKObject
    {
        public static readonly int VK_API_ERROR = -101;
        public static readonly int VK_API_CANCELED = -102;
        public static readonly int VK_API_REQUEST_NOT_PREPARED = -103;
        public static readonly int VK_API_JSON_FAILED = -104;
        public static readonly int VK_API_REQUEST_HTTP_FAILED = -105;

        /**
     * Contains system HTTP error
     */
        public Exception httpError;
        /**
     * Describes API error
     */
        public VKError apiError;
        /**
     * Request which caused error
     */
        public VKRequest request;
        /**
     * May contains such errors:<br/>
     * <b>HTTP status code</b> if HTTP error occured;<br/>
     * <b>VK_API_ERROR</b> if API error occured;<br/>
     * <b>VK_API_CANCELED</b> if request was canceled;<br/>
     * <b>VK_API_REQUEST_NOT_PREPARED</b> if error occured while preparing request;
     */
        public int errorCode;
        /**
     * API error message
     */
        public string errorMessage;
        /**
     * Reason for authorization fail
     */
        public string errorReason;
        /**
     * API parameters passed to request
     */
        public List<Dictionary<string, string>> requestParams;
        /**
     * Captcha identifier for captcha-check
     */
        public string captchaSid;
        /**
     * Image for captcha-check
     */
        public string captchaImg;
        /**
     * Redirection address if validation check required
     */
        public string redirectUri;

        /**
     * Generate new error with code
     *
     * @param errorCode positive if it's an HTTP error. Negative if it's API or SDK error
     */
        public VKError(int errorCode)
        {
            this.errorCode = errorCode;
        }

        /**
     * Generate API error from JSON
     *
     * @param json Json description of VK API error
     */
        public VKError(JObject json)
        {
            VKError internalError = new VKError(json.getInt(VKApiConst.ERROR_CODE));
            internalError.errorMessage = json.getstring(VKApiConst.ERROR_MSG);
            internalError.requestParams = (List<Dictionary<string, string>>)VKJsonHelper.toList(
            json.getJSONArray(VKApiConst.REQUEST_PARAMS));
            if (internalError.errorCode == 14)
            {
                internalError.captchaImg = json.getstring(VKApiConst.CAPTCHA_IMG);
                internalError.captchaSid = json.getstring(VKApiConst.CAPTCHA_SID);
            }

            this.
        errorCode = VK_API_ERROR;
            this.apiError = internalError;
        }

        /**
         * Generate API error from HTTP-query
         *
         * @param queryParams key-value parameters
         */
        public VKError(Dictionary<string, string> queryParams)
        {
            this.errorCode = VK_API_ERROR;
            this.errorReason = queryParams.get("error_reason");
            this.errorMessage = Uri.decode(queryParams.get("error_description"));
        }

        /**
         * Repeats failed captcha request with user entered answer to captcha
         *
         * @param userEnteredCode answer for captcha
         */
        public void answerCaptcha(string userEnteredCode) {
        VKParameters parameters = new VKParameters();
        parameters.Add(VKApiConst.CAPTCHA_SID, captchaSid);
        parameters.Add(VKApiConst.CAPTCHA_KEY, userEnteredCode);
        request.addExtraParameters(parameters);
        request.repeat();
    }
        public static VKError getRegisteredError(long requestId)
        {
            return (VKError)getRegisteredObject(requestId);
        }
    }
}