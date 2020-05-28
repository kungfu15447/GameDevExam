using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float travelSpeed = 5f;
    public float timeUntilDestory = 1f;
    public float damage = 10f;
    private Rigidbody2D rb2d;
    private GameObject target;
    private float degreesToSubtract;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeUntilDestory);
        degreesToSubtract = 90f;
        rb2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDirection = (target.transform.position - transform.position).normalized * travelSpeed;
        rb2d.velocity = moveDirection;

        //This does not work without the "degreesToSubtract" variable that subtracts from the angle variable down below
        //No idea why. A reason could be how the "Bullet" gameobject is rotated. But changing the prefabs
        //rotation in the z-axis doesnt do anything. Even if its the same value as "degreesToSubtract"
        float angle = (Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg) - degreesToSubtract;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag != "Enemy" && collider.tag != "PlayerAttack" && collider.tag != "EnemyAttack" && collider.tag != "EnemyAware")
        {
            if (collider.tag == "Player")
            {
                collider.GetComponent<Player>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
