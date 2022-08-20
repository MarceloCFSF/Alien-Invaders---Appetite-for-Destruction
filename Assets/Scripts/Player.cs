using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float attackRange = 1f;
    public LayerMask collectableLayers;
    public int attackStrength = 20;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector2 position = transform.position;
        position.x = position.x + 0.1f * horizontal;
        position.y = position.y + 0.1f * vertical;
        transform.position = position;

        if (Input.GetKeyDown(KeyCode.Space)) {
            Attack();
        }
    }

    void Attack() {
        Collider2D[] hitPlants = Physics2D.OverlapCircleAll(transform.position, attackRange, collectableLayers);

        foreach (Collider2D collectable in hitPlants)
        {
            collectable.GetComponent<Plant>().TakeDamage(attackStrength);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
