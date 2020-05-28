using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float damage;
    public float timerUntilDestroy;
    void Start()
    {
        Destroy(gameObject, timerUntilDestroy);
    }

    public void Trigger()
    {
        //TODO
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyStats>().DoDamage(damage);
        }
    }
}
