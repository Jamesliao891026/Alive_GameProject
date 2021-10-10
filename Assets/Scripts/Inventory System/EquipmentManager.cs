using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    void Awake()
    {
        if(instance != null)
        {
            //Debug.LogError("More than one instance of EquipmentManager found!");
            return;
        }
        instance = this;
    }
    #endregion

    [SerializeField] Equipment[] currentEquipment;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip(Equipment newItem)
    {
        Equipment oldItem = null;

        int slotIndex = (int)newItem.equipSlot;

        if (currentEquipment[slotIndex] != null)
            oldItem = currentEquipment[slotIndex];

        if (onEquipmentChanged != null)
            onEquipmentChanged.Invoke(newItem, oldItem);
        
        // set it equal to our new item
        currentEquipment[slotIndex] = newItem;
    }

    public void Unequip(int slotIndex)
    {
        if(currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            currentEquipment[slotIndex] = null;

            // invoke it when we equip an item
            if (onEquipmentChanged != null)
                onEquipmentChanged.Invoke(null, oldItem);
        }
    }
}
