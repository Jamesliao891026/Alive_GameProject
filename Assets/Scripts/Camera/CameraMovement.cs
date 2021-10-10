using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // ���a��m
    Transform target;

    // �y�Z��(�۾������H�t��)
    //public float smoothness;

    public SpriteRenderer backgroundSprite;


    // �۾���b��@�����e�����]�ʪ��̤j�̤p�d�� (�ȮɥΤ���, ��TileMap�X�ӦA��)
    Vector2 maxPosition;
    Vector2 minPosition;

    private void Start()
    {
        target = Player.instance.transform;

        Vector3 spritePos = backgroundSprite.gameObject.transform.position;

        float spriteHalfHeight = (backgroundSprite.bounds.size.y * backgroundSprite.transform.localScale.y)/2;
        float spriteHalfWidth = (backgroundSprite.bounds.size.x * backgroundSprite.transform.localScale.x)/2;
        

        float cameraHalfHeight = Camera.main.orthographicSize;
        float cameraHalfWidth = cameraHalfHeight * Camera.main.aspect;

        Vector2 mapMaxBounds = new Vector2(spritePos.x + spriteHalfWidth , spritePos.y + spriteHalfHeight);
        Vector2 mapMinBounds = new Vector2(spritePos.x - spriteHalfWidth , spritePos.y - spriteHalfHeight);

        //float spriteEdgePosTop = spritePos.y + spriteHalfHeight - cameraHalfHeight;
        //float spriteEdgePosRight = spritePos.x + spriteHalfWidth - cameraHalfWidth;
        //float spriteEdgePosBottom = spritePos.y - spriteHalfHeight + cameraHalfHeight;
        //float sprtieEdgePosLeft = spritePos.x - spriteHalfWidth + cameraHalfWidth;

        maxPosition = mapMaxBounds - new Vector2(cameraHalfWidth,cameraHalfHeight);
        minPosition = mapMinBounds + new Vector2(cameraHalfWidth,cameraHalfHeight);

        Player.instance.GetComponent<PlayerMovement>().SetBounds(mapMinBounds, mapMaxBounds);
    }


    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x,minPosition.x,maxPosition.x),Mathf.Clamp(transform.position.y,minPosition.y,maxPosition.y),transform.position.z);

        // �Y�۾��|�����ʨ쪱�a�Ҧb����m
        //if (transform.position != target.position)
        //{
        //    // �]�@�ӥΨӷ�@�۾����ʲ��I���ܼ�(x,y���۪��a, z���۬۾�����)
        //    Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        //    // ��۾������ʲ��I, �]�U�@�ӳ̤j�P�̤p�Ȫ����� (�ȮɥΤ���, ��TileMap�X�ӦA��)
        //    targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
        //    targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);


        //    // �Ϭ۾��C�C��F�ڭ̳]�w�����ʲ��I
        //    transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness);
        //}
    }
}
