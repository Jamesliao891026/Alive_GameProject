using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_WatchUI : MonoBehaviour
{
    public GameObject ai_watchUI;
    public void OpenUI()
    {
        ai_watchUI.SetActive(true);
    }
    public void CloseUI()
    {
        ai_watchUI.SetActive(false);
    }
    public void MainMenuButton()
    {
        Debug.Log("Go To MainMenu Scene.");
    }
    public void SaveButton()
    {
        Debug.Log("Save!");
    }
    public void LoadButton()
    {
        Debug.Log("Load!");
    }
    public void SettingsButton()
    {
        Debug.Log("Open Settings Panel!");
    }
    public void StaffButton()
    {
        Debug.Log("Open Stuff Panel");
    }
    public void ExitButton()
    {
        Debug.Log("Exit!");
        Application.Quit();
    }
}
