using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Promts_DoorScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        ShowPromtsScript.doorHasBeenClickedOn = true;
    }
}
