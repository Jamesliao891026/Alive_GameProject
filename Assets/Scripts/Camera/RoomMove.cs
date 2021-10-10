using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    // 用於同一張地圖的畫面切換, 透過碰撞特定物品來調整相機與角色位置
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 碰撞到的是tag為Player的 2D物件的話
        if (other.CompareTag("Player"))
        {
            
            //cam.minPosition += cameraChange;
            //cam.maxPosition += cameraChange;
            
            other.transform.position += playerChange;
        }
    }
}
