using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameManager GM;

    [Header("Movement")]
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    private Vector3 scale;

    [Header("Attack")]
    public float attackRange = 1f;
    public Transform attackPoint;
    public LayerMask attackLayer;
    public int attackStrength = 20;
    public float attackRate = 1f;
    private float nextAttackTime = 0f;

    [Header("Life")]
    public int maxHealth = 100;
    public int health;
    public HealthBar healthBar;

    private void Start() {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        scale = transform.localScale;
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x < 0) {
            transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
        } else if (movement.x > 0) {
            transform.localScale = new Vector3(scale.x, scale.y, scale.z);
        }

        if (Time.time >= nextAttackTime && Input.GetKeyDown(KeyCode.Space)) {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack() {
        animator.SetTrigger("Attack");
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, attackLayer);

        foreach (Collider2D collectable in hits) {
            if (collectable.gameObject.CompareTag("Plant")) {
                collectable.GetComponent<Plant>().TakeDamage(attackStrength);
            }
            if (collectable.gameObject.CompareTag("Animal")) {
                collectable.GetComponent<Animal>().TakeDamage(attackStrength);
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void TakeDamage(int damage) {
        health -= damage;
        animator.SetTrigger("Hurt");
        healthBar.SetHealth(health);

        if (health <= 0) {
            GM.Die();
        }
    }
}
