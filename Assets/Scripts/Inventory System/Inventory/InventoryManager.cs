using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public MouseItem mouseItem = new MouseItem();

    public InventoryObject bagObj;
    public InventoryObject storageBoxObj;

    // 開始遊戲時會更新一次UI，呈現背包原本有甚麼
    private void Start()
    {
        bagObj.RefreshInventoryUI();
        storageBoxObj.RefreshInventoryUI();
    }
    // 按R會清空背包和儲物箱
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            ResetInventory();
        }
    }
    // 清空
    private void ResetInventory()
    {
        Debug.Log("Reset BAG Inventory");
        bagObj.container.Clear();
        bagObj.RefreshInventoryUI();

        Debug.Log("Reset Storage Box Inventory");
        storageBoxObj.container.Clear();
        storageBoxObj.RefreshInventoryUI();
    }

    //private void OnApplicationQuit()
    //{
    //    bagObj.container.items = new InventorySlot[bagObj.space];
    //    storageBoxObj.container.items = new InventorySlot[storageBoxObj.space];
    //}
}
