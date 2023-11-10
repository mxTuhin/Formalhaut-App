using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    private static VibrationManager instance;
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public void PlayVibration()
    {
        Handheld.Vibrate();
    }
    
    public static VibrationManager GetInstance()
    {
        return instance;
    }
}
