using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Text;
using Vk.SDK.Util;
using Vk.SDK.Vk;

namespace Vk.SDK.httpClient
{
    public class VKHttpClient : HttpClient
    {

        private static Lazy<VKHttpClient> sInstance = new Lazy<VKHttpClient>(() => new VKHttpClient());
        /**
     * Default constructor from basic class
     *
     * @param conman The connection manager
     * @param params The parameters
     */
        private VKHttpClient(/*ClientConnectionManager conman, HttpParams param*/)
        {
            // super(conman, param);
        }

        /**
     * Creates the http client (if need). Returns reusing client
     *
     * @return Prepared client used for API requests loading
     */
        public static VKHttpClient getClient() {
            if (sInstance == null) {
                SchemeRegistry schemeRegistry = new SchemeRegistry();
                schemeRegistry.register(new Scheme("http",
                    PlainSocketFactory.getSocketFactory(), 80));
                schemeRegistry.register(new Scheme("https",
                    SSLSocketFactory.getSocketFactory(), 443));
                HttpParams parameters = new BasicHttpParams();
                Context ctx = VKUIHelper.getTopActivity();

                try {
                    if (ctx != null)
                    {
                        PackageManager packageManager = ctx.getPackageManager();
                        if (packageManager != null) {
                            PackageInfo info = packageManager.getPackageInfo(ctx.getPackageName(), 0);
                            parameters.setParameter(CoreProtocolPNames.USER_AGENT,
                                string.format(Locale.US,
                                    "%s/%s (%s; Android %d; Scale/%.2f; VK SDK %s; %s)",
                                    VKUtil.getApplicationName(ctx), info.versionName,
                                    Build.MODEL, Build.VERSION.SDK_INT,
                                    ctx.getResources().getDisplayMetrics().density,
                                    VKSdkVersion.SDK_VERSION,
                                    info.packageName));
                        }
                    }
                } catch (Exception ignored) {
                }
                sInstance = new VKHttpClient(new ThreadSafeClientConnManager(params, schemeRegistry),params);
            }
            return sInstance;
        }

        /**
     * Prepares new "normal" request from VKRequest
     *
     * @param vkRequest Request, created for some method
     * @return Prepared request for creating VKHttpOperation
     */
        public static WebRequest RequestWithVkRequest(VKRequest vkRequest)
        {
            WebRequest request = null;
            VKParameters preparedParameters = vkRequest.getPreparedParameters();
            var urlstringBuilder = new StringBuilder();
            urlstringBuilder.AppendFormat("http{0}://api.vk.com/method/{1}", vkRequest.secure ? "s" : "", vkRequest.methodName);
            switch (vkRequest.httpMethod)
            {
                case VKRequest.HttpMethod.GET:
                    if (preparedParameters.Count > 0)
                    {
                        urlstringBuilder.Append("?").Append(VKstringJoiner.joinUriParams(preparedParameters));
                    }
                    request = WebRequest.Create(urlstringBuilder.ToString());
                    break;

                case VKRequest.HttpMethod.POST:
                    WebRequest post = WebRequest.Create(urlstringBuilder.ToString());
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
                    UrlEncodedFormEntity entity = new UrlEncodedFormEntity(pairs, "UTF-8");
                    post.setEntity(entity);

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

        public static WebRequest fileUploadRequest(string uploadUrl, params byte[] files)
        {

            WebRequest post = WebRequest.Create(uploadUrl);
            post.Method = "POST";
            post.setEntity(new VKMultipartEntity(files));
            return post;
        }

        /**
     * Returns Dictionary of default headers for any request
     *
     * @return Dictionary of default headers
     */
        private static Dictionary<string, string> getDefaultHeaders()
        {
            return new Dictionary<string, string> { { "Accept-Encoding", "gzip" } };
        }
    }
}
