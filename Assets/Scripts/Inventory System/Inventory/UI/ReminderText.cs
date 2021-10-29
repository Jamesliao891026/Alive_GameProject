using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReminderText : MonoBehaviour
{
    public void ShowReminderText(string reminderText)
    {
        this.GetComponent<Text>().text = reminderText;
        Debug.Log("SHOW TEXT!");
        Invoke("DestroyShowText", 0.5f);
    }

    public void DestroyShowText()
    {
        this.gameObject.SetActive(false);
        Debug.Log("TEXT IS GONE!");
    }
}
