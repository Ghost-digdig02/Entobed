using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryTest : MonoBehaviour
{
    public InventoryObject inventory;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        var item = other.GetComponent<ItemOnetest>();

        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
       
        
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
    
}
