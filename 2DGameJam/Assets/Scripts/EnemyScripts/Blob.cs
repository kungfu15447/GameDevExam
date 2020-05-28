using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour
{
    public GameObject arrow;
    public float health;
    public EnemySpawner enemySpawner;
    private float deathThreshhold;
    public float fireRate;
    private float nextFire;
    private bool justSpawned;
    private EnemyAware awareChild;
    private bool isAware;
    // Start is called before the first frame update
    void Start()
    {
        nextFire = 1f;
        nextFire = Time.time;
        deathThreshhold = 0;
        justSpawned = true;
        awareChild = GetComponentInChildren<EnemyAware>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= deathThreshhold)
        {
            Destroy(gameObject);
        }

        isAware = awareChild.GetAware();
        if (isAware)
        {
            TimeToFire();
        }
    }

    private void TimeToFire()
    {
        if (justSpawned)
        {
            StartCoroutine(IWaitToFire());
        }
        else
        {
            if (Time.time > nextFire)
            {
                Instantiate(arrow, transform.position, Quaternion.identity);
                nextFire = Time.time + fireRate;
            }
        }
    }

    IEnumerator IWaitToFire()
    {
        yield return new WaitForSeconds(fireRate);
        justSpawned = false;
    }
}
