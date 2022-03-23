using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemChildScript : PickUpObjectsBaseScript
{
    public GameObject thisItem;
    private void FixedUpdate()
    {
        if (holdingObject == true && addItemToInventory == true) //adds the item to the player's inventory if the player klicks the item while holding it
        {
            guideCol.enabled = true; //this line allows the item the player is holding to enter the player's inventory (the inventory pick up system is based around colliders)
            holdingObject = false;
            addItemToInventory = false;
            Debug.Log("adding item to inventory");
        }

        if (mouseDown == true && holdingObject == false) //is used if the player clicks on an item the want to pick up
        {
            HoldItem(thisItem);
        }

        if (mouseDown == false && holdingObject == true) //is used when the player doesn't want to hold an object anymore
        {
            LetGoOfItem(thisItem);
        }
    }
}
