using System.Collections.Generic;
using Helpshift;
using UnityEngine;
using HSMiniJSON;

namespace HelpshiftExample
{
    public class HSEventsListener: IHelpshiftEventsListener
    {

        public void AuthenticationFailedForUser(HelpshiftAuthenticationFailureReason reason)
        {
            string message = "Helpshift - Authentication Failed for reason: " + reason.ToString();
            Debug.Log(message);
            HelpshiftEventLoggerScript.AddEventMessage(message);
        }

        public void HandleHelpshiftEvent(string eventName, Dictionary<string, object> eventData)
        {
            string eventDataString = "";
            string message =  $"Helpshift - Event: {eventName}";
            if (eventData != null)
            {
                foreach (KeyValuePair<string, object> kvp in eventData)
                {
                    eventDataString += string.Format("Key = {0}, Value = {1}", kvp.Key, Json.Serialize(kvp.Value));
                }
                message += $"\n{eventDataString}";
            }

            Debug.Log(message);
            HelpshiftEventLoggerScript.AddEventMessage(message);
        }
    }
}
