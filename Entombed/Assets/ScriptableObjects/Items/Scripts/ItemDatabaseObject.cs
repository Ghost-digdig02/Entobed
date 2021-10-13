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
    public string description; //holds a description of the item
    public ItemObject[] Items;
    public Dictionary<ItemObject, int> GetId = new Dictionary<ItemObject, int>();

    public void OnAfterDeserialize() //is used since Unity doesn't serialize dictionaries
    {
        GetId = new Dictionary<ItemObject, int>();
        for(int i = 0; i < Items.Length; i++)
        {
            GetId.Add(Items[i], i);
        }
    }

    public void OnBeforeSerialize()
    {
        
    }
}
