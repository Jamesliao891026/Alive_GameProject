using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : Interact
{
    // Reference to the intermediate dialog value
    [SerializeField] private TextAssetValue dialogValue; // 對話的值
    // Reference to the NPC's dialog
    [SerializeField] private TextAsset myDialog; // 對話的文本(原始資料)
    // Notification to send to the canvases to activate and check
    // dialog
    [SerializeField] private Notification branchingDialogNotification; // 分支對話的事件

    [SerializeField] private GameObject NPCDialogCanvas;

    [SerializeField] public static bool isTalking;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange && isTalking == false) 
        {
            dialogValue.value = myDialog;
            branchingDialogNotification.Raise();
            isTalking = true;
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            myNotification.Raise();
            playerInRange = false;
            NPCDialogCanvas.SetActive(false);
            isTalking = false;
        }
    }
}
