using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveMenu : MonoBehaviour
{
    public TextMeshProUGUI loadingText;
    public GameObject saveButton;
    public GameObject cancelButton;
    public GameObject saveMenu;

    public void SaveGame()
    {
        loadingText.text = "Loading...";
        saveButton.SetActive(false);
        cancelButton.SetActive(false);
        string userId = GlobalControl.instance.userId;
        if (!string.IsNullOrEmpty(userId))
        {
            SaveDataDAO.PatchSaveDataForUser(userId)
                .Then(response =>
                {
                    loadingText.text = "Complete!";
                    StartCoroutine(WaitToQuit());
                }).Catch(error =>
                {
                    loadingText.text = "Something went wrong...";
                    cancelButton.SetActive(true);
                });
        }else
        {
            loadingText.text = "Something went wrong...";
            cancelButton.SetActive(true);
        }
    }

    public void Cancel()
    {
        Time.timeScale = 1f;
        saveMenu.SetActive(false);
    }

    IEnumerator WaitToQuit()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        Debug.Log("This is after stuff");
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Scene should have loaded");
    }

    
}
