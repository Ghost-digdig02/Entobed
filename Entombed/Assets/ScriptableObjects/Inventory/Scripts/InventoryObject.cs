using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory Syste/Inventory" )]
public class InventoryObject : ScriptableObject
{
    public ItemDatabaseObject database;
    public List<InventorySlot> Container = new List<InventorySlot>(); //a list that contains all the items in the inventory
    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem;
        hasItem = false; //here we asume that we don't have the item in our inventory

        for(int i = 0; i < Container.Count; i++)//here we check if we have the item in the inventory
        {
            if(Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }          
        }
        if (!hasItem) //is used if the item does not already exist in the inventory
        {
            Container.Add(new InventorySlot(_item, _amount));
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount; //how many of the items that is in the inventory

    public InventorySlot(ItemObject _item, int _amount) //a constructor for the class
    {
        item = _item;
        amount = _amount;

    }
    public void AddAmount(int value)//is used when you add to the amount of items
    {
        amount += value;
    }
    public void ReduceAmount(int value) //is used when you reduce the amount of items
    {
        amount -= value;
    }
}
