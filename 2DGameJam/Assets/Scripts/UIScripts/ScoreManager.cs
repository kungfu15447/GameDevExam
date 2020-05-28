using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager: MonoBehaviour
{
    private static int scoreNumber = 0;
    private TextMeshProUGUI scoretext;
    // Start is called before the first frame update
    void Start()
    {
        LoadScore();
        scoretext = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "" + scoreNumber;
    }

    public static void AddToScore(int points)
    {
        scoreNumber += points;
    }

    public static int GetScore()
    {
        return scoreNumber;
    }

    public void SaveScore()
    {
        GlobalControl.instance.playerPoints = scoreNumber;
    }

    public void LoadScore()
    {
        scoreNumber = GlobalControl.instance.playerPoints;
    }
}
