using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl instance;

    public string userId;
    public float playerHP;
    public int playerPoints;
    public int currentLevel = 0;


    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
