using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Vk.SDK.Util
{

/**
 * Helper class for join collections to strings
 */
    public class VKstringJoiner
    {
    /**
     * Joins array of strings to one string with glue
     *
     * @param what Array of string to join
     * @param glue Glue for joined strings
     * @return Joined string
     */
    public static String join(String[] what, String glue) {
        return join(what.ToList(), glue);
    }

    /**
     * Joins some collection to string with glue
     *
     * @param what Collection to join
     * @param glue Glue for joined strings
     * @return Joined string
     */
    public static String join(IEnumerable<string> what, String glue) {
        return string.Join(glue, what);
    }

    /**
     * Join parameters map into string, usually query string
     *
     * @param queryParams Map to join
     * @param isUri       Indicates that value parameters must be uri-encoded
     * @return Result query string, like k=v&k1=v1
     */
    public static String joinParams(Dictionary<String, Object> queryParams, bool isUri) {
        var parameters = new List<string>(queryParams.Count());
        parameters.AddRange(queryParams.Select(entry => String.Format("{0}={1}", entry.Key, isUri ? HttpUtility.UrlEncode(Convert.ToString(entry.Value)) : Convert.ToString(entry.Value))));
        return join(parameters, "&");
    }

    /**
     * Join parameters from map without URI-encoding
     *
     * @param queryParams Map to join
     * @return Joined string
     */
    public static String joinParams(Dictionary<String, Object> queryParams) {
        return joinParams(queryParams, false);
    }

    /**
     * Join parameters from map with URI-encoding
     *
     * @param queryParams Map to join
     * @return Joined string
     */
    public static String joinUriParams(Dictionary<String, Object> queryParams) {
        return joinParams(queryParams, true);
    }
}
}
