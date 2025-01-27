using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Vector2 destination;
    Vector2 movement;
    public float speed = 3f;
    bool clickingOnSelf = false;
    public float health;
    public float maxHealth = 5;
    bool isDead;
    public HealthBar healthBar;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = maxHealth;
        isDead = false;
        PlayerPrefs.GetFloat("CurrentHP", maxHealth);
    }

    private void FixedUpdate()
    {
        if (isDead) return;
        movement = destination - (Vector2)transform.position;
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !clickingOnSelf)
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("Movement", movement.magnitude);
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void OnMouseDown()
    {
        if (isDead) return;
        clickingOnSelf = true;
        gameObject.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);

    }

    private void OnMouseUp()
    {
        clickingOnSelf = false;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        PlayerPrefs.SetFloat("CurrentHP", health);
        if (health <= 0)
        {
            isDead = true;
            animator.SetTrigger("Death");
        }
        else
        {
            isDead = false;
            animator.SetTrigger("TakeDamage");
        }
    }
}
