using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIAccess : MonoBehaviour
{
    // private static string baseURL = "https://nexusorbit.digital/aqua-flow/";
    private static string baseURL = "http://127.0.0.1:8000/";
    private static string apiVersion = "api/v1/";

    //Sign Up System
    public static string GetSignUpURL => baseURL+"register";
    
    //ForgotPass
    public static string GetForgotPasswordURL => baseURL+"forgot_password";
    
    
    //API Access
    public static string GetLoginURL => baseURL +apiVersion + "user_login/";
    public static string FetchNotificationURL => baseURL + apiVersion + "get_notifications/";
    public static string FetchProfileDataURL => baseURL + apiVersion + "profile_data/";
    
    public static string FetchDeviceStateURL => baseURL + apiVersion + "device_state/";
    
    public static string AppSendCommandURL => baseURL + apiVersion + "app_send_command/";
    
}
