using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAware : MonoBehaviour
{
    private bool isAware;
    // Start is called before the first frame update
    void Start()
    {
        isAware = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isAware = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isAware = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isAware = true;
        }
    }

    public bool GetAware()
    {
        return isAware;
    }
}
