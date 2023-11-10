using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIAccess : MonoBehaviour
{
    private static string baseURL = "https://nexusorbit.digital/aqua-flow/";
    private static string apiVersion = "api/v1/";

    //Sign Up System
    public static string GetSignUpURL => baseURL+"register";
    
    //ForgotPass
    public static string GetForgotPasswordURL => baseURL+"forgot-password";
    
    
    //API Access
    public static string GetLoginURL => baseURL + apiVersion + "login";
    public static string FetchNotificationURL => baseURL + apiVersion + "notifications";
    public static string FetchProfileDataURL => baseURL + apiVersion + "profile-data";
    
    public static string fetchDeviceStateURL => baseURL + apiVersion + "device-state";
    
}
