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
        if(PickUpObjects.holdingObject == true)
        {
            PickUpObjects.addItemToInventory = true;
        }
    }
}
