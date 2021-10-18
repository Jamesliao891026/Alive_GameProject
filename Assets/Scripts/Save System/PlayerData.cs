using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public float[] PlayerPosition;
    public PlayerData(Player player) // constructor
    {
        player = Player.instance;
        PlayerPosition = new float[3];
        PlayerPosition[0] = player.transform.position.x;
        PlayerPosition[1] = player.transform.position.y;
        PlayerPosition[2] = player.transform.position.z;
    }
}
