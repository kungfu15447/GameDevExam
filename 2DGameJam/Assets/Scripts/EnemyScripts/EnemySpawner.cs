using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject topLeftPoint;
    public GameObject bottomRightPoint;
    public LevelManager levelManager;
    public int maxSpawnNumber;
    public int spawnCooldown;
    private int spawned = 0;
    List<GameObject> spawnedBeings;

    // Start is called before the first frame update
    void Start()
    {
        spawnedBeings = new List<GameObject>();
        StartCoroutine(SpawnEnemies());
    }

    internal void RemoveMonster(GameObject gameObject)
    {
        levelManager.maxMonsterCount--;
        spawnedBeings.Remove(gameObject);
    }

    private IEnumerator SpawnEnemies()
    {
        while(true)
        {
            if (spawned < maxSpawnNumber)
            {
                float x = Random.Range(topLeftPoint.transform.position.x, bottomRightPoint.transform.position.x);
                float y = Random.Range(bottomRightPoint.transform.position.y, topLeftPoint.transform.position.y);
                GameObject spawnedPrefab = Instantiate(prefab, new Vector2(x, y), Quaternion.identity);
                spawnedPrefab.GetComponent<EnemyStats>().enemySpawner = this;
                spawnedBeings.Add(spawnedPrefab);
            }
            spawned++;
            yield return new WaitForSeconds(spawnCooldown);
        }
    }
}
