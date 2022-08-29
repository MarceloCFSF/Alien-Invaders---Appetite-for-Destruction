using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public GameObject player;
    private Inventory inventory;

    [Header("Life")]
    public int maxHealth = 100;
    public int health;
    public HealthBar healthBar;

    void Start() {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        inventory = player.GetComponent<Inventory>();
    }

    public void TakeDamage(int damage) {
        if (!healthBar.gameObject.activeSelf) {
            healthBar.gameObject.SetActive(true);
        }

        health -= damage;
        healthBar.SetHealth(health);

        if (health <= 0) {
            Die();
        }
    }

    void Die() {
        inventory.PlantCollected();
        gameObject.SetActive(false);
    }
}
