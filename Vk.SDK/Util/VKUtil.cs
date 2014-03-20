#region usings

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

#endregion

namespace Vk.SDK.Util
{
    public class VKUtil
    {
        /**
         * Breaks key=value&key=value string to map
         *
         * @param queryString string to explode
         * @return Key-value map of passed string
         */

        public static Dictionary<String, String> explodeQueryString(String queryString)
        {
            var keyValuePairs = queryString.Split('&');
            return
                keyValuePairs.Select(keyValueString => keyValueString.Split('='))
                    .ToDictionary(keyValueArray => keyValueArray[0], keyValueArray => keyValueArray[1]);
        }

        /**
         * Reads content of file, and returns result as string
         *
         * @param filename path to file
         * @return Contents of file
         * @throws IOException
         */

        public static String fileToString(String filename)
        {
            return File.ReadAllText(filename);
        }

        /**
         * Saves passed string to file
         *
         * @param filename      path to file
         * @param stringToWrite string to save
         */

        public static void stringToFile(String filename, String stringToWrite)
        {
            StreamWriter writer = new StreamWriter(new FileStream(filename, FileMode.OpenOrCreate));
            writer.Write(stringToWrite);
        }

        /**
         * Returns md5 hash of string
         *
         * @param s string to hash
         * @return md5 hash
         */

        public static string md5(String s)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(s);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        /**
         * Get current certificate fingerprint
         *
         * @param ctx         context of application
         * @param packageName your package name
         * @return Base64 packed SHA fingerprint of your packet certificate
         */

        private static String toHex(byte[] bytes)
        {
            var bi = BitConverter.ToInt64(bytes, 1);
            return String.Format("{0}" + (bytes.Count() << 1) + "X", bi);
        }

        /**
         * Builds map from list of strings
         *
         * @param args key-value pairs for build a map. Must be a multiple of 2
         * @return Result map. If args not multiple of 2, last argument will be ignored
         */

        public static Dictionary<String, Object> mapFrom(params Object[] args)
        {
            if (args.Length%2 != 0)
            {
                throw new ArgumentException("not equal parameter", "args");
                //  if (VKSdk.DEBUG)
                //  Log.w("VKUtil", "Params must be paired. Last one is ignored");
            }
            Dictionary<String, Object> result = new Dictionary<string, object>();
            for (int i = 0; i + 1 < args.Count(); i += 2)
            {
                if (args[i] == null || args[i + 1] == null || !(args[i] is string))
                {
                    //if (VKSdk.DEBUG)
                    //  Log.e("VK SDK", "Error while using mapFrom", new Exception("Key and value must be specified. Key must be string"));
                    continue;
                }
                result.Add((String) args[i], args[i + 1]);
            }
            return result;
        }

        public static VKParameters paramsFrom(params Object[] args)
        {
            return new VKParameters(mapFrom(args));
        }


        public static string getApplicationName()
        {
            return ConfigurationManager.AppSettings.Get("AppName");
        }
    }
}