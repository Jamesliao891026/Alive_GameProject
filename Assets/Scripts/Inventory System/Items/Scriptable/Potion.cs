using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Inventory System/Items/Potion")]
public class Potion : ItemObject
{
    public int restoreHealthValue;
    public bool PotionExist = true; // �Ӫ��~�O�_�٦s�b
    public override void Use()
    {
        base.Use();
        Debug.Log("POTION");
    }
}
