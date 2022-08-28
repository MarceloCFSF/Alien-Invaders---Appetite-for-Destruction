using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //variavel animação
    public PlayerAnimationController playerAnim;
    //tela de perdeu
    [SerializeField] private GameObject loseGame;


    [Header("Attack")]
    public float attackRange = 1f;
    public Transform attackPoint;
    public LayerMask attackLayer;
    public int attackStrength = 20;

    [Header("Life")]
    public int maxHealth = 100;
    public int health;
    public HealthBar healthBar;

    private void Start() {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector2 position = transform.position;
        position.x = position.x + 0.1f * horizontal;
        position.y = position.y + 0.1f * vertical;
        transform.position = position;
        playerAnim.PlayAnimation("playerWalk");


        if (Input.GetKeyDown(KeyCode.Space)) {
            Attack();
        }
    }

    void Attack() {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, attackLayer);

        foreach (Collider2D collectable in hits) {
            if (collectable.gameObject.CompareTag("Plant")) {
                collectable.GetComponent<Plant>().TakeDamage(attackStrength);
                //animação do player atacando
                playerAnim.PlayAnimation("playerAtaque");
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void TakeDamage(int damage) {
        if (!healthBar.gameObject.activeSelf) {
            healthBar.gameObject.SetActive(true);
            //animação do player sendo prejudicado
            playerAnim.PlayAnimation("playerAtacado");
        }

        health -= damage;
        healthBar.SetHealth(health);

        if (health <= 0) {
            Die();
        }
    }

    void Die() {
        //SceneManager.LoadScene("Intro");
        //ativa a imagem de perdedor
        loseGame.SetActive(true);
    }
}
