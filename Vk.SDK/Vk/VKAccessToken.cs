#region usings

using System;
using System.Collections.Generic;
using Vk.SDK.Util;

#endregion

namespace Vk.SDK.Vk
{
    public class VKAccessToken
    {
        public static readonly string ACCESS_TOKEN = "access_token";
        public static readonly string EXPIRES_IN = "expires_in";
        public static readonly string USER_ID = "user_id";
        public static readonly string SECRET = "secret";
        public static readonly string HTTPS_REQUIRED = "https_required";
        public static readonly string CREATED = "created";
        /**
     * string token for use in request parameters
     */
        public string accessToken = null;
        public long created = 0;
        /**
     * Time when token expires
     */
        public int expiresIn = 0;
        /**
     * Current user id for this token
     */
        /**
     * If user sets "Always use HTTPS" setting in his profile, it will be true
     */
        public bool httpsRequired = false;
        public string secret = null;
        public string userId = null;

        /**
     * Indicates time of token creation
     */

        /**
          * Removes token from preferences with specified key
          * @param ctx      Context for preferences
          * @param tokenKey Key for saving settings
          */

        private VKAccessToken()
        {
        }

        public void saveTokenToFile(string filePath)
        {
            VKUtil.stringToFile(filePath, serialize());
        }

        /**
     * Serialize token into string
     *
     * @return Serialized token string as query-string
     */

        protected string serialize()
        {
            VKParameters parameters = new VKParameters();
            parameters.Add(ACCESS_TOKEN, accessToken);
            parameters.Add(EXPIRES_IN, expiresIn);
            parameters.Add(USER_ID, userId);
            parameters.Add(CREATED, created);

            if (secret != null)
            {
                parameters.Add(SECRET, secret);
            }
            if (httpsRequired)
            {
                parameters.Add(HTTPS_REQUIRED, "1");
            }

            return VKstringJoiner.joinParams(parameters);
        }

        /**
     * Retrieve token from key-value query string
     *
     * @param urlstring string that contains URL-query part with token. E.g. access_token=eee&expires_in=0...
     * @return parsed token
     */

        public static VKAccessToken TokenFromUrlstring(string urlstring)
        {
            if (urlstring == null)
                return null;
            Dictionary<string, string> parameters = VKUtil.explodeQueryString(urlstring);

            return TokenFromParameters(parameters);
        }

        /**
     * Retrieve token from key-value map
     *
     * @param parameters map that contains token info
     * @return Parsed token
     */

        public static VKAccessToken TokenFromParameters(Dictionary<string, string> parameters)
        {
            if (parameters == null || parameters.Count == 0)
                return null;
            
            var token = new VKAccessToken();
            token.accessToken = parameters[ACCESS_TOKEN];
            token.expiresIn = Convert.ToInt32(parameters[EXPIRES_IN]);
            token.userId = parameters[USER_ID];
            //token.secret = parameters[SECRET];
            token.httpsRequired = false;

            if (parameters.ContainsKey(HTTPS_REQUIRED))
            {
                token.httpsRequired = parameters[HTTPS_REQUIRED] == "1";
            }
            if (parameters.ContainsKey(CREATED))
            {
                token.created = Convert.ToInt64(parameters[CREATED]);
            }
            else
            {
                token.created = DateTime.Now.Millisecond;
            }
            return token;
        }

        /**
     * Checks expiration time of token and returns result.
     *
     * @return true if token has expired, false otherwise.
     */

        public bool IsExpired()
        {
            return expiresIn > 0 && expiresIn * 1000 + created < DateTime.Now.Millisecond;
        }
    }
}