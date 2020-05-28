using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float damage = 10;
    public Vector2 movement;
    private float direction = 0;
    private int[] randomDirections = {-1, 1};
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DoMovement());
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
    }

    private IEnumerator DoMovement()
    {
        movement = new Vector2(0,0);
        int thisDir = Random.Range(0, 2);
        float seconds = Random.Range(0.5f, 1.5f);

        if (direction == 0)
        {
            movement = new Vector2(randomDirections[thisDir], 0);
            direction = 1;
        } else
        {
            movement = new Vector2(0, randomDirections[thisDir]);
            direction = 0;
        }

        yield return new WaitForSeconds(seconds);
        StartCoroutine(StandStill());
    }

    private IEnumerator StandStill()
    {
        movement = new Vector2(0,0);
        float seconds = Random.Range(0.3f, 0.4f);
        yield return new WaitForSeconds(seconds);
        StartCoroutine(DoMovement());
    }
}
