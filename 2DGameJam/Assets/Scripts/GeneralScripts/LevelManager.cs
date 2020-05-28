using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameObject[] spawners;
    public int maxMonsterCount;
    public GameObject teleporter;
    // Start is called before the first frame update
    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (GameObject gb in spawners)
        {
            maxMonsterCount += gb.GetComponent<EnemySpawner>().maxSpawnNumber;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!teleporter.activeSelf && maxMonsterCount == 0)
        {
            teleporter.SetActive(true);
        }
    }
}
