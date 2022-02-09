using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This scripts hides and opens the player's inventory when the player clicks 
/// </summary>
public class HideAndOpenInventoryScript : MonoBehaviour
{
    protected bool inventoryIsOpen;
    private GameObject inventoryCanvas;

    public void Start()
    {
        inventoryCanvas = GameObject.Find("InventoryScreen"); //change this to InventoryPanel in the reall version later
        inventoryIsOpen = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!inventoryIsOpen)
            {
                inventoryCanvas.SetActive(true);
                inventoryIsOpen = true;
            }
            else
            {
                inventoryCanvas.SetActive(false);
                inventoryIsOpen = false;
            }
        }
    }
}
