using System;
using UnityEngine;
using System.Collections.Generic;

#if UNITY_ANDROID

namespace HelpshiftExample
{
	public class FirebaseIntegration
	{
		public static void initFirebase()
		{
            Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
                var dependencyStatus = task.Result;
                if (dependencyStatus == Firebase.DependencyStatus.Available)
                {
                    Firebase.FirebaseApp app = Firebase.FirebaseApp.DefaultInstance;

                    // Set a flag here to indicate whether Firebase is ready to use by your app.
                    Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
                    Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;
                }
                else
                {
                    Debug.LogError(System.String.Format(
                      "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                    // Firebase Unity SDK is not safe to use here.
                }
            });
        }

        public static void OnTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token)
        {
            Debug.Log("Received Registration Token: " + token.Token);
            Helpshift.HelpshiftSdk.GetInstance().RegisterPushToken(token.Token);
        }

        public static void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e)
        {
            Debug.Log("Received a new message from: " + e.Message.From);

            IDictionary<string, string> pushData = e.Message.Data;

            /// Check if the notification origin is Helpshift
            if (pushData.ContainsKey("origin") && pushData["origin"].Equals("helpshift"))
            {
                Dictionary<string, object> hsPushData = new Dictionary<string, object>();
                Debug.Log("Received a new message for Helpshift");
                foreach (string key in pushData.Keys)
                {
                    hsPushData.Add(key, pushData[key]);
                }

                // Handle the notification with Helpshift SDK.
                Helpshift.HelpshiftSdk.GetInstance().HandlePushNotification(hsPushData);
                return;
            }

            /// Handle notification from other sources

            /// For example, lets say you send notification for Helpshift Outbound support
            /// and embed the outbound link in "helpshift_proactive_link" key
            if (pushData.ContainsKey("helpshift_proactive_link"))
            {
                // Recevied notification from customer's push integration.
                // Extract proactive outbound link for Helpshift Outbound Support
                string outboundLink = pushData["helpshift_proactive_link"];

                // Embed this outboundLink in a notification Intent and post notification on device.
                // When user clicks the notification then extract this outboundLink from the notification intent extra data and call
                // Helpshift.HelpshiftSdk.GetInstance().HandleProactiveLink(outboundLink);
                
                // Below example demonstrates the above logic.
                AndroidJavaClass notificationUtil = new AndroidJavaClass("com.helpshift.unity.sdkx.helpshiftexamplenativehandler.HelpshiftNotificationUtil");
                
                AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject currentActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");

                notificationUtil.CallStatic("showNotification", new object[] { currentActivity, "Helpshift Example: Outbound Support Notification",  outboundLink});
               
                return;
            }
        }
    }
}

#endif

