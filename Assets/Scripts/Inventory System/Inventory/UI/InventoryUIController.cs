using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour
{
    public GameObject StorageUICanvas;
    public Button backButton;

    public void OpenCanvas()
    {
        StorageUICanvas.SetActive(true);
    }
    public void CloseCanvas()
    {
        StorageUICanvas.SetActive(false);
    }
}
