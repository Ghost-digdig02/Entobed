using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Add this sctipt to the Item you want to be able to pick up
/// </summary>
public class PickUpObjectsBaseScript : MonoBehaviour
{
    private float throwforce = 1000;
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
        // foreach (GameObject _item in Items) { Items[1].GetComponent<Rigidbody>().useGravity = false; }
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

    public void HoldItem(GameObject _item) //this void allowes the player to pick up an item (it changes the position of the item the player clicked to where the guide is (the player's "hand")
    {
        _item.GetComponent<Rigidbody>().useGravity = false;
        _item.GetComponent<Rigidbody>().detectCollisions = true;
        _item.GetComponent<Rigidbody>().isKinematic = true;

        _item.transform.parent = tempParent.transform;

        _item.transform.position = guide.transform.position;
        _item.transform.localPosition = new Vector3(8, 2, -1); //this is the offset from the guide position
        _item.transform.rotation = guide.transform.rotation;

        holdingObject = true;

        pickUpItemCol.enabled = true;
    }

    public void LetGoOfItem(GameObject item) //this void allows the player to put the item back down
    {
        guideCol.enabled = false;
        
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.GetComponent<Rigidbody>().detectCollisions = false;

        item.transform.parent = null;
        item.transform.position = guide.transform.position;

        item.GetComponent<Rigidbody>().AddForce(guide.transform.forward * throwforce);

        holdingObject = false;

        pickUpItemCol.enabled = false;
    }

    
}
