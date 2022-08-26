using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Inventory inventory = other.GetComponent<Inventory>();

            if (inventory) {
                inventory.PlantCollected();
                gameObject.SetActive(false);
            }
        }
    }
}