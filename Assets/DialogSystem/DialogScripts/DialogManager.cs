using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject branchingCanvas; // 對話框介面ui
    [SerializeField] private GameObject choicePrefab; // 文本內的選擇對話走向內容 
    [SerializeField] private TextAssetValue dialogValue; // 對話文本
    [SerializeField] private GameObject dialogHolder; // 要放置對話內容的地方(他的父親)
    [SerializeField] private GameObject choiceHolder; // 要放置選擇對話走向內容的地方(他的父親)

    [SerializeField] private Story myStory; // 故事
    [SerializeField] private Text textPrefab = null; // 對話預製物件
    [SerializeField] private bool goOn = false;
    [SerializeField] private bool MakingChoices = false;
    [SerializeField] private bool DontPressSpace = false;

    void Update() {
        if (DialogNPC.isTalking) {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UpdateDialogs();
            }
            if (myStory.currentChoices.Count > 0 && MakingChoices == true)
            {
                MakeNewChoices(); // 新的選擇
                MakingChoices = false;
            }
            else if (myStory.currentChoices.Count == 0)
            {
                for (int j = 0; j < choiceHolder.transform.childCount; j++)
                {
                    Destroy(choiceHolder.transform.GetChild(j).gameObject);
                }
            }
            else
            {
                return;
            }
        }
    }

    public void EnableCanvas()
    { // 控制ui及觸發對話事件
        branchingCanvas.SetActive(true);
        SetStory();
        if (myStory.canContinue)
        {
            // Continue gets the next line of the story
            string text = myStory.Continue();
            // This removes any white space from the text.
            text = text.Trim();
            // Display the text on screen!
            CreateContentView(text);
        }
    }

    public void UpdateDialogs() {
        if (myStory.canContinue)
        {
            if (dialogHolder.GetComponentsInChildren<Transform>(true).Length > 1)
            {
                Destroy(dialogHolder.transform.GetChild(0).gameObject);
            }
            // Continue gets the next line of the story
            string text = myStory.Continue();
            // This removes any white space from the text.
            text = text.Trim();
            // Display the text on screen!
            CreateContentView(text);
        }
        // !!對話時，按按鈕(回應)時按按鍵應該要無效
        else if (!myStory.canContinue && DontPressSpace == true) {
            return;
        }
        else
        {
            branchingCanvas.SetActive(false);
        }
    }

    // Creates a textbox showing the the line of text
    void CreateContentView(string text)
    {
        Text storyText = Instantiate(textPrefab) as Text;
        storyText.transform.SetParent(dialogHolder.transform, false);
        StopAllCoroutines();
        if (myStory.currentChoices.Count > 0)
            DontPressSpace = true;
        StartCoroutine(TypeSentence(text, storyText));
    }

    public void SetStory()
    { // 設置故事
        if (dialogValue.value)
        {
            DelectOldDialogs();
            myStory = new Story(dialogValue.value.text);
        }
        else
        {
            Debug.Log("No Dialog!");
        }
    }
    void DelectOldDialogs()
    { // 將前一次選擇對話清除
        for (int i = 0; i < dialogHolder.transform.childCount; i++)
        {
            Destroy(dialogHolder.transform.GetChild(i).gameObject);
        }
        for (int j = 0; j < choiceHolder.transform.childCount; j++)
        {
            Destroy(choiceHolder.transform.GetChild(j).gameObject);
        }
    }

    IEnumerator TypeSentence(string sentence, Text storyText) {
        /*if (sentence.Substring(1, 1) == "我") {
            Debug.Log("656565656");
        }*/
            foreach (char letter in sentence.ToCharArray()) {
            storyText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        if (myStory.currentChoices.Count > 0) {
            MakingChoices = true;
        }
        if (goOn == true)
        {
            yield return new WaitForSeconds(1f);
            UpdateDialogs();
            goOn = false;
        }
    }

    void MakeNewResponse(string newDialog, int choiceValue)
    {  // 建立新的對話選擇並放置到choiceHolder下方
        ResponseObject newResponseObject =
            Instantiate(choicePrefab, choiceHolder.transform).GetComponent<ResponseObject>();
        newResponseObject.Setup(newDialog, choiceValue);  // 將對話選擇放置到TMP文本內
        Button responseButton = newResponseObject.gameObject.GetComponent<Button>();
        if (responseButton)
        { // 若按下某一個選擇
            responseButton.onClick.AddListener(delegate { ChooseChoice(choiceValue); }); // 觸發該選擇的事件
        }
    }

    void MakeNewChoices()
    { // 將前一次選擇對話清除並建立新的對話選擇
        for (int i = 0; i < choiceHolder.transform.childCount; i++)
        {
            Destroy(choiceHolder.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < myStory.currentChoices.Count; i++)
        {
            MakeNewResponse(myStory.currentChoices[i].text, i); // 建立新的選擇
        }
    }

    void ChooseChoice(int choice)
    { // 將choice值傳入並更新對話
        myStory.ChooseChoiceIndex(choice);
        DontPressSpace = false;
        if (myStory.canContinue)
        {
            goOn = true;
            // Continue gets the next line of the story
            string text = myStory.Continue();
            // This removes any white space from the text.
            text = text.Trim();
            // Display the text on screen!
            if (dialogHolder.GetComponentsInChildren<Transform>(true).Length > 1)
            {
                Destroy(dialogHolder.transform.GetChild(0).gameObject);
            }
            CreateContentView(text);
        }
        else {
            UpdateDialogs();
        }
    }
}
