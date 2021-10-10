using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Inventory System/Items/Potion")]
public class Potion : ItemObject
{
    public int restoreHealthValue;
    public override void Use()
    {
        base.Use();
        Debug.Log("POTION");
    }
}
