using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    Player player;
    private void Start()
    {
        player = Player.instance;
    }
    public void Save()
    {
        SaveSystem.SavePlayer(player);
        Debug.Log("Saving...");
    }
    public void Load()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Debug.Log("Loading...");
        Vector3 position; // player's last saved position
        position.x = data.PlayerPosition[0];
        position.y = data.PlayerPosition[1];
        position.z = data.PlayerPosition[2];
        player.transform.position = position;
    }
}
