using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLog
{
    private static bool isDebugMode = true;
    private static bool errorDebugMode = true;
    private static bool warningDebugMode = true;
    private static bool infoDebugMode = true;
    private static bool printDebugMode = true;
    
    public static void Print(object message)
    {
        if(!isDebugMode)
            return;
        if(printDebugMode)
        {
            Debug.Log("<color=#26C6DA>"+message+"</color>");
        }
    }
    
    public static void Error(object message)
    {
        if(!isDebugMode)
            return;
        if(errorDebugMode)
        {
            Debug.LogError("<color=#F06292>"+message+"</color>");
        }
    }
    
    public static void Warning(object message)
    {
        if(!isDebugMode)
            return;
        if(warningDebugMode)
        {
            Debug.LogWarning("<color=#FFF176>"+message+"</color>");
        }
    }
    
    public static void Info(object message)
    {
        if(!isDebugMode)
            return;
        if(infoDebugMode)
        {
            Debug.Log("<color=#9CCC65>"+message+"</color>");
        }
    }
}
