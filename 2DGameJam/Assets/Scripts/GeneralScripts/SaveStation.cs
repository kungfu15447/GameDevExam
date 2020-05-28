using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStation : MonoBehaviour
{
    public GameObject saveMenu;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            saveMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
