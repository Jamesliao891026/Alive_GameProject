using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public ItemDatabaseObject database;
    public int space = 10;
    public Inventory container;

    // InventoryUI
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    
    int slotMaxStack = 5;
    int itemRest;  

    public bool Add(ItemObject item)
    {
        if (HasSameItem(item)) 
        {
            RefreshInventoryUI();
            if (itemRest != 0) 
            {
                if (CanAddIntoEmptySlot(item, item.amount))
                {
                    RefreshInventoryUI();
                    return true;
                }
                else
                    return false;
            }
            return true; // no item rest
        }
        else 
        {
            if (CanAddIntoEmptySlot(item, item.amount))
            {
                RefreshInventoryUI();
                return true;
            }
            else
                return false;
        }
    }

    public bool CanAddIntoEmptySlot(ItemObject _item, int _amount)
    {
        for (int i = 0; i < container.items.Length; i++)
        {
            if(container.items[i].ID <= -1)
            {
                container.items[i].UpdateSlot(_item.Id, _item, _amount);
                return true;
            }
        }
        // Inventory is Full !
        Debug.Log("Not Enough room!");
        return false;
    }

    public void MoveItem(InventorySlot item1, InventorySlot item2)
    {
        InventorySlot temp = new InventorySlot(item2.ID, item2.item, item2.amount);
        item2.UpdateSlot(item1.ID, item1.item, item1.amount);
        item1.UpdateSlot(temp.ID, temp.item, temp.amount);
    }

    public int UseItem(int slotIndex, ItemObject _item)
    {
        int rest = _item.amount;
        if (container.items[slotIndex].amount > 0)
        {
            container.items[slotIndex].AddAmount(-1);
            if (container.items[slotIndex].amount == 0) // 沒藥水，要清空背包格子
                container.items[slotIndex].UpdateSlot(-1, null, 0);
            rest = container.items[slotIndex].amount;
            RefreshInventoryUI();
            return rest;
        }
        return rest;
    }
    
    public void RefreshInventoryUI()
    {
        // Update the UI (triggering an event)
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();  // Invoke the method(UpdateUI)
        }
    }

    private bool HasSameItem(ItemObject item)
    {
        for (int i = 0; i < container.items.Length; i++)
        {
            if (container.items[i].item == null)
                return false;

            if (container.items[i].item.type == ItemType.SmallPotion || container.items[i].item.type == ItemType.BigPotion)
            {
                if (container.items[i].item.type == item.type && container.items[i].amount < slotMaxStack)
                {
                    itemRest = item.amount;
                    if (container.items[i].amount + item.amount <= slotMaxStack) // 裝得下 ( ex :  3 + 2 <= 5)
                    {
                        itemRest -= item.amount;
                        container.items[i].AddAmount(item.amount);
                    }
                    else // 裝不下( ex :  3 + 5 > 5)
                    {
                        itemRest = (container.items[i].amount + item.amount) - slotMaxStack;
                        container.items[i].AddAmount((item.amount - itemRest));
                    }
                    return true;
                }
            }
        }
        return false;
    }
}

[System.Serializable]
public class Inventory
{
    public InventorySlot[] items = new InventorySlot[10];

    public void Clear()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].RemoveItem();
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    [System.NonSerialized]
    public UserInterface parent; // parent 是哪個 inventoryObj
    public int ID = -1;
    public ItemObject item;
    public int amount;

    public InventorySlot()
    {
        ID = -1;
        item = null;
        amount = 0;
    }

    public InventorySlot(int _id, ItemObject _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }

    public void RemoveItem()
    {
        ID = -1;
        item = null;
        amount = 0;
    }

    public void UpdateSlot(int _id, ItemObject _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}
