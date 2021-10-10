using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NotificationListener : MonoBehaviour
{
    public Notification notification;
    public UnityEvent signalEvent; // 事件

    public void OnSignalRaised() { // 觸發事件
        signalEvent.Invoke();
    }

    private void OnEnable()
    { // 將一個事件加入陣列
        notification.RegisterListener(this);
    }
    private void OnDisable()
    { // 將一個事件移除陣列
        notification.DeRegisterListener(this);
    }
}
