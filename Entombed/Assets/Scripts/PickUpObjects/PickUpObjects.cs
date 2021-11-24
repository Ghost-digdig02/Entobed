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
    
    public Collider col;
    
    void Start()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(2)) //adds the item to the player's inventory if you middle click
        {
            PlayerInventory.addItemToInventory();
        }
    }

    void OnMouseDown()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;
    }

    void OnMouseUp()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item.transform.position = guide.transform.position;
    }
}
