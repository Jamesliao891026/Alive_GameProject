using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour // // 此為player走入某範圍內發出的問號圖示切換
{
    public GameObject contextClue;
    public bool contextActive = false;

    public void ChangeContext() {
        contextActive = !contextActive;
        if (contextActive)
        {
            contextClue.SetActive(true);
        }
        else {
            contextClue.SetActive(false);
        }
    }
}
