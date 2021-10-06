using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// this script lets us create new weapon items through the create asset menu inside of unity, and
/// it sets the item type automatically for us, so we don't need to think about that :)
/// </summary>

[CreateAssetMenu(fileName = "New Weapon Item", menuName = "Invetory System/Items/Weapon")]
public class WeaponObject : ItemObject
{
    public int dmg;
    public void Awake()
    {
        type = ItemType.Weapon;
    }
}
