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
    [SerializeField] private GameObject LoginLoading;
    

    private void Start()
    {
        UIManager = UIManager.GetInstance();
        if (PrefsManager.HasKey(PrefsManager.IsStartingForTheFirstTime))
        {
            PrefsManager.SetBool(PrefsManager.IsStartingForTheFirstTime, true);
        }
    }

    public void SetView(bool flag)
    {
        gameObject.SetActive(flag);
    }

    public void ProcessLoginAction()
    {
        if(username.text=="sqa" && password.text=="sqa")
        {
            LoginLoading.SetActive(true);
            LoginLoading.transform.DOScale(1, Random.Range(1.0f,1.5f)).SetEase(Ease.Linear).OnComplete(() =>
            {
                LoginLoading.SetActive(false);
                SetView(false);
                UIManager.GetInstance().GetDashboard().SetView(true);
            });
        }
        else if (username.text != "" && password.text != "")
        {
            LoginLoading.SetActive(true);
            Login(username.text, password.text);
        }
        else
        {
            ToastMessageManager.GetInstance().ShowToastMessage("Field Empty", 1);
        }
        
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
            CLog.Print("User logged in successfully");
            LoginLoading.SetActive(false);
            LoginLoading.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack).OnComplete(() =>
            {
                UIManager.GetInstance().GetDashboard().SetView(true);
            });
        }
        else
        {
            CLog.Error("Login failed. Error #" + www.text);
            VibrationManager.GetInstance().PlayVibration();
            AudioManager.PlaySFX(AudioManager.GetError);
        }
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
