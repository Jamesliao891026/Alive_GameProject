using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    public string areaToLoad;

    //example:B3-1
    //B3 : means current scene
    //1 : means the index of exit area on this scene -> 1-2 , 1-3 for example
    public string areaTransitionName;

    public AreaEntrance entrance;

    // Start is called before the first frame update
    void Start()
    {
        entrance.transitionName = areaTransitionName;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SceneManager.LoadScene(areaToLoad);

            Player.instance.areaTransitionName = areaTransitionName;
        }
    }
}
