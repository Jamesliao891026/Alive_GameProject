using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : Interactable
{
    public string areaTransitionName;

    public AreaEntrance entrance;

    public static Elevator instance;

    private void Start()
    {
        instance = this;
        GameManager.instance.previousSceneName = SceneManager.GetActiveScene().name;
        entrance.transitionName = areaTransitionName;
        Debug.Log(entrance.transitionName);
    }
    public override void Interact()
    {
        base.Interact();
        Player.instance.areaTransitionName = areaTransitionName;
        Debug.Log("Elevator's Open Animation!!");
        SceneManager.LoadScene("ElevatorScene");
    }
}