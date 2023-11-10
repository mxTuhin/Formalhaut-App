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
    
    
    //Login
    public static string GetLoginURL => baseURL + apiVersion + "login";
}
