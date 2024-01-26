using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationObject : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text message;
    
    public void SetNotification(string title,string message)
    {
        this.title.text = title;
        this.message.text = message;
    }
}
