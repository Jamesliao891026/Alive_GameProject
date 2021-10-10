using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;
    public GameObject uiManager;

    // Start is called before the first frame update
    void Start()
    {
        if(Player.instance == null)
        {
            Player clone = Instantiate(player).GetComponent<Player>();
            //Player.instance = clone;
        }
        if(GameManager.instance == null)
        {
            GameManager clone = Instantiate(gameManager).GetComponent<GameManager>();
            //GameManager.instance = clone;
        }
        if (UIManager.instance == null)
        {
            UIManager clone = Instantiate(uiManager).GetComponent<UIManager>();
            //UIManager.instance = clone;
        }
    }

}
