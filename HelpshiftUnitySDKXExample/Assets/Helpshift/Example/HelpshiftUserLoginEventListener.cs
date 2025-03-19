using System.Collections.Generic;
using Helpshift;
using UnityEngine;
using UnityEngine.UI;

namespace HelpshiftExample
{
    public class HelpshiftUserLoginEventListener: MonoBehaviour, IHelpshiftUserLoginEventListener
    {
        private HelpshiftSdk _helpshiftX;

        private Text statusText; // Private reference to Text component

        public void OnLoginSuccess()
        {
            Debug.Log("Helpshift - IdentityLogin - Login was successful!");
            UpdateStatusUI("Login was successful!");
        }

        public void OnLoginFailure(string reason, Dictionary<string, string> errorMap)
        {
            Debug.Log("Helpshift - IdentityLogin - Login was failed!");

            string errorDetails = "Login failed due to: " + reason;
            foreach (var error in errorMap)
            {
                Debug.Log($"Error Key: {error.Key}, Error Value: {error.Value}");
                errorDetails += $"\nError Key: {error.Key}, Error Value: {error.Value}";
            }
            UpdateStatusUI(errorDetails);
        }

        private void UpdateStatusUI(string message)
        {
            if (statusText == null)
            {
                statusText = GameObject.FindGameObjectWithTag("loginStatus").GetComponent<Text>();
            }
            statusText.text = message;
            HelpshiftEventLoggerScript.AddEventMessage(message+ "\n");
        }
    }
}
