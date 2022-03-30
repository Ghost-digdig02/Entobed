using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script is used for the cipher puzzle. It checks if the correct password has been entered, and if it has, it will unlock the chest so
/// the player can grab the key that is inside the chest. (the key is currently ontop of the chest since you cannot open the model(but that will be fixed))
/// </summary>

public class UnlockChestScript : MonoBehaviour
{
    public static bool chestIsUnlocked = false;
    private bool chestHasBeenOpened = false;
    public GameObject doorKey;
    public GameObject[] Chest;

    void FixedUpdate()
    {
        //checks the rotation of the wheels and unlocks the chest if the rotations are right
        if (RoteraL�sDelar1.rotationsDone == 2 && RoteraL�sDelar2.rotationsDone == 0 && RoteraL�sDelar3.rotationsDone == 1 && RoteraL�sDelar4.rotationsDone == 4)
        {
            chestIsUnlocked = true;          
        }
        if (chestIsUnlocked == true) { OpenChest(); }
    }


    public void OpenChest()
    {
        if (chestHasBeenOpened = false) { doorKey.SetActive(true); }
        foreach(GameObject chestpart in Chest)
        {
            chestpart.SetActive(false); 
        }
        chestHasBeenOpened = true;
    }
}
