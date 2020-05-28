using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public string[] levels;
    private string levelToTeleport;
    private GameObject player;
    public ScoreManager score;
    // Start is called before the first frame update
    void Start()
    {
        CheckForLevel();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<Player>().SavePlayer();
            score.SaveScore();
            if (levels.Length == 1)
            {
                GlobalControl.instance.currentLevel++;
            }
            SceneManager.LoadScene(levelToTeleport);
        }
    }

    private void CheckForLevel()
    {
        if (levels.Length != 0)
        {
            if (levels.Length < 2)
            {
                levelToTeleport = levels[0];
            }else
            {
                int levelIndex = GlobalControl.instance.currentLevel;
                if (levelIndex >= levels.Length)
                {
                    levelIndex = 0;
                    GlobalControl.instance.currentLevel = 0;
                }
                levelToTeleport = levels[levelIndex];
            }
        }else
        {
            Debug.Log("Something is wrong with teleporting to level...");
        }
        Debug.Log("Level has been checked!");
    }
}
