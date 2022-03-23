using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemChildScript : PickUpObjectsBaseScript
{
    public GameObject thisItem;
    private float distanceToPlayer;
    private void FixedUpdate()
    {
        distanceToPlayer = Vector3.Distance(thisItem.transform.position, guide.transform.position); //the distance between the player and the item - the player will only be able to pick up the items if they are close enough to it.
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

        if (Input.GetMouseButtonDown(1) == false && holdingObject == true) //is used when the player doesn't want to hold an object anymore
        {
            LetGoOfItem(thisItem);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        LetGoOfItem(thisItem);
    }
}
