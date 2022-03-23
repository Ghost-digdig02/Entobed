using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used together with the KeyToLockedDoorSCript and UnlockTheDoorScript, and what these three scripts do together is that they enable the player
/// to pick up the key and unlock the door that leads to the locked room
/// </summary>
public class PickUpTheKey : PickUpObjectsBaseScript
{
    public GameObject theKey;
    private void Update()
    {
        //if the key has been clicked, the player will now hold it in their hand
        if (KeyToLockedDoorSCript.keyHasbeenPickedUp == true) { HoldItem(theKey); }
        //if the player clicks on the door after they have picked up the key, the key will dissapear from their hand since they now have used it
        if (UnlockTheDoorScript.theDoorHasBeenClicked == true) { Destroy(theKey); }
    }
}
