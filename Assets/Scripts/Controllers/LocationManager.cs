using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Android; // For Android permissions

public class LocationManager : MonoBehaviour
{
    public TMP_Text locationText;

    private bool checkedOnce;
    
    private void Start()
    {
        locationText.text = "Fetching Location...";
        // Request permission for Android by Application Platform
        if (Application.platform == RuntimePlatform.Android)
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {
                Permission.RequestUserPermission(Permission.FineLocation);
            }
            else
            {
                checkedOnce = true;
                // Start the location service
                StartCoroutine(StartLocationService());
            }
        }
        else if (Application.platform == RuntimePlatform.OSXEditor)
        {
            StartCoroutine(GetCityCountry(23.66538313494425f,90.4805120379231f));
        }
    }

    private void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            if (!checkedOnce)
            {
                if (Permission.HasUserAuthorizedPermission(Permission.FineLocation))
                {
                    Permission.RequestUserPermission(Permission.FineLocation);
                    checkedOnce = true;
                    StartCoroutine(StartLocationService());
                }
            }
        }

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

        // Add the accept-language header to specify English
        Dictionary<string, string> headers = new Dictionary<string, string>
        {
            { "Accept-Language", "en" }
        };

        using (WWW www = new WWW(url, null, headers))
        {
            yield return www;

            if (string.IsNullOrEmpty(www.error))
            {
                // Parse JSON to get city and country
                LocationData locationData = JsonUtility.FromJson<LocationData>(www.text);

                // Update the text with city and country
                locationText.text = "City: " + locationData.address.suburb + "\n" + locationData.address.city;
                if (locationData.address.city == "")
                { 
                    locationText.text = "Error #005";
                }
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
        public string suburb;
    }
}
