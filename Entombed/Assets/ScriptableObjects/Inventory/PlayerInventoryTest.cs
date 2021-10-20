using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is a plyer script the player will have to have to be able to pickup the items
/// </summary>
public class PlayerInventoryTest : MonoBehaviour
{
    public InventoryObject inventory;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
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
        inventory.Container.Clear();
    }
    
}
