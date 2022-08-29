using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Inventory : MonoBehaviour
{
    public GameManager GM;
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
            GM.Win();
        }
    }

    int FindGameObjectsWithLayer (int layer) { 
        Plant[] goArray = FindObjectsOfType(typeof(Plant)) as Plant[]; 
        // List<GameObject> goList = new List<GameObject>(); 
        // for (int i = 0; i < goArray.Length; i++) { 
        //     if (goArray[i].layer == layer) { 
        //         goList.Add(goArray[i]); 
        //     }
        // }
        return goArray.Length; 
    }
}
