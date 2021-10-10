using UnityEngine;

public class ItemPickup : Interactable
{
    public InventoryManager inventory;
    public ItemObject item;

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
            Destroy(gameObject); 
    }
}

