using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UseItemWindow : MonoBehaviour
{
    public PlayerState playerState;
    // public HealthSystem healthSystem;
    
    private InventoryManager inventory;
    [SerializeField] private ItemObject thisItem;
    [SerializeField] private int slotIndex;

    [Header("UI stuff to change")]
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private Button useButton;
    [SerializeField] private Button unequipButton;
    [SerializeField] private Button backButton;

    private void Start()
    {
        inventory = GameManager.instance.GetComponent<InventoryManager>();
    }

    public void SetItemInfo(string _description, ItemObject _item, int _slotIndex, bool buttonActive)
    {
        itemDescription.text = _description;
        slotIndex = _slotIndex;
        if (buttonActive)
        {
            thisItem = _item;
            icon.sprite = _item.icon;

            useButton.enabled = true;

            if (thisItem.type == ItemType.Equipment)
            {
                unequipButton.gameObject.SetActive(true);
                unequipButton.enabled = true;
            }
            else
            {
                unequipButton.gameObject.SetActive(false);
                unequipButton.enabled = false;
            }

            backButton.enabled = true;
        }
        else
        {
            thisItem = null;
            icon.sprite = null;

            useButton.enabled = false;
            
            unequipButton.gameObject.SetActive(false);
            unequipButton.enabled = false;

            backButton.enabled = false;
        }
    }

    public void UseButton()
    {
        if(thisItem != null)
        {
            if(thisItem.type == ItemType.SmallPotion || thisItem.type == ItemType.BigPotion)
            {
                Potion thisPotion = (Potion) thisItem;
                
                if (playerState.HealthEnough(thisPotion.restoreHealthValue))
                {
                    Debug.Log("Health Enough!");
                    return;
                }

                thisItem.Use();
                int itemAmount = inventory.bagObj.UseItem(slotIndex, thisItem);

                playerState.Heal(thisPotion.restoreHealthValue);
                if (itemAmount == 0)
                    BackButton();
            }
            else// ¤£¬OÃÄ¤ô
            {
                Debug.Log("Unavailable!");
                thisItem.Use();
            }
        }
        else
        {
            Debug.Log("NO ITEM");
        }
    }
    public void BackButton()
    {
        SetItemInfo("", null, 0, false);
        GetComponent<UseItemWindow>().gameObject.SetActive(false);
    }
}
