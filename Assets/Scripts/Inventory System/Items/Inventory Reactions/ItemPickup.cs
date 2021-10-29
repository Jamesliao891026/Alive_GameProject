using UnityEngine;

public class ItemPickup : Interactable
{
    public InventoryManager inventory;
    public ItemObject item;
    [SerializeField] private GameObject remiderText;

    private void Start()
    {
        inventory = GameManager.instance.GetComponent<InventoryManager>();
    }

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        Debug.Log(inventory);
        bool wasPickedUp = inventory.bagObj.Add(item);
        if (wasPickedUp)
        {
            item.itemExist = false;
            Debug.Log(item.itemExist);
            string printText = item.name.ToString() + " is Picked up!";
            remiderText.SetActive(true);
            remiderText.GetComponent<ReminderText>().ShowReminderText(printText);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("BAG IS FULL!");
            remiderText.SetActive(true);
            remiderText.GetComponent<ReminderText>().ShowReminderText("BAG IS FULL!");
        }
    }
}

