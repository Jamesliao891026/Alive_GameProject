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
            saveSystemUI.SetActive(!saveSystemUI.activeSelf); // �ثe���A���ۤϪ��A
        }
    }
}
