using UnityEngine;
using System;
using TMPro;

public class RealTimeClock : MonoBehaviour
{
    public TMP_Text clockText;

    private void Start()
    {
        // Start the coroutine to update the clock
        StartCoroutine(UpdateClockCoroutine());
    }

    private System.Collections.IEnumerator UpdateClockCoroutine()
    {
        while (true)
        {
            // Get the current time
            DateTime currentTime = DateTime.Now;

            // Format the time as a string in 12-hour format with AM/PM
            string timeString = currentTime.ToString("h:mm:ss tt");

            // Update the Text component with the current time
            UpdateClockText(timeString);

            // Wait for one second using real-time
            yield return new WaitForSecondsRealtime(1f);
        }
    }

    private void UpdateClockText(string time)
    {
        // Make sure this is called on the main thread
        if (clockText)
        {
            clockText.text = time;
        }
    }
}