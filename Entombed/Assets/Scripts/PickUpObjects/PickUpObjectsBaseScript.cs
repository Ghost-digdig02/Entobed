using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Add this sctipt to the Item you want to be able to pick up
/// </summary>
public class PickUpObjectsBaseScript : MonoBehaviour
{
    private GameObject[] Items = new GameObject[2];
    public GameObject tempParent;
    public Transform guide;
    protected bool mouseDown;
    public static bool holdingObject;
    public static bool addItemToInventory = false;
    
    public Collider guideCol;
    public BoxCollider pickUpItemCol;
    
    void Start()
    {
        Items[1].GetComponent<Rigidbody>().useGravity = false;
        mouseDown = false;
        holdingObject = false;
    }



    protected void OnMouseDown() //this void is used when the player clicks on an object
    {
        if (mouseDown == true) { mouseDown = false;}
        else { 
            mouseDown = true;
            guideCol.enabled = false;
        }    

    }

    protected void HoldItem(GameObject item) //this void allowes the player to pick up an item (it changes the position of the item the player clicked to where the guide is (the player's "hand")
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;

        item.transform.parent = tempParent.transform;

        item.transform.position = guide.transform.position;
        item.transform.localPosition = new Vector3(8, 2, -1); //this is the offset from the guide position
        item.transform.rotation = guide.transform.rotation;

        holdingObject = true;

        pickUpItemCol.enabled = true;
    }

    protected void LetGoOfItem(GameObject item) //this void allows the player to put the item back down
    {
        guideCol.enabled = false;

        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.GetComponent<Collider>().enabled = true;

        item.transform.parent = null;
        item.transform.position = guide.transform.position;

        holdingObject = false;

        pickUpItemCol.enabled = false;
    }

}
