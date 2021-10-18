using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public string previousSceneName;

    public Dictionary<string,GameObject> essentialLoadingObjects;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    public void ToggleEssentialLoader()
    {
        //FindObjectOfType<GameManager>().gameObject.SetActive(!FindObjectOfType<GameManager>().gameObject.activeSelf);
        FindObjectOfType<Player>(true).gameObject.SetActive(!FindObjectOfType<Player>(true).gameObject.activeSelf);
        FindObjectOfType<UIManager>(true).gameObject.SetActive(!FindObjectOfType<UIManager>(true).gameObject.activeSelf);
    }
}
