using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public MouseItem mouseItem = new MouseItem();

    public InventoryObject bagObj;
    public InventoryObject storageBoxObj;

    // �}�l�C���ɷ|��s�@��UI�A�e�{�I�]�쥻���ƻ�
    private void Start()
    {
        bagObj.RefreshInventoryUI();
        storageBoxObj.RefreshInventoryUI();
    }
    // ��R�|�M�ŭI�]�M�x���c
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            ResetInventory();
        }
    }
    // �M��
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
