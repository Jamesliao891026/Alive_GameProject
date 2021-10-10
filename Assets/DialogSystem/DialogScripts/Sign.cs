using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interact
{
    public GameObject mark; // 驚嘆號
    public GameObject dialogBox; // 文字框物件(控制ui開關)
    public Text dialogText; // 文字操控此文本內容
    public string dialog; // 文字

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange) {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    public override void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !other.isTrigger) {
            myNotification.Raise();
            playerInRange = true;
            mark.SetActive(true);
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            myNotification.Raise();
            playerInRange = false;
            dialogBox.SetActive(false);
            mark.SetActive(false);
        }
    }
}
