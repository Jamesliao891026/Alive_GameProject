using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Notification : ScriptableObject // 事件
{
    public List<NotificationListener> listeners = new List<NotificationListener>(); // 建立NotificationListener陣列

    public void Raise() { // 觸發事件
        for (int i = listeners.Count - 1; i >= 0; i--) {
            listeners[i].OnSignalRaised();
        }
    }

    public void RegisterListener(NotificationListener listener) { // 將一個事件加入陣列
        listeners.Add(listener);
    }
    public void DeRegisterListener(NotificationListener listener) // 將一個事件移除陣列
    {
        listeners.Remove(listener);
    }
}
