#if UNITY_IOS || UNITY_ANDROID

using System;
using System.Runtime.InteropServices;

namespace HelpshiftExample
{
    public class HelpshiftXExampleDebug
    {
        private static HelpshiftXExampleDebug instance = null;

#if UNITY_IOS
        [DllImport("__Internal")]
        private static extern void HsPurge();
#endif
        public void Purge()
        {
#if UNITY_IOS
            HsPurge();
#endif
        }

        /// <summary>
        /// Main function which should be used to get the HelpshiftXExampleDebug instance.
        /// </summary>
        /// <returns>Singleton HelpshiftXExampleDebug instance</returns>
        public static HelpshiftXExampleDebug GetInstance()
        {
#if UNITY_IOS
            if (instance == null)
            {
                instance = new HelpshiftXExampleDebug();
            }
            return instance;
#else
            return null;
#endif
        }
    }
}
#endif
