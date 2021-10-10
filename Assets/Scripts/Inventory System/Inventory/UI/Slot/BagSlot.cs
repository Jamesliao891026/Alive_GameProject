using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagSlot : Slot
{
    int slotIndex;
    public GameObject useItemWindow;
    private void Start()
    {
        slotIndex = transform.GetSiblingIndex();
    }

    public void UseItem()
    {
        if (item != null)
        {
            useItemWindow.SetActive(true);
            useItemWindow.GetComponent<UseItemWindow>().SetItemInfo(item.itemDescription, item, slotIndex, true);
        }
    }
}
