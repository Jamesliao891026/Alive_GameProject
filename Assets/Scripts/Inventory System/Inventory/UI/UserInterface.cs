using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UserInterface : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public InventoryObject inventoryObj;

    public Slot[] slots;

    [SerializeField]
    public Dictionary<GameObject, InventorySlot> itemsDisplayed = new Dictionary<GameObject, InventorySlot>();

    void Start()
    {
        inventoryManager = GameManager.instance.GetComponent<InventoryManager>();

        for (int i = 0; i < inventoryObj.container.items.Length; i++)
        {
            inventoryObj.container.items[i].parent = this;
        }

        slots = GetComponentsInChildren<Slot>();
        CreateSlots();
        inventoryObj.onItemChangedCallback += UpdateUI;
    }

    public abstract void CreateSlots();

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventoryObj.container.items.Length)
            {
                if (inventoryObj.container.items[i].item != null)
                    slots[i].AddItem(inventoryObj.container.items[i].item, inventoryObj.container.items[i].amount);
                if (inventoryObj.container.items[i].amount == 0)
                    slots[i].ClearSlot();
            }
            else
            {
                slots[i].ClearSlot();
                //if (inventoryObj.container.items[i].item == null)
                //{
                //    slots[i].ClearSlot();
                //}
            }
        }
    }

    protected void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }

    public void OnEnter(GameObject obj)
    {
        // we know which obj our mouse is over by accessing this 
        inventoryManager.mouseItem.hoverObj = obj;
        if (itemsDisplayed.ContainsKey(obj))
            inventoryManager.mouseItem.hoverItem = itemsDisplayed[obj];
    }
    public void OnExit(GameObject obj)
    {
        inventoryManager.mouseItem.hoverObj = null;
        inventoryManager.mouseItem.hoverItem = null;
    }
    public void OnDragStart(GameObject obj)
    {
        var mouseObject = new GameObject();
        // Rectransform to the mouse obj
        var rt = mouseObject.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(70, 70); // item's icon size
        mouseObject.transform.SetParent(transform.parent);
        if (itemsDisplayed[obj].ID >= 0)
        {
            var img = mouseObject.AddComponent<Image>();
            img.sprite = inventoryObj.database.GetItem[itemsDisplayed[obj].ID].icon;
            img.raycastTarget = false;
        }
        inventoryManager.mouseItem.obj = mouseObject;
        inventoryManager.mouseItem.item = itemsDisplayed[obj];
    }
    public void OnDragEnd(GameObject obj)
    {
        if (inventoryManager.mouseItem.hoverObj) // 在背包的格子內
        {
            inventoryObj.MoveItem(itemsDisplayed[obj], inventoryManager.mouseItem.hoverItem.parent.itemsDisplayed[inventoryManager.mouseItem.hoverObj]);
            inventoryObj.RefreshInventoryUI();
            inventoryManager.mouseItem.hoverItem.parent.inventoryObj.RefreshInventoryUI();
            if (itemsDisplayed[obj].item == null)
            {
                obj.GetComponent<Slot>().ClearSlot();
            }
        }
        Destroy(inventoryManager.mouseItem.obj);
        inventoryManager.mouseItem.item = null;
    }
    public void OnDrag(GameObject obj)
    {
        if (inventoryManager.mouseItem.obj != null)
            inventoryManager.mouseItem.obj.GetComponent<RectTransform>().position = Input.mousePosition;
    }
}

public class MouseItem
{
    public GameObject obj;
    public InventorySlot item;
    public InventorySlot hoverItem;
    public GameObject hoverObj;
}