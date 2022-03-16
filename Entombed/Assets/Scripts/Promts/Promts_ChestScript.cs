using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Promts_ChestScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        if(EnableRotationForLooseLockPiece.itemHasBeenPickedUp == false){
            ShowPromtsScript.chestHasBeenClickedOn = true;
        }
            
    }
}
