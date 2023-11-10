using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    
    
    [Header("UI Objects")]
    [SerializeField] private DashboardController dashboardController;
    [SerializeField] private LoginController LoginController;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if(instance==null)
            instance = this;
        else
            Destroy(gameObject);
    }
    
    
    public static UIManager GetInstance()
    {
        return instance;
    }

    public DashboardController GetDashboard()
    {
        return dashboardController;
    }
    
    public LoginController GetLoginController()
    {
        return LoginController;
    }
}
