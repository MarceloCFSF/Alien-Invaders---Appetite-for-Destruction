using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Inventory : MonoBehaviour
{
    public int Plants { get; private set; }

    public void PlantCollected()
    {
        Plants++;
        Debug.Log("plants: " + Plants);
        if (Plants == 5) {
            SceneManager.LoadScene("Intro");
        }
    }
}
