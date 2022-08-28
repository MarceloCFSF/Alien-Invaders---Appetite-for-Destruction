using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{

    public GameObject pickup;
    public Sprite pickupImage;
    
    [Header("Life")]
    public int maxHealth = 100;
    public int health;
    public HealthBar healthBar;

    void Start() {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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
        gameObject.SetActive(false);

        GameObject instance = Instantiate(pickup, transform.position, transform.rotation) as GameObject;
        instance.GetComponent<SpriteRenderer>().sprite = pickupImage;
    }
}
