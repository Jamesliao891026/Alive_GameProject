using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Slot : MonoBehaviour
{
    // UI stuff to change
    [SerializeField] protected Image icon;
    [SerializeField] protected Text amountText;

    // variable from item
    [SerializeField] protected ItemObject item;

    // bag
    //int slotIndex;
    //public GameObject useItemWindow;
    //private void Start()
    //{
    //    slotIndex = transform.GetSiblingIndex();
    //}

    // add item to the slot
    public void AddItem(ItemObject newItem, int amount)
    {
        // newItem : bag's item
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;

        amountText.text = amount.ToString();
        amountText.enabled = true;

    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;

        amountText.text = null;
        amountText.enabled = false;
    }

    // bag
    //public void UseItem()
    //{
    //    if (item != null)
    //    {
    //        useItemWindow.SetActive(true);
    //        useItemWindow.GetComponent<UseItemWindow>().SetItemInfo(item.itemDescription, item, slotIndex, true);
    //    }
    //}
}
