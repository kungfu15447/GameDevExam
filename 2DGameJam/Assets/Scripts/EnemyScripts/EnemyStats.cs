using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float health = 30f;
    public float deathThreshold = 0f;
    public int points = 0;
    public EnemySpawner enemySpawner;

    // Update is called once per frame
    void Update()
    {
        if (health <= deathThreshold)
        {
            if (enemySpawner != null)
            {
                enemySpawner.RemoveMonster(gameObject);
            }
            ScoreManager.AddToScore(points);
            Destroy(gameObject);
        }
    }

    public void DoDamage(float damage)
    {
        health -= damage;
    }
}
