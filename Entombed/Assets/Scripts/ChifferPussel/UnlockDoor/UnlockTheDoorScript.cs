using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script is used together with the KeyToLockedDoorSCript and PickUpTheKey-script, and what these three scripts do together is that they enable the player
/// to pick up the key and unlock the door that leads to the locked room
/// </summary>
public class UnlockTheDoorScript : OpenDoorScript
{
    public static bool theDoorIsUnlocked = false;
    public static bool theDoorHasBeenClicked = false;

    private bool doorHasBeenClicked = false;
    private bool doorIsOpen = false;


    void Update()
    {
        //cheks if the key has been picked up, and if it has, the door will now be unlocked
        if(KeyToLockedDoorSCript.keyHasbeenPickedUp == true) { theDoorIsUnlocked = true; }
        if (theDoorIsUnlocked == true)
        {
            if (doorHasBeenClicked == true && doorIsOpen == false) { OpenDoor(); }
            if (doorHasBeenClicked == true && doorIsOpen == true) { CloseDoor(); }
        }
    }

    private void OnMouseUp()
    {
        if(theDoorHasBeenClicked == true) { doorHasBeenClicked = true; }

        //this is used/needed for the pickUpTheKey-script, since the other script will destory the key after the door has been clicked/opened
        if(theDoorIsUnlocked == true) { theDoorHasBeenClicked = true; }

        //write what will happen when you opend the door!!!
    }
}
