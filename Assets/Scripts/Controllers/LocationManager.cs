using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.Android; // For Android permissions

public class LocationManager : MonoBehaviour
{
    public TMP_Text locationText;

    private void Start()
    {
        // Request permission for Android
        #if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
        
        // Start the location service
        StartCoroutine(StartLocationService());
        
        #elif UNITY_EDITOR
        locationText.text = "Banani, Dhaka";
#endif
    }

    private IEnumerator StartLocationService()
    {
        // First, check if location services are enabled
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("Location services are not enabled");
            locationText.text = "Not Permitted";
            yield break;
        }

        // Start location service with desired accuracy and update distance
        Input.location.Start(10f, 0.1f);

        // Wait until the location service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // If initialization takes too long, print a message to the console
        if (maxWait <= 0)
        {
            Debug.Log("Location service initialization timed out");
            yield break;
        }

        // Check if the location service has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Location service failed");
            yield break;
        }

        // Retrieve latitude and longitude
        float latitude = Input.location.lastData.latitude;
        float longitude = Input.location.lastData.longitude;

        // Use a geocoding service to get city and country based on latitude and longitude
        StartCoroutine(GetCityCountry(latitude, longitude));
    }

    private IEnumerator GetCityCountry(float latitude, float longitude)
    {
        string url = "https://nominatim.openstreetmap.org/reverse?format=json&lat=" + latitude + "&lon=" + longitude;

        using (WWW www = new WWW(url))
        {
            yield return www;

            if (string.IsNullOrEmpty(www.error))
            {
                // Parse JSON to get city and country
                LocationData locationData = JsonUtility.FromJson<LocationData>(www.text);

                // Update the text with city and country
                locationText.text = "City: " + locationData.address.city + "\nCountry: " + locationData.address.country;
            }
            else
            {
                Debug.LogError("Error retrieving location data: " + www.error);
            }
        }
    }

    [System.Serializable]
    private class LocationData
    {
        public AddressData address;
    }

    [System.Serializable]
    private class AddressData
    {
        public string city;
        public string country;
    }
}
