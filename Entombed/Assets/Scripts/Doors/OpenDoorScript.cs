using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour
{
    public GameObject Door;
    private bool doorHasBeenClicked = false;
    private bool doorIsOpen = false;
    private float defaultRotation;
    private float opendDoorRotation;

    private void Start()
    {
        defaultRotation = Door.transform.rotation.y;
        opendDoorRotation = Door.transform.rotation.y + 90;
    }
    private void Update()
    {
        if (doorHasBeenClicked == true && doorIsOpen == false) { OpenDoor(); }
        if(doorHasBeenClicked == true && doorIsOpen == true) { CloseDoor(); }
    }
    //method to detect id the player is clicking on the door
    private void OnMouseUp()
    {
        doorHasBeenClicked = true;
    }

    //method to open the door
    private void OpenDoor()
    {
        Debug.Log("opening Door");
        Door.transform.Rotate(0, opendDoorRotation, 0);
        Invoke("ResetBool", 1f);
        Invoke("DoorIsOpen", 1);
        Debug.Log(Door.transform.rotation.y);

    }

    //method to close the door
    private void CloseDoor()
    {
        Debug.Log("closing Door");
        doorIsOpen = false;
        Door.transform.Rotate(0, defaultRotation, 0);
        Invoke("ResetBool", 1f);
        Invoke("DoorIsOpen", 1);
    }

    private void ResetBool()
    {
        doorHasBeenClicked = false;
    }

    private void DoorIsOpen()
    {
        if(doorIsOpen == true) { doorIsOpen = false; }
        else { doorIsOpen = true; }
    }
}
