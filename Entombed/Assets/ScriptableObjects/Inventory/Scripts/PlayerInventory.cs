using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is a plyer script the player will have to have to be able to pickup the items
/// </summary>
public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;


    public void addItemToInventory(Collider other)
    {
        var item = other.GetComponent<GroundItem>();
        if (item)
        {
            inventory.AddItem(new Item(item.item), 1);
            Destroy(other.gameObject);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //change these later
        {
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.L)) //change these later
        {
            inventory.Load();
        }
    }

    private void OnApplicationQuit()
    {
       inventory.Container.Items = new InventorySlot[18];
    }
    
}
