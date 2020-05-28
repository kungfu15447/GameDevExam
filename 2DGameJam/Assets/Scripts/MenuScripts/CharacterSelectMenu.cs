using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectMenu : MonoBehaviour
{
    public GameObject stickMan;
    public GameObject fiveDNeas;

    public void PickedStickMan()
    {
        PlayerPrefs.SetString("Character", stickMan.GetComponent<Player>().name);
    }
    public void PickedFiveDNeas()
    {
        PlayerPrefs.SetString("Character", fiveDNeas.GetComponent<Player>().name);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
