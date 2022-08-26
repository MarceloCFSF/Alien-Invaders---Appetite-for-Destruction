using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private Text plantText;

    void Start()
    {
        plantText = GetComponent<Text>();
    }

    // Update is called once per frame
    public void UpdatePlantText(Inventory inventory)
    {
        plantText.text = inventory.Plants.ToString();
    }
}
