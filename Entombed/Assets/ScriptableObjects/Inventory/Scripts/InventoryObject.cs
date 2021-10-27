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
    private ItemDatabaseObject database;
    public List<InventorySlot> Container = new List<InventorySlot>(); //a list that contains all the items in the inventory

    private void OnEnable()
    {
#if UNITY_EDITOR
        database = (ItemDatabaseObject)AssetDatabase.LoadAssetAtPath("Assets/Resourses/TestDatabase.asset", typeof(ItemDatabaseObject)); //the assetpath will be different for the real database we'll use. it should be "Assets/Resourses/TheGamesInventoryDataBase.asset"
#else
        database = Resources.Load<ItemDatabaseObject>("Database");
#endif
    }

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
