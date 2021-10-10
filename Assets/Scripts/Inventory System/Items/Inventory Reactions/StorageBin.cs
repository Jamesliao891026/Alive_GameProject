using UnityEngine;
using UnityEngine.UI;

public class StorageBin : Interactable
{
    //public GameObject storageBinCanvas;
    //InventoryUI inventoryUI;
    public InventoryUIController inventoryUIController;

    private void Start()
    {
        //inventoryUI = storageBinCanvas.GetComponent<InventoryUI>();
    }

    public override void Interact()
    {
        base.Interact();
        Debug.Log("OPEN THE STORAGE BIN CANVAS");
        // inventoryUI.OpenCanvas();
        inventoryUIController.OpenCanvas();
    }
}
