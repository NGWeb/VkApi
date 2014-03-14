/**
 * Presents VK API access token that used for loading API methods and other stuff.
 */

using System;
using System.Collections.Generic;

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
        /**
     * Time when token expires
     */
        public int expiresIn = 0;
        /**
     * Current user id for this token
     */
        public string userId = null;
        /**
     * User secret to sign requests (if nohttps used)
     */
        public string secret = null;
        /**
     * If user sets "Always use HTTPS" setting in his profile, it will be true
     */
        public bool httpsRequired = false;

        /**
     * Indicates time of token creation
     */
        public long created = 0;

        /**
     * Save token into specified file
     *
     * @param filePath path to file with saved token
     */
        public void saveTokenToFile(string filePath)
        {
            VKUtil.stringToFile(filePath, serialize());
        }

        /**
          * Removes token from preferences with specified key
          * @param ctx      Context for preferences
          * @param tokenKey Key for saving settings
          */
        private VKAccessToken()
        {
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
        public static VKAccessToken tokenFromUrlstring(string urlstring)
        {
            if (urlstring == null)
                return null;
            Dictionary<string, string> parameters = VKUtil.explodeQuerystring(urlstring);

            return tokenFromParameters(parameters);
        }

        /**
     * Retrieve token from key-value map
     *
     * @param parameters map that contains token info
     * @return Parsed token
     */
        public static VKAccessToken tokenFromParameters(Dictionary<string, string> parameters)
        {
            if (parameters == null || parameters.Count == 0)
                return null;
            var token = new VKAccessToken();
            try
            {
                token.accessToken = parameters[ACCESS_TOKEN];
                token.expiresIn = Convert.ToInt32(parameters[EXPIRES_IN]);
                token.userId = parameters[USER_ID];
                token.secret = parameters[SECRET];
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
            catch (Exception e)
            {
                return null;
            }
        }

        /**
          * Retrieve token from file. Token must be saved into file with saveTokenToFile method
          *
          * @param filePath path to file with saved token
          * @return Previously saved token or null
          */
        public static VKAccessToken tokenFromFile(string filePath)
        {
            try
            {
                string data = VKUtil.fileTostring(filePath);
                return tokenFromUrlstring(data);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /**
     * Checks expiration time of token and returns result.
     *
     * @return true if token has expired, false otherwise.
     */
        public bool isExpired()
        {
            return expiresIn > 0 && expiresIn * 1000 + created < System.currentTimeMillis();
        }
    }
}