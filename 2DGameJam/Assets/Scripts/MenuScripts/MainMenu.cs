using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button continueButton;
    public TextMeshProUGUI continueText;
    private SaveData saveData;
    private void Start()
    {
        Time.timeScale = 1f;
        continueButton.interactable = false;
        continueText.color = new Color(1, 1, 1, 0.5f);
        GetData();
        GlobalControl.instance.playerHP = 0;
        GlobalControl.instance.playerPoints = 0;
        GlobalControl.instance.currentLevel = 0;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Continue()
    {
        GlobalControl.instance.playerHP = saveData.fields.playerHP.integerValue;
        GlobalControl.instance.playerPoints = saveData.fields.playerPoints.integerValue;
        GlobalControl.instance.currentLevel = saveData.fields.currentLevel.integerValue;
        PlayerPrefs.SetString("Character", saveData.fields.character.stringValue);
        SceneManager.LoadScene("SaveArea");
    }

    private void GetData()
    {
        string userId = GlobalControl.instance.userId;
        if (!string.IsNullOrEmpty(userId))
        {
            SaveDataDAO.GetSaveDataByUser(userId)
                .Then(response => {
                    if (response != null)
                    {
                        saveData = response;
                        continueButton.interactable = true;
                        continueText.color = new Color(1, 1, 1, 1);
                    }else
                    {
                        continueButton.interactable = false;
                    }}).Catch(error => {
                        continueButton.interactable = false;
                        Debug.Log("Something went wrong: " + error);
                    });
        }else
        {
            continueButton.interactable = false;
        }
    }
}
