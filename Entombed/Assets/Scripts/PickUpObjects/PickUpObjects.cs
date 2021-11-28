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
    
    public Collider guideCol;
    
    void Start()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        mouseDown = false;
    }

    private void FixedUpdate()
    {
        if (mouseDown == true && Input.GetMouseButton(2)) //adds the item to the player's inventory if you middle click
        {
            Debug.Log("middleclick");
            guideCol.enabled = true;
        }
    }

    void OnMouseDown()
    {
        mouseDown = true;
        guideCol.enabled = false;

        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;
        Debug.Log("mouse down");
    }

    void OnMouseUp()
    {
        mouseDown = false;
        guideCol.enabled = true;
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item.transform.position = guide.transform.position;
        Debug.Log("mouse up");
    }
}
