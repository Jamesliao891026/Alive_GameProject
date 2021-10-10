using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    // �Ω�P�@�i�a�Ϫ��e������, �z�L�I���S�w���~�ӽվ�۾��P�����m
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �I���쪺�Otag��Player�� 2D���󪺸�
        if (other.CompareTag("Player"))
        {
            
            //cam.minPosition += cameraChange;
            //cam.maxPosition += cameraChange;
            
            other.transform.position += playerChange;
        }
    }
}
