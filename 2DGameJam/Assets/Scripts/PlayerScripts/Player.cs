using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject attackSprite;
    public Vector2 movement;
    public new string name = "Default";
    public float maxHealth = 100f;
    public float horizontalAttackDistance;
    public float verticalAttackDistance;

    private Rigidbody2D rb2D;
    private Animator animator;
    private GameObject attackPoint;
    private bool isPlaying;
    private float currentHealth;
    private HealthBar healthBar;
    private float horizontal = 0;
    private float vertical = 0;
    // Start is called before the first frame update
    void Start()
    {
        LoadPlayer();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        animator.SetFloat("health", currentHealth);

        attackPoint = gameObject.transform.GetChild(0).gameObject;
        isPlaying = false;

        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1f)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (movement.x != 0 || movement.y != 0)
            {
                horizontal = movement.x;
                vertical = movement.y;
            }
            AttackPoint();
            Movement();
            Attacking();
        }
    }

    private void FixedUpdate()
    {
        if (isPlaying)
        {
            rb2D.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            rb2D.bodyType = RigidbodyType2D.Dynamic;
        }
        rb2D.MovePosition(rb2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void Movement()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void Attacking()
    {
        if (!isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                animator.Play("Attack");
                Attack();
            }
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            isPlaying = true;
            animator.SetFloat("Horizontal", horizontal);
            animator.SetFloat("Vertical", vertical);
        }
        else
        {
            isPlaying = false;
        }
    }

    private void Attack()
    {
        Instantiate(attackSprite, attackPoint.transform.position, Quaternion.identity);
    }

    private void AttackPoint()
    {
        if (horizontal == 0 && vertical == 0)
        {
            attackPoint.transform.localPosition = attackPoint.transform.right * horizontalAttackDistance;
        }
        else if (horizontal != 0)
        {
            attackPoint.transform.localPosition = attackPoint.transform.right * horizontalAttackDistance * horizontal;
        }
        else if (vertical != 0)
        {
            attackPoint.transform.localPosition = attackPoint.transform.up * verticalAttackDistance * vertical;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        animator.SetFloat("health", currentHealth);
    }

    public void GetHealth(float health)
    {
        if (currentHealth + health <= maxHealth)
        {
            currentHealth += health;
        }
        else
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
        animator.SetFloat("health", currentHealth);
    }

    public void SavePlayer()
    {
        if (currentHealth <= 0)
        {
            GlobalControl.instance.playerHP = maxHealth;
        }
        else
        {
            GlobalControl.instance.playerHP = currentHealth;
        }
    }

    public void LoadPlayer()
    {
        currentHealth = GlobalControl.instance.playerHP;
    }

    public float GetHorizontal()
    {
        return horizontal;
    }

    public float GetVertical()
    {
        return vertical;
    }
}
