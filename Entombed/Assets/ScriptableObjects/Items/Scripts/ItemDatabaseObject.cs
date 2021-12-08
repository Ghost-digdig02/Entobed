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
    public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>();

    public void OnAfterDeserialize() //is used since Unity doesn't serialize dictionaries, but I don't use a dictionary anymore? Come back an fix this bulshit...
    {       
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].Id = i;
            GetItem.Add(i, Items[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        GetItem = new Dictionary<int, ItemObject>();
    }
}
