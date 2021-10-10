using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory System/Items/Equipment")]
public class Equipment : ItemObject
{
    public EquipmentSlot equipSlot;

    private void Awake()
    {
        type = ItemType.Equipment;    
    }

    public override void Use()
    {
        base.Use();

        EquipmentManager.instance.Equip(this);
    }
}

public enum EquipmentSlot {Hand}