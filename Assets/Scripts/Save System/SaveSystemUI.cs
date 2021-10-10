using UnityEngine;
using UnityEngine.UI;

public class SaveSystemUI : MonoBehaviour
{
    public GameObject saveSystemUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            saveSystemUI.SetActive(!saveSystemUI.activeSelf); // 目前狀態的相反狀態
        }
    }
}
