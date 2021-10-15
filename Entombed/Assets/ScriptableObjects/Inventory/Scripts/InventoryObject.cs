using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory Syste/Inventory" )]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemDatabaseObject database;
    public List<InventorySlot> Container = new List<InventorySlot>(); //a list that contains all the items in the inventory
    public void AddItem(ItemObject _item, int _amount)
    {
        
        for(int i = 0; i < Container.Count; i++)//here we check if we have the item in the inventory
        {
            if(Container[i].item == _item)
            {
               Container[i].AddAmount(_amount);
                return;              
            }          
        }    
        Container.Add(new InventorySlot(database.GetId[_item], _item, _amount));
        
    }

    public void OnAfterDeserialize() // is used as soon as something changes on a scriptable object that cuses unity to need to serialize that object
    {
        for (int i = 0; i < Container.Count; i++) //looks through all the items in our container and makes sure that all item matches with their item id
        { 
            Container[i].item = database.GetItem[Container[i].ID]; 
        } 
    }

    public void OnBeforeSerialize()
    {
        
    }
}

[System.Serializable]
public class InventorySlot
{
    public int ID;
    public ItemObject item;
    public int amount; //how many of the items that is in the inventory

    public InventorySlot( int _id, ItemObject _item, int _amount) //a constructor for the class
    {
        ID = _id;
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
