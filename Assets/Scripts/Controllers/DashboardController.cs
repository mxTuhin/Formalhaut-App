using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DashboardController : MonoBehaviour
{
    
    [Header("UI Access")]
    //Dashboard Scroll
    [SerializeField] private RectTransform dashboardScroll;
    
    
    [Header("Dashboard Controllers")]
    
    [SerializeField] private HomeController homeController;
    [SerializeField] private NotificationController notificationController;
    [SerializeField] private ProfileController profileController;
    [SerializeField] private SettingsController settingsController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetView(bool flag)
    {
        gameObject.SetActive(flag);
        SetHomeView();
    }

    public void SetHomeView()
    {
        ScrollPos(0);
    }
    
    public void SetNotificationView()
    {
        ScrollPos(1080*1);
    }
    
    public void SetProfileView()
    {
        ScrollPos(1080*2);
    }
    
    public void SetSettingsView()
    {
        ScrollPos(1080*3);
    }

    private void ScrollPos(int pos)
    {
        dashboardScroll.DOAnchorPos(new Vector2(-pos, 0), 0.5f).SetEase(Ease.Linear).OnComplete(() =>
        {

        });
    }
}
