using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FooterController : MonoBehaviour
{
    [SerializeField] private DashboardController dashboardController;
    
    [Header("Footer Icons")]
    [SerializeField] private Image HomeIcon;
    [SerializeField] private Image NotificationIcon;
    [SerializeField] private Image ProfileIcon;
    [SerializeField] private Image SettingsIcon;
    
    public void GoToHome()
    {
        dashboardController.SetHomeView();
        SetImageColor(HomeIcon);
    }
    public void GoToNotification()
    {
        dashboardController.SetNotificationView();
        SetImageColor(NotificationIcon);
    }
    public void GoToProfile()
    {
        dashboardController.SetProfileView();
        SetImageColor(ProfileIcon);
    }
    public void GoToSettings()
    {
        dashboardController.SetSettingsView();
        SetImageColor(SettingsIcon);
    }

    private void SetAllImageToDefault()
    {
        HomeIcon.color = new Color(0.867f, 0.867f, 0.867f);
        NotificationIcon.color = new Color(0.867f, 0.867f, 0.867f);
        ProfileIcon.color = new Color(0.867f, 0.867f, 0.867f);
        SettingsIcon.color = new Color(0.867f, 0.867f, 0.867f);
    }
    
    private void SetImageColor(Image image)
    {
        SetAllImageToDefault();
        image.color = new Color(1.0f, 0.439f, 0.435f);
    }
}
