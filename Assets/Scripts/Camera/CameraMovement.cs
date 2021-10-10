using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // 玩家位置
    Transform target;

    // 流暢度(相機的跟隨速度)
    //public float smoothness;

    public SpriteRenderer backgroundSprite;


    // 相機能在單一場景畫面中跑動的最大最小範圍 (暫時用不到, 等TileMap出來再說)
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

        // 若相機尚未移動到玩家所在的位置
        //if (transform.position != target.position)
        //{
        //    // 設一個用來當作相機移動終點的變數(x,y取自玩家, z取自相機本身)
        //    Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        //    // 位相機的移動終點, 設下一個最大與最小值的限制 (暫時用不到, 等TileMap出來再說)
        //    targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
        //    targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);


        //    // 使相機慢慢到達我們設定的移動終點
        //    transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness);
        //}
    }
}
