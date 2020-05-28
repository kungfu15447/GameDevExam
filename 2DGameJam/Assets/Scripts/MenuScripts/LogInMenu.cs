using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogInMenu : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TextMeshProUGUI wrongText;
    public GameObject mainMenuPanel;
    public Button logInButton;
    public Button signUpButton;
    public Button quitButton;

    private string userId;

    // Update is called once per frame
    void Update()
    {
        SetUserId();
        if (!string.IsNullOrEmpty(userId))
        {
            mainMenuPanel.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void SignUp()
    {
        DisableButtons();
        logInButton.interactable = false;
        string email = emailInput.text;
        string password = passwordInput.text;
        Authentication.SignUp(email, password).Then(response =>
        {
            Authentication.SetIdToken(response.idToken);
            Authentication.SetLocalId(response.localId);
            GlobalControl.instance.userId = Authentication.GetLocalId();
            Debug.Log("Succesfully signed up and logged in!");
            Debug.Log("Id Token: " + Authentication.GetIdToken());
            Debug.Log("Local Id: " + Authentication.GetLocalId());
            EnableButtons();
        }).Catch(error =>
        {
            wrongText.text = "Something went wrong...";
            EnableButtons();
            Debug.Log("Could not sign user up succesfully. Something went wrong: " + error);
            Debug.Log("Message: " + error.Message);
            Debug.Log("StackTrace: " + error.StackTrace);
            Debug.Log("To String: " + error.ToString());
            Debug.Log("Inner Exception: " + error.InnerException.Message);
        }).Finally(() => {
            EnableButtons();
        });
    }

    public void Login()
    {
        DisableButtons();
        string email = emailInput.text;
        string password = passwordInput.text;
        Authentication.Login(email, password).Then(response =>
        {
            Authentication.SetIdToken(response.idToken);
            Authentication.SetLocalId(response.localId);
            GlobalControl.instance.userId = Authentication.GetLocalId();
            Debug.Log("Succesfully logged in!");
            Debug.Log("Id Token: " + Authentication.GetIdToken());
            Debug.Log("Local Id: " + Authentication.GetLocalId());
            EnableButtons();
        }).Catch(error =>
        {
            wrongText.text = "Something went wrong...";
            EnableButtons();
            Debug.Log("Could not sign in user succesfully. Something went wrong: " + error);
            Debug.Log("Message: " + error.Message);
            Debug.Log("StackTrace: " + error.StackTrace);
            Debug.Log("To String: " + error.ToString());
            Debug.Log("Inner Exception: " + error.InnerException.Message);
        }).Finally(() => {
            EnableButtons();
        });
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void SetUserId()
    {
        userId = GlobalControl.instance.userId;
    }

    private void DisableButtons()
    {
        logInButton.interactable = false;
        signUpButton.interactable = false;
        quitButton.interactable = false;
    }

    private void EnableButtons()
    {
        logInButton.interactable = true;
        signUpButton.interactable = true;
        quitButton.interactable = true;
    }
}
