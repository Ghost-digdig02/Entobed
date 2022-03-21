using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemColliderScript : MonoBehaviour
{
    public BoxCollider2D col;
    void Start()
    {
        col.enabled = false;
    }

    private void OnMouseUp()
    {
        if(PickUpObjectsBaseScript.holdingObject == true)
        {
            PickUpObjectsBaseScript.addItemToInventory = true;
        }
    }
}
