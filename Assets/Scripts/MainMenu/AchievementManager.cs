using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public Achievement[] achievements;

    public AchievementUI achievementUI;

    public static AchievementManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            AddPoint("水電工具人");
        }
    }
    public void AddPoint(string name)
    {
        Achievement achievement = Array.Find(achievements, listElement => listElement.name == name);
        achievement.GetPoint();
    }
    public void UpdateUI()
    {
        achievementUI.RefreshPanel();
    }
}