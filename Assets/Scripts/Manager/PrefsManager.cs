using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsManager : MonoBehaviour
{
    
    public static string IsStartingForTheFirstTime = "IsStartingForTheFirstTime";
    
    public static void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        Save();
    }
    
    public static string GetString(string key)
    {
        return PlayerPrefs.GetString(key);
    }
    
    public static void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        Save();
    }
    
    public static int GetInt(string key)
    {
        return PlayerPrefs.GetInt(key);
    }
    
    public static void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
        Save();
    }
    
    public static float GetFloat(string key)
    {
        return PlayerPrefs.GetFloat(key);
    }
    
    public static void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
        Save();
    }
    
    public static bool GetBool(string key)
    {
        return PlayerPrefs.GetInt(key) == 1;
    }
    
    public static void DeleteKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }
    
    public static void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }
    
    public static bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }
    
    public static void Save()
    {
        PlayerPrefs.Save();
    }

}
