using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;


public class HelpshiftEventLoggerScript : MonoBehaviour
{
    private static List<string> eventMessages = new List<string>(); // List to store event messages
    private const int maxMessages = 50; // Maximum number of messages to display
    private static string storedText = ""; // Static variable to store text locally

    // Called when the dialog is activated or the scene is loaded
    private void OnEnable()
    {
        UpdateEventData();
    }

    // Hide the dialog
    public void CloseEventLogger()
    {
        SceneManager.UnloadSceneAsync("HelpshiftEventLogger");
    }
    
    public static void AddEventMessage(string message)
    {
        
        // Add the new message to the list
        eventMessages.Insert(0, message);

        // Remove old messages if the list exceeds the maxMessages limit
        if (eventMessages.Count > maxMessages)
        {
            eventMessages.RemoveAt(eventMessages.Count - 1); // Remove the oldest message (last in the list)
        }

        // Update the UI with the current list of messages
        UpdateStatusUI();
    }

    private static void UpdateStatusUI()
    {
        string message = string.Join("\n\n", eventMessages.Select((msg, index) => $"({index + 1}). {msg}"));
        storedText = message;
        UpdateEventData();
    }

    public static void UpdateEventData()
    {
        // Find the GameObject with the tag "helpshiftEvent"
        GameObject helpshiftEventObj = GameObject.FindGameObjectWithTag("helpshiftEvent");

        if (helpshiftEventObj != null)
        {
            // Get the Text component directly
            Text textObject = helpshiftEventObj.GetComponent<Text>();

            if (textObject != null)
            {
                // Update the text
                textObject.text = storedText;
            }
            else
            {
                Debug.LogWarning("Text component is missing on the helpshiftEvent GameObject.");
            }
        }
        else
        {
            Debug.LogWarning("No GameObject with the tag 'helpshiftEvent' found in the scene.");
        }
    }
}
