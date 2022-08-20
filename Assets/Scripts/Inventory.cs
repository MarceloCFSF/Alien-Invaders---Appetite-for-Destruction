using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public int Plants { get; private set; }

    // public UnityEvent<Inventory> OnPlantCollected;

    public void PlantCollected()
    {
        // OnPlantCollected.Invoke(this);
        Plants++;
        Debug.Log("plants: " + Plants);
        if (Plants == 5) {
            SceneManager.LoadScene("Intro");
        }
    }
}
