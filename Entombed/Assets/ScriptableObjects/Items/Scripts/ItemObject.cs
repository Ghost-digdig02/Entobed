using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script containes the base class for creating items and also a public enum for the different item types
/// </summary>
public enum ItemType
{
   Weapon, //the knife
   Equipment, //flashligth
   PuzzelClue, //items that are clues for the puzzles
   PuzzlePart, //items that are part of the puzzles
   defaultObject, //random items you can find

}

public abstract class ItemObject : ScriptableObject
{
    public int Id;
    public Sprite UiDispaly;
    public ItemType type;
    [TextArea(15,20)]
    public string description; //holds a description of the item
           
}

[System.Serializable]
public class Item
{
    public string Name;
    public int Id;
    public Item(ItemObject item)
    {
        Name = item.name;
        Id = item.Id;
    }
}