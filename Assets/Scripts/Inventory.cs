using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int Plants { get; private set; }

    public void PlantCollected()
    {
        Plants++;
    }
}
