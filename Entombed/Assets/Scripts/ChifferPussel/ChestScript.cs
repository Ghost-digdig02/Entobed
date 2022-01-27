using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is a script that is conected/used together with the ChifferLåsMainScript and the EnableRotationForLooseLockPiece.
/// What this script does is that it checks with the EnableRotationForLooseLockPiece script if the lock piece has been picked up or not, and if it has, 
/// this script will then chek if the player has clicked on the chest.
/// </summary>
public class ChestScript : MonoBehaviour
{
    public static bool ChestHasBeenClicked = false;

    private void OnMouseDown()
    {
        if(EnableRotationForLooseLockPiece.itemHasBeenPickedUp == true)
        {
            Debug.Log("The chest has been clicked");
            ChestHasBeenClicked = true;
            this.GetComponent<BoxCollider>().enabled = false;
        }        
    }
}
