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
    public class RequestFactory /*: HttpClient*/ : IRequestFactory
    {
        private readonly IRequestCreator _creator;

        public RequestFactory(IRequestCreator creator)
        {
            _creator = creator;
            // super(conman, param);
        }

        public WebRequest RequestWithVkRequest(AbstractRequest vkRequest)
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
                    request = _creator.Create(urlstringBuilder.ToString());
                    break;

                case AbstractRequest.HttpMethod.POST:
                    var post = _creator.Create(urlstringBuilder.ToString());
                    request.Method = "POST";
                    var pairs = new Dictionary<string, object>(preparedParameters.Count);
                    foreach (var entry in preparedParameters)
                    {
                        object value = entry.Value;
                        if (value is Collection<object>)
                        {
                            var values = (List<object>)value;
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
            Dictionary<string, string> defaultHeaders = GetDefaultHeaders();
            foreach (var key in defaultHeaders)
            {
                request.Headers.Add(key.Key, key.Value);
            }

            return request;
        }

        public WebRequest FileUploadRequest(string uploadUrl, params FileInfo[] files)
        {
            WebRequest post = _creator.Create(uploadUrl);
            post.Method = "POST";
            var e = new VKMultipartEntity(files);
            e.writeTo(post.GetRequestStream());
            return post;
        }

        private Dictionary<string, string> GetDefaultHeaders()
        {
            return new Dictionary<string, string>();
            //  return new Dictionary<string, string> {{"Accept-Encoding", "gzip"}};
        }
    }
}