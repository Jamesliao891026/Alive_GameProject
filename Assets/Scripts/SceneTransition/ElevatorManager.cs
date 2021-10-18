using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorManager : MonoBehaviour
{
    public GameObject outsideImg, insideImg,close;

    public GameObject[] sidewayButtons; //make sure [0] is down , [1] is up.
    public enum UpOrDown { Up,Down};
    public UpOrDown upOrDown;

    bool shouldClick;

    [Header("IndsideFloorSelectPanel")]

    public GameObject[] floorButtons;

    public GameObject openSelectedButton, closeSelectedButton;

    public string[] floorSceneNames;
    private int selectedFloorIndex;

    private void Start()
    {
        PressSidewaysButtons();
        Invoke("OpenDoor",0.5f);
        GameManager.instance.ToggleEssentialLoader();
    }
    private void Update()
    {
        if(shouldClick && Input.GetMouseButtonDown(0))
        {
            shouldClick = false;
            OpenFloorSelectPanel();
        }
    }
    void PressSidewaysButtons()
    {
        Debug.Log("PressSidewaysButtons");
        if(upOrDown == UpOrDown.Up)
        {
            sidewayButtons[1].SetActive(true);
        }
        else
        {
            sidewayButtons[0].SetActive(true);
        }
    }
    void OpenDoor()
    {
        Debug.Log("OpenDoor");
        close.SetActive(false);
        shouldClick = true;
    }
    void OpenFloorSelectPanel()
    {
        outsideImg.SetActive(false);
        insideImg.SetActive(true);
    }
    public void floorButtonClick(int index)
    {
        ClearAllFloorButtons();
        floorButtons[index].SetActive(true);
        selectedFloorIndex = index;
    }
    public void OpenButtonClick()
    {
        openSelectedButton.SetActive(true);
        Debug.Log("Open The Door! Go Back Previous Scene");
        GameManager.instance.ToggleEssentialLoader();
        SceneManager.LoadScene(GameManager.instance.previousSceneName);
    }
    public void CloseButtonClick()
    {
        closeSelectedButton.SetActive(true);
        Debug.Log("Close The Door! Go To " + selectedFloorIndex + " Scene");
        GameManager.instance.ToggleEssentialLoader();
        SceneManager.LoadScene(floorSceneNames[selectedFloorIndex]);
    }
    void ClearAllFloorButtons()
    {
        for (int i = 0; i < floorButtons.Length; i++)
        {
            floorButtons[i].SetActive(false);
        }
    }
}
