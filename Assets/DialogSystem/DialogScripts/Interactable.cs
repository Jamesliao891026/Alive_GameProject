using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] public Notification myNotification; // 此事件為player走入某範圍內發出的問號圖示
    [SerializeField] public string otherTag; 
    [SerializeField] public bool playerInRange; // player是否在範圍內


   public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            myNotification.Raise();
            playerInRange = true;
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            myNotification.Raise();
            playerInRange = false;
        }
    }
}
