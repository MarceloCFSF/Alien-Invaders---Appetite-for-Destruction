using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Inventory : MonoBehaviour
{
    public int Plants { get; private set; }
    private int goal;

    public void Start() {
        goal = FindGameObjectsWithLayer(LayerMask.NameToLayer("Collectable"));
        Debug.Log("Total Plants: " + goal);

    }

    public void PlantCollected()
    {
        Plants++;
        Debug.Log("plants: " + Plants);
        if (Plants == goal) {
            SceneManager.LoadScene("Intro");
        }
    }

    int FindGameObjectsWithLayer (int layer) { 
        GameObject[] goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[]; 
        Debug.Log("GameObjects: " + goArray.Length);
        Debug.Log("Layer: " + layer);
        List<GameObject> goList = new List<GameObject>(); 
        for (int i = 0; i < goArray.Length; i++) { 
            if (goArray[i].layer == layer) { 
                goList.Add(goArray[i]); 
            }
            Debug.Log("Layer Obj: " + goArray[i].layer);
        }
        return goList.Count; 
    }
}
