using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour
{
    public GameObject Door;
    private bool doorHasBeenClicked = false;
    private bool doorIsOpen = false;


    private float doorOpeningSpeed = 0.4f;

    private void Update()
    {
        if (doorHasBeenClicked == true && doorIsOpen == false) { OpenDoor(Door); }
        if(doorHasBeenClicked == true && doorIsOpen == true) { CloseDoor(Door); }
    }
    //method to detect id the player is clicking on the door
    private void OnMouseUp()
    {
        doorHasBeenClicked = true;
    }

    //method to open the door
    protected void OpenDoor(GameObject Door)
    {
        //Debug.Log("opening Door");
        Door.transform.rotation = Quaternion.Slerp(Door.transform.rotation, Quaternion.Euler(0, -140, 0), doorOpeningSpeed * Time.deltaTime);
        //Quaternion.Slerp will rotate the object from one position to another during a set time. the Quaternion.Euler(X,Y,Z) is how you want the door to rotate
        Invoke("ResetBool", 0.5f);
        Invoke("DoorIsOpen", 0.5f);

    }

    //method to close the door
    protected void CloseDoor(GameObject Door)
    {
        Debug.Log("closing Door");
        doorIsOpen = false;
        Door.transform.rotation = Quaternion.Slerp(Door.transform.rotation, Quaternion.Euler(0, -140, 0), doorOpeningSpeed * Time.deltaTime);
        Invoke("ResetBool", 0.5f);
        Invoke("DoorIsOpen", 0.5f);
    }

    protected void ResetBool()
    {
        doorHasBeenClicked = false;
    }

    protected void DoorIsOpen()
    {
        if(doorIsOpen == true) { doorIsOpen = false; }
        else { doorIsOpen = true; }
    }
}
