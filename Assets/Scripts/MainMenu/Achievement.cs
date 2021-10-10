using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Achievement
{
    public string name;
    public string describe;
    public Sprite sprite;
    public bool isUnlock = false;

    int currentPoint;
    public int needPointToUnlock;

    public void GetPoint()
    {
        currentPoint++;
        CanUnlock();
    }
    void CanUnlock()
    {
        if(currentPoint >= needPointToUnlock)
        {
            UnlockAchievement();
        }
    }
    void UnlockAchievement()
    {
        Debug.Log("The Achievement '" + name +"is Unlock!!");
        isUnlock = true;
        AchievementManager.instance.UpdateUI();
    }
}
