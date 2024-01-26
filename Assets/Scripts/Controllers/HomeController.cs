using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeController : MonoBehaviour
{
    [SerializeField] private GameObject On;
    [SerializeField] private GameObject Off;
    
    public void DeviceOnOff(bool flag)
    {
        StartCoroutine(OnOff(flag));
    }
    
    private IEnumerator OnOff(bool flag)
    {
        string url = $"{APIAccess.AppSendCommandURL}?device_id=F001&device_status={(flag ? "On" : "Off")}";
    
        WWW www = new WWW(url);
        CLog.Print("Access URL: " + url);
        yield return www;

        CLog.Print("Response: " + www.text);
        if (www.text == "0")
        {
            CLog.Print("Success");
            yield return new WaitForSeconds(0.8f);
            On.SetActive(!flag);
            Off.SetActive(flag);
        }
        else
        {
        }
    }
}
