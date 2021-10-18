using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PotionData
{
    public bool ifExist;
    public PotionData(Potion potion)
    {
        ifExist = potion.PotionExist;
    }
}
