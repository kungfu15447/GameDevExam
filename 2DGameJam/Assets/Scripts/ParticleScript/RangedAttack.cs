using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public float damage;
    public float speed;
    public float timeUntilDestroy = 1f;

    private Rigidbody2D rb2d;
    private Vector2 direction;
    private SpriteRenderer spriteRenderer;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        SetDirection();
        FlipSprite();
        Destroy(gameObject, timeUntilDestroy);
    }

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" && collision.tag != "EnemyAttack" && collision.tag != "EnemyAware")
        {
            if (collision.tag == "Enemy")
            {
                collision.GetComponent<EnemyStats>().DoDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    private void SetDirection()
    {
        float defaultTravelValue = 1;
        float horizontal = player.GetHorizontal();
        float vertical = player.GetVertical();

        if (horizontal == 0 && vertical == 0)
        {
            direction.x = defaultTravelValue;
        }else
        {
            if (horizontal != 0 && vertical !=0)
            {
                direction.x = horizontal;
            }else
            {
                direction.x = horizontal;
                direction.y = vertical;
            }
        }
    }

    private void FlipSprite()
    {
        float rotateAngleValue = 90f;
        if (direction.x != 0 && direction.y != 0)
        {
            if (direction.x > 0)
            {
                spriteRenderer.flipX = false;
            } else
            {
                spriteRenderer.flipY = true;
            }
        }else
        {
            if (direction.y != 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotateAngleValue * direction.y));
            }
            spriteRenderer.flipX = (direction.x < 0);
        }
    }
}
