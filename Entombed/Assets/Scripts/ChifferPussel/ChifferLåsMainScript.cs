using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is script is used together with the EnableRotationForLockPiece script and the ChestScript, and what this script does is that it takes
/// information from those two scripts and, depending on the outputs it gets, enables/activates the lock part on the chest. 
/// The lock piece the player finds on the floor in one of the rooms is a different gameObject than the lockpiece that is on the chest.
/// </summary>
public class ChifferLåsMainScript : MonoBehaviour
{
    public GameObject lockPart;
    void Update()
    {
        //this void checks if the lock piece has been picked up and if the player has clicked on the chest. 
        //If those two statements are true, the player will now be able to put in the right code.
        if(EnableRotationForLooseLockPiece.itemHasBeenPickedUp == true && ChestScript.ChestHasBeenClicked == true)
        {
            lockPart.SetActive(true);
            Destroy(this);
        }
    }
}
