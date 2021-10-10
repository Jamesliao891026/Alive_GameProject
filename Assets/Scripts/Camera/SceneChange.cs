using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // 用於不同場景的畫面切換, 透過碰撞特定物品來切換所預設的場景編號

    // 用來轉移用的號碼(記得先將想切換至的場景放入Bulid Setting)
    public int SceneNumber;
    void Start()
    {
        
    }
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 碰撞到的是tag為Player的 2D物件的話
        if (other.CompareTag("Player"))
        {
            // SceneManager.LoadScene("場景名稱"); 但是基於方便性應該還是用SceneNumber
            SceneManager.LoadScene(SceneNumber);
        }
    }
}
