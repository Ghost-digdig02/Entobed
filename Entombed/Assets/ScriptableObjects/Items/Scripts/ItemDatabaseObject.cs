using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is a item database holder that will hold our items. It is used while saving and loading objects
/// </summary>

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory Syst/Items/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    [TextArea(15, 20)]
    public string description; //holds a description so I'll remeber better were to put the right stuff
    public ItemObject[] Items;
    public Dictionary<ItemObject, int> GetId = new Dictionary<ItemObject, int>(); //here I use two dictionaries (for the purpose of the item database), 
    public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>();

    public void OnAfterDeserialize() //is used since Unity doesn't serialize dictionaries
    {
        GetId = new Dictionary<ItemObject, int>();
        GetItem = new Dictionary<int, ItemObject>();
        for (int i = 0; i < Items.Length; i++)
        {
            GetId.Add(Items[i], i);
            GetItem.Add(i, Items[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        //this is not used, but it still needs to be here since we use ISerializationCallbackReceiver :)
    }
}
