using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    private UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = UIManager.GetInstance();
    }

    public void Logout()
    {
        PrefsManager.SetBool(PrefsManager.IsLoggedIn,false);
        PrefsManager.SetString(PrefsManager.UserID,"");
        PrefsManager.SetString(PrefsManager.UserPassword,"");
        uiManager.GetDashboard().SetView(false);
        uiManager.GetLoginController().SetView(true);
    }
}
