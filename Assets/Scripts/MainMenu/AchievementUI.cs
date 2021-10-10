using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUI : MonoBehaviour
{
    public GameObject[] points;
    Achievement[] achievements;

    public GameObject leftButton, rightButton;

    int section = 0;

    private void Start()
    {
        achievements = AchievementManager.instance.achievements;
        RefreshPanel();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            RefreshPanel();
        }    
    }
    public void RefreshPanel()
    {
        ShowLeftRightButton();

        int achievementIndex = 3 * section;  //count the achievementIndex using section

        for (int i = 0; i < points.Length; i++ , achievementIndex++)
        {
            GetImageObj(i).GetComponentInChildren<Image>().sprite = achievements[achievementIndex].sprite;
            GetImageObj(i).GetComponentInChildren<Text>().text = achievements[achievementIndex].name;
            GetDescriptionObj(i).GetComponentInChildren<Text>().text = achievements[achievementIndex].describe;

            CheckAchievementUnlock( i , achievementIndex);
        }
        
    }
    public void AchievementButtonClick(int pointIndex)
    {
        int achievementIndex = 3 * section + pointIndex;
        if (AchievementIsUnlock(achievementIndex))
        {
            ToggleAchievementButton(pointIndex);
        }
    }
    bool AchievementIsUnlock(int index)
    {
        return achievements[index].isUnlock;
    }
    void ToggleAchievementButton(int pointIndex)
    {
        GameObject imageObj = GetImageObj(pointIndex);
        GameObject descriptionObj = GetDescriptionObj(pointIndex);
        imageObj.SetActive(!imageObj.activeSelf);
        descriptionObj.SetActive(!descriptionObj.activeSelf);
    }
    GameObject GetImageObj(int pointIndex)
    {
        return points[pointIndex].transform.GetChild(0).gameObject;
    }
    GameObject GetDescriptionObj(int pointIndex)
    {
        return points[pointIndex].transform.GetChild(1).gameObject;
    }
    GameObject GetLockPanel(int pointIndex)
    {
        return points[pointIndex].transform.GetChild(2).gameObject;
    }
    public void LeftButton()
    {
        section--;
        RefreshPanel();
    }
    public void RightButton()
    {
        section++;
        RefreshPanel();
    }
    public void CloseButton()
    {
        gameObject.SetActive(false);
    }
    void ShowLeftRightButton()
    {
        if(section != 0)
        {
            leftButton.SetActive(true);
        }
        else
        {
            leftButton.SetActive(false);
        }

        bool isLastSection = section * 3 + 3 == achievements.Length;
        if(isLastSection)
        {
            rightButton.SetActive(false);
        }
        else
        {
            rightButton.SetActive(true);
        }
    }
    void CheckAchievementUnlock(int pointIndex , int achievementIndex)
    {
        if (achievements[achievementIndex].isUnlock)
        {
            GetLockPanel(pointIndex).SetActive(false);
        }
        else
        {
            GetLockPanel(pointIndex).SetActive(true);
        }
    }
}
