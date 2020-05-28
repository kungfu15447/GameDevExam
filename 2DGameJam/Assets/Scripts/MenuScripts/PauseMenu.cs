using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private static bool isGamePaused;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject saveMenu;
    public HealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        isGamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (saveMenu != null)
        {
            if (!saveMenu.activeSelf)
            {
                Pausing();
            }
        }else
        {
            Pausing();
        }
    }

    private void Pause()
    {
        isGamePaused = !isGamePaused;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        isGamePaused = !isGamePaused;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void backToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    private void Pausing()
    {
        if (healthBar.GetHealth() > 0)
        {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.F1))
            {
                if (isGamePaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
#else
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
#endif
        }
        else
        {
            pauseMenu.SetActive(false);
            gameOverMenu.SetActive(true);
        }
    }
}
