using UnityEngine;

public class ItemObject : ScriptableObject
{
    public int Id;
    new public string name = "new Item";
    public ItemType type;
    public Sprite icon = null;

    [TextArea(15, 20)]
    public string itemDescription;
    public int amount = 1; // �߰_�Ӫ����~�ƶq��itemAmount
    
    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }
}

public enum ItemType { Equipment, SmallPotion, BigPotion, Note, VaccineMaterials, Default }