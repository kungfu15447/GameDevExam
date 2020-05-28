using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public GameObject menuButton;

    private void Start()
    {
        menuButton.SetActive(false);
        string userId = GlobalControl.instance.userId;
        SaveDataDAO.DeleteSaveDataOnUser(userId)
            .Then(response =>
            {
                Debug.Log("Save data deleted");
                menuButton.SetActive(true);
            }).Catch(error =>
            {
                Debug.Log("Something went wrong...");
                menuButton.SetActive(true);
            }).Finally(() => {
                menuButton.SetActive(true);
            });
    }
}
