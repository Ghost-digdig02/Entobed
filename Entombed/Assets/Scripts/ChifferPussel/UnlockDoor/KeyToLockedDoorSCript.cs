using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script is used together with the PickUpTheKey-script and the UnlockTheDoorScript, and what these three scripts do together is that they enable the player
/// to pick up the key and unlock the door that leads to the locked room
/// </summary>
public class KeyToLockedDoorSCript : MonoBehaviour
{
    public static bool keyHasbeenPickedUp;

    private void Start()
    {
        keyHasbeenPickedUp = false;
    }
    public void OnMouseDown()
    {
        //if the player clicks on the key, they will pick it up
        keyHasbeenPickedUp = true;
    }
}


