using System;
using UnityEditor;
using UnityEngine;
public class ScreenshotCapture : MonoBehaviour
{
    
    //System Works in MacOs FileSystem. For Windows Update Address Accordingly
    
    //CONST
    private const string SCREEN_SHOT_COUNTER = "ScreenShotCounter";

    //TODO: Change this to your desired system
    private const string username = "mxtuhin"; //NOTE: Update As Per Your Username
    private const string folderEndpoint = "Downloads"; //NOTE: Document, Downloads, Desktop
    private const string projectName = "FruitEater"; //NOTE: Folder Name | Create First Manually
    
    private const string fileName = "ScreenShot"; //NOTE: File Name
    private const string fileType = ".png"; //NOTE: File Type - JPG/PNG etc

    //NOTE: Lifecycle Variable
    int count = 0;

    #region ManualDictation

    //NOTE: Manual Start Counter
    [SerializeField] private bool setManual;
    [SerializeField] private int setStartCounter;

    #endregion

    private void Start()
    {
        if (!PlayerPrefs.HasKey(SCREEN_SHOT_COUNTER))
        {
            if (setManual)
                count = setStartCounter;
        }
        else
        {
            count = PlayerPrefs.GetInt(SCREEN_SHOT_COUNTER, 0);
        }
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeScreenShot();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ClearScreenShotCounter();
        }
#endif
    }

    private void TakeScreenShot()
    {
        PlayerPrefs.SetInt(SCREEN_SHOT_COUNTER, ++count);
        ScreenCapture.CaptureScreenshot($"/Users/{username}/{folderEndpoint}/{projectName}/{fileName}-{count}{fileType}");
    }
    
    private void ClearScreenShotCounter()
    {
        PlayerPrefs.DeleteKey(SCREEN_SHOT_COUNTER);
    }
}