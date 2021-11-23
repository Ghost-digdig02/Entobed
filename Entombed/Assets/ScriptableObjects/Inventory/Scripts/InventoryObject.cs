using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory Syste/Inventory" )]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    public string savePath;
    public ItemDatabaseObject database;
    public Inventory Container;


    public void AddItem(Item _item, int _amount)
    {      

        for (int i = 0; i < Container.Items.Length; i++)//here we check if we have the item in the inventory
        {
            if (Container.Items[i].ID == _item.Id)
            {
                Container.Items[i].AddAmount(_amount);
                return;
            }
        }

        SetEmptySlot(_item, _amount);

    }
    public InventorySlot SetEmptySlot(Item _item, int _amount) //function to find the first empty slot in the inventory
    {
        for (int i = 0; i < Container.Items.Length; i++)
        {
            if (Container.Items[i].ID <= -1)
            {
                Container.Items[i].UpdateSlot(_item.Id, _item, _amount);
                return Container.Items[i];
            }
        }
        
        return null; //this can be changed depending on what happens when your inventory is full. I will leave it like this since the player in this game will be able to hold every item they will need in their inventory
    }

    public void Save() //save method 
    {
        Debug.Log("save");
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath)); // using string.Concat takes up less space and creates less garbage collection that using "" + ""
        bf.Serialize(file, saveData);
        file.Close();

    }

    public void Load() //load method
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            Debug.Log("load");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close(); //closing the file after we're done makes sure that we don't have any memoryleaks
        }
    }

    public void OnAfterDeserialize() // is used as soon as something changes on a scriptable object that cuses unity to need to serialize that object
    {
  //      for (int i = 0; i < Container.Items.Count; i++) //looks through all the items in our container and makes sure that all item matches with their item id
  //      { 
  /////          Container.Items[i].item = database.GetItem[Container.Items[i].ID]; Fix this when you have the enery
  //      } 
    }

    public void OnBeforeSerialize() //this needs to be here since we are using the OnAfterdeserialize from the ISerializationCallbackReceiver
    {
        
    }
}

[System.Serializable]
public class Inventory
{    
    public InventorySlot[] Items = new InventorySlot[18]; 
}

[System.Serializable]
public class InventorySlot
{
    public int ID;
    public Item item;
    public int amount; //how many of the items that is in the inventory
    public InventorySlot() //default constructor for the class
    {
        ID = -1;
        item = null;
        amount = 0;

    }
    public InventorySlot( int _id, Item _item, int _amount) //a constructor for the class
    {
        ID = _id;
        item = _item;
        amount = _amount;

    }
    public void UpdateSlot(int _id, Item _item, int _amount) //a constructor for the class
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
