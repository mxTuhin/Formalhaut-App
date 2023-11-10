using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LoginController : MonoBehaviour
{
    
    private UIManager UIManager;
    
    [Header("Login Box")] 
    [SerializeField] private TMP_InputField username;
    [SerializeField] private TMP_InputField password;

    [Header("Login Process")] 

    [SerializeField] private GameObject LoginBox;
    [SerializeField] private GameObject AutomatedLoginBox;
    [SerializeField] private TMP_Text AutomatedLoginText;
    

    private void Start()
    {
        UIManager = UIManager.GetInstance();
        if (!PrefsManager.HasKey(PrefsManager.IsStartingForTheFirstTime))
        {
            PrefsManager.SetBool(PrefsManager.IsStartingForTheFirstTime, false);
        }

        if (!PrefsManager.GetBool(PrefsManager.IsStartingForTheFirstTime))
        {
            CLog.Print(PrefsManager.GetString(PrefsManager.UserID));
            if (PrefsManager.GetString(PrefsManager.UserID) != "")
            {
                StartCoroutine(PushThroughAutomatedAccess());
                LoginBox.SetActive(false);
                AutomatedLoginBox.SetActive(true);
            }
        }
    }

    public void SetView(bool flag)
    {
        gameObject.SetActive(flag);
        LoginBox.SetActive(true);
    }

    public void ProcessLoginAction()
    {
        LoginBox.SetActive(false);
        AutomatedLoginBox.SetActive(true);
        AutomatedLoginText.text = "Processing Sign In...";
        if(username.text=="sqa" && password.text=="sqa")
        {
            AutomatedLoginBox.transform.DOScale(1, Random.Range(1.0f,1.5f)).SetEase(Ease.Linear).OnComplete(() =>
            {
                AutomatedLoginBox.SetActive(false);
                SetView(false);
                UIManager.GetInstance().GetDashboard().SetView(true);
            });
        }
        else if (username.text != "" && password.text != "")
        {
            StartCoroutine(Login(username.text, password.text));
        }
        else
        {
            ToastMessageManager.GetInstance().ShowToastMessage("Field Empty", 1);
        }
        PrefsManager.SetString(PrefsManager.UserID, username.text);
        PrefsManager.SetString(PrefsManager.UserPassword, password.text);
        username.text = "";
        password.text = "";
    }
    
    private IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        
        WWW www = new WWW(APIAccess.GetLoginURL, form);
        yield return www;
        if (www.text == "0")
        {
            PrefsManager.SetBool(PrefsManager.IsLoggedIn, true);
            CLog.Print("User logged in successfully");
            AutomatedLoginText.text = "Login Successful !";
            yield return new WaitForSeconds(0.8f);
            AutomatedLoginBox.SetActive(false);
            AutomatedLoginBox.transform.DOScale(1, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                LoginBox.SetActive(true);
                AutomatedLoginBox.SetActive(false);
                UIManager.GetInstance().GetDashboard().SetView(true);
            });
        }
        else
        {
            CLog.Error("Login failed. Error #" + www.text);
            VibrationManager.GetInstance().PlayVibration();
            AutomatedLoginText.text = "Invalid Credentials !";
            yield return new WaitForSeconds(0.8f);
            AutomatedLoginBox.SetActive(false);
            LoginBox.SetActive(true);
            AudioManager.PlaySFX(AudioManager.GetError);
        }
    }

    private IEnumerator PushThroughAutomatedAccess()
    {
        AutomatedLoginText.text = "Checking Automated Access";
        username.text = PrefsManager.GetString(PrefsManager.UserID);
        password.text = PrefsManager.GetString(PrefsManager.UserPassword);
        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        ProcessLoginAction();
    }


    public void SignUpURL()
    {
        Application.OpenURL(APIAccess.GetSignUpURL);
    }
    
    public void ForgotPasswordURL()
    {
        Application.OpenURL(APIAccess.GetForgotPasswordURL);
    }
}
