using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartManager : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject stickMan;
    public GameObject fiveDNeas;
    private GameObject player;

    private void OnEnable()
    {
        string characterName = PlayerPrefs.GetString("Character");

        switch(characterName)
        {
            case "Stickman":
                player = Instantiate(stickMan, spawnPoint.transform.position, Quaternion.identity);
                break;
            case "5Dneas":
                player = Instantiate(fiveDNeas, spawnPoint.transform.position, Quaternion.identity);
                break;
        }

        if (GlobalControl.instance.playerHP == 0)
        {
            player.GetComponent<Player>().SavePlayer();
        }
    }
}
