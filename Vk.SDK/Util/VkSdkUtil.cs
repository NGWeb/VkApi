using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.SDK.Util
{
 public class VKUtil {
    /**
     * Breaks key=value&key=value string to map
     *
     * @param queryString string to explode
     * @return Key-value map of passed string
     */
    public static Map<String, String> explodeQueryString(String queryString) {
        String[] keyValuePairs = queryString.split("&");
        HashMap<String, String> parameters = new HashMap<String, String>(keyValuePairs.length);

        for (String keyValueString : keyValuePairs) {
            String[] keyValueArray = keyValueString.split("=");
            parameters.put(keyValueArray[0], keyValueArray[1]);
        }
        return parameters;
    }

    /**
     * Reads content of file, and returns result as string
     *
     * @param filename path to file
     * @return Contents of file
     * @throws IOException
     */
    public static String fileToString(String filename) throws IOException {
        BufferedReader reader = new BufferedReader(new FileReader(filename));
        StringBuilder builder = new StringBuilder();
        String line;

        // For every line in the file, append it to the string builder
        while ((line = reader.readLine()) != null) {
            builder.append(line);
        }
        reader.close();

        return builder.toString();
    }

    /**
     * Saves passed string to file
     *
     * @param filename      path to file
     * @param stringToWrite string to save
     */
    public static void stringToFile(String filename, String stringToWrite) {
        try {
            BufferedWriter writer = new BufferedWriter(new FileWriter(filename));
            writer.write(stringToWrite);
            writer.flush();
            writer.close();
        } catch (Exception ignored) {
        }
    }

    /**
     * Returns md5 hash of string
     *
     * @param s string to hash
     * @return md5 hash
     */
    public static String md5(final String s) {
        try {
            // Create MD5 Hash
            MessageDigest digest = MessageDigest.getInstance("MD5");
            digest.update(s.getBytes());
            byte messageDigest[] = digest.digest();

            // Create Hex String
            StringBuilder hexString = new StringBuilder();
            for (byte aMessageDigest : messageDigest) {
                String h = Integer.toHexString(0xFF & aMessageDigest);
                while (h.length() < 2)
                    h = "0" + h;
                hexString.append(h);
            }
            return hexString.toString();

        } catch (NoSuchAlgorithmException e) {
            if (VKSdk.DEBUG)
                e.printStackTrace();
        }
        return "";
    }

    /**
     * Get current certificate fingerprint
     *
     * @param ctx         context of application
     * @param packageName your package name
     * @return Base64 packed SHA fingerprint of your packet certificate
     */
    public static String[] getCertificateFingerprint(Context ctx, String packageName) {
        try {
	        if (ctx == null || ctx.getPackageManager() == null)
		        return null;
            PackageInfo info = ctx.getPackageManager().getPackageInfo(
                    packageName,
                    PackageManager.GET_SIGNATURES);
	        assert info.signatures != null;
	        String[] result = new String[info.signatures.length];
            int i = 0;
            for (Signature signature : info.signatures) {
                MessageDigest md = MessageDigest.getInstance("SHA");
                md.update(signature.toByteArray());
//                result[i++] = Base64.encodeToString(md.digest(), Base64.DEFAULT);
                result[i++] = toHex(md.digest());
            }
            return result;
        } catch (Exception e) {
            return null;
        }
    }

    private static String toHex(byte[] bytes) {
        BigInteger bi = new BigInteger(1, bytes);
        return String.format("%0" + (bytes.length << 1) + "X", bi);
    }

    /**
     * Builds map from list of strings
     *
     * @param args key-value pairs for build a map. Must be a multiple of 2
     * @return Result map. If args not multiple of 2, last argument will be ignored
     */
    public static Map<String, Object> mapFrom(Object... args) {
        if (args.length % 2 != 0) {
            if (VKSdk.DEBUG)
                Log.w("VKUtil", "Params must be paired. Last one is ignored");
        }
        LinkedHashMap<String, Object> result = new LinkedHashMap<String, Object>(args.length / 2);
        for (int i = 0; i + 1 < args.length; i += 2) {
            if (args[i] == null || args[i + 1] == null || !(args[i] instanceof String)) {
                if (VKSdk.DEBUG)
                    Log.e("VK SDK", "Error while using mapFrom", new InvalidParameterSpecException("Key and value must be specified. Key must be string"));
                continue;
            }
            result.put((String) args[i], args[i + 1]);
        }
        return result;
    }

    public static VKParameters paramsFrom(Object... args) {
        return new VKParameters(mapFrom(args));
    }

    /**
     * Check if package installed
     *
     * @param context Context of current app
     * @param uri Package of application to check
     * @return true if passed package installed
     */
    public static boolean isAppInstalled(Context context, String uri) {
        PackageManager pm = context.getPackageManager();
        boolean appInstalled;
        try {
            assert pm != null;
            pm.getPackageInfo(uri, PackageManager.GET_ACTIVITIES);
            appInstalled = true;
        } catch (PackageManager.NameNotFoundException e) {
            appInstalled = false;
        }
        return appInstalled;
    }
    /**
     * Check if action available installed
     *
     * @param context Context of current app
     * @param action Package of application to check
     * @return true if passed package installed
     */
    public static boolean isIntentAvailable(Context context, String action) {
        final PackageManager packageManager = context.getPackageManager();
        final Intent intent = new Intent(action);
        assert packageManager != null;
        List<ResolveInfo> list =
                packageManager.queryIntentActivities(intent,
                        PackageManager.MATCH_DEFAULT_ONLY);
        return list.size() > 0;
    }

    public static String getApplicationName(Context ctx) {
        ApplicationInfo ai;
        try {
            Context appContext = ctx.getApplicationContext();
            assert appContext != null;
            final PackageManager pm = appContext.getPackageManager();
            assert pm != null;
            ai = pm.getApplicationInfo(ctx.getPackageName(), 0);
            return (String) (ai != null ? pm.getApplicationLabel(ai) : "(unknown)");
        } catch (Exception ignored) {
        }
        return null;
    }
}
}
