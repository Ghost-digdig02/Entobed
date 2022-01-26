using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script checks if the player has clicked/picked up the lockpart. This script is conected/used together with the ChifferLåsMainScript.
/// </summary>
public class EnableRotationForLooseLockPiece : MonoBehaviour
{
    public static bool itemHasBeenPickedUp = false;   

    private void OnMouseDown()
    {
        itemHasBeenPickedUp = true;
        Debug.Log("lockpart has been clicked");
    }
}
