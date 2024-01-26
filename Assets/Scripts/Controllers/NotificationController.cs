using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class NotificationController : MonoBehaviour
{
    // Replace with your Laravel API endpoint

    [SerializeField] private Transform NotificationSpawnParent;
    [SerializeField] private NotificationObject notificationPrefab;

    void Start()
    {
        StartCoroutine(GetNotifications());
    }

    IEnumerator GetNotifications()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(APIAccess.FetchNotificationURL))
        {
            // Send the request and wait for a response
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || 
                webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                CLog.Print("Access URL: " + APIAccess.FetchNotificationURL);
                CLog.Print("Error: " + webRequest.error);
            }
            else
            {
                // Parse the JSON response
                string jsonResponse = webRequest.downloadHandler.text;
                CLog.Print("Response: " + jsonResponse);

                List<NotificationData> notifications = JsonConvert.DeserializeObject<List<NotificationData>>(webRequest.downloadHandler.text);

                // Print notifications
                foreach (NotificationData notification in notifications)
                {
                    NotificationObject notificationObject = Instantiate(notificationPrefab, NotificationSpawnParent);
                    notificationObject.SetNotification(notification.title,notification.body);
                }
            }
        }
    }
}

[System.Serializable]
public class NotificationData
{
    public string title;
    public string body;
}
