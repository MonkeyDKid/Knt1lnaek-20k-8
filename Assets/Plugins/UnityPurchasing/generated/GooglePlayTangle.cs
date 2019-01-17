#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("MjW6Jkz/+Uqub0JSUDCZ9YplB0f9a8Gj/N1i7w8UMgAHcb+iUwQ/F2k3nZ00W4x7nabZaJidTv5ZUS/waBMC8d4YBSn7TAmRChAxG9EbgygqDdTN4fdFRfetIM/EqB4PHvSWeZJTobgtS2Qos6UJJRJ/c3xx+XvOO8ZtteiTTPw02V/i287E3Dfl/9lfZXTfIB8hx9Ozb5daZ6M57YUK7gS7JXod1A/i2VzdzV91SLvfb2H6Rfd0V0V4c3xf8z3zgnh0dHRwdXb1vJY7Wa1COZUwtVCH/F/bszGbK/d0enVF93R/d/d0dHX8gQ9YdgKlpqZtyvBnTml/7UXNk9ruCGnYApWo8xzUPmo7aGGDgJLd76Kkca2KbH7n/oJxnlVITnd2dHV0");
        private static int[] order = new int[] { 10,5,2,9,6,9,13,7,8,10,12,12,13,13,14 };
        private static int key = 117;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
