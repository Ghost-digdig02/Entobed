using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Add this sctipt to the Item you want to be able to pick up
/// </summary>
public class PickUpObjects : MonoBehaviour
{
    public GameObject item;
    public GameObject tempParent;
    public Transform guide;
    private bool mouseDown;
    private bool holdingObject;
    
    public Collider guideCol;
    
    void Start()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        mouseDown = false;
        holdingObject = false;
    }

    private void FixedUpdate()
    {
        if (holdingObject == true && Input.GetMouseButton(1)) //adds the item to the player's inventory if the player klicks the item while holding it
        {
            Debug.Log("pick up item");
            guideCol.enabled = true; //this line allows the item the player is holding to enter the player's inventory (the inventory pick up system is based around colliders)
            Debug.Log(guideCol.enabled);
            holdingObject = false;
        }

        if(mouseDown == true && holdingObject == false) //is used if the player clicks on an item the want to pick up
        {
            holdItem();
        }

        if(mouseDown == false && holdingObject == true) //is used when the player doesn't want to hold an object anymore
        {
            LetGoOfItem();
        }
    }

    void OnMouseDown() //this void is used when the player clicks on an object
    {
        if (mouseDown == true) { mouseDown = false;}
        else { 
            mouseDown = true;
            guideCol.enabled = false;
        }    

    }

    void holdItem() //this void allowes the player to pick up an item (it changes the position of the item the player clicked to where the guide is (the player's "hand")
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;

        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;

        item.transform.parent = tempParent.transform;

        holdingObject = true;

        Debug.Log("holding item");
    }

    void LetGoOfItem() //this void allows the player to put the item back down
    {
        guideCol.enabled = false;

        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;

        item.transform.parent = null;
        item.transform.position = guide.transform.position;

        holdingObject = false;
        Debug.Log("letting go of item");
    }

}
