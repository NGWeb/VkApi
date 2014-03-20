#region usings

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Text;
using Vk.SDK.Util;

#endregion

namespace Vk.SDK.Http
{
    public class RequestFactory /*: HttpClient*/
    {
        private static readonly Lazy<RequestFactory> SInstance = new Lazy<RequestFactory>(() => new RequestFactory());
        /**
     * Default constructor from basic class
     *
     * @param conman The connection manager
     * @param params The parameters
     */

        private RequestFactory( /*ClientConnectionManager conman, HttpParams param*/)
        {
            // super(conman, param);
        }

        /**
     * Creates the http client (if need). Returns reusing client
     *
     * @return Prepared client used for API requests loading
     */

        public static RequestFactory Client
        {
            get { return SInstance.Value; }
        }

        /**
     * Prepares new "normal" request from VKRequest
     *
     * @param vkRequest Request, created for some method
     * @return Prepared request for creating VKHttpOperation
     */

        public static WebRequest RequestWithVkRequest(AbstractRequest vkRequest)
        {
            WebRequest request = null;
            VKParameters preparedParameters = vkRequest.GetPreparedParameters();
            var urlstringBuilder = new StringBuilder();
            urlstringBuilder.AppendFormat("http{0}://api.vk.com/method/{1}", vkRequest.secure ? "s" : "",
                vkRequest.methodName);
            switch (vkRequest.httpMethod)
            {
                case AbstractRequest.HttpMethod.GET:
                    if (preparedParameters.Count > 0)
                    {
                        urlstringBuilder.Append("?").Append(VKstringJoiner.joinUriParams(preparedParameters));
                    }
                    request = WebRequest.Create(urlstringBuilder.ToString());
                    break;

                case AbstractRequest.HttpMethod.POST:
                    var post = WebRequest.Create(urlstringBuilder.ToString());
                    request.Method = "POST";
                    var pairs = new Dictionary<string, object>(preparedParameters.Count);
                    foreach (var entry in preparedParameters)
                    {
                        object value = entry.Value;
                        if (value is Collection<object>)
                        {
                            var values = (List<object>) value;
                            foreach (object v in values)
                            {
                                // This will add a parameter for each value in the Collection/List
                                pairs.Add(string.Format("{0}[]", entry.Key), v == null ? null : Convert.ToString(v));
                            }
                        }
                        else
                        {
                            pairs.Add(entry.Key, value == null ? null : Convert.ToString(value));
                        }
                    }
                    var boundary = "-----------------------------28520690214962";
                    var newLine = Environment.NewLine;
                    var propFormat = boundary + newLine +
                                     "Content-Disposition: form-data; name=\"{0}\"" + newLine + newLine +
                                     "{1}" + newLine + newLine;

                    using (var reqStream = post.GetRequestStream())
                    {
                        var reqWriter = new StreamWriter(reqStream);
                        StringBuilder bilBuilder = new StringBuilder();

                        foreach (var pair in pairs)
                        {
                            bilBuilder.AppendFormat(propFormat, pair.Key, pair.Value);
                        }
                        reqWriter.Write(bilBuilder.ToString());
                        reqWriter.Write(boundary + "--");
                        reqWriter.Flush();
                    }

                    request = post;

                    break;
            }
            Dictionary<string, string> defaultHeaders = getDefaultHeaders();
            foreach (var key in defaultHeaders)
            {
                request.Headers.Add(key.Key, key.Value);
            }

            return request;
        }

        public static WebRequest FileUploadRequest(string uploadUrl, params FileInfo[] files)
        {
            WebRequest post = WebRequest.Create(uploadUrl);
            post.Method = "POST";
            var e = new VKMultipartEntity(files);
            e.writeTo(post.GetRequestStream());
            return post;
        }

        /**
     * Returns Dictionary of default headers for any request
     *
     * @return Dictionary of default headers
     */

        private static Dictionary<string, string> getDefaultHeaders()
        {
            return new Dictionary<string, string>();
          //  return new Dictionary<string, string> {{"Accept-Encoding", "gzip"}};
        }
    }
}