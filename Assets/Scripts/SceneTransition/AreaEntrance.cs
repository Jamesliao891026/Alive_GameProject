using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string transitionName;

    private void Start()
    {
        if(transitionName == Player.instance.areaTransitionName)
        {
            Player.instance.gameObject.transform.position = transform.position;
        }
    }
}
