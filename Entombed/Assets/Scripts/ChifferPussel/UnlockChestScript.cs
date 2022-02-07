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
    public GameObject doorKey;
    public GameObject[] Chest;

    void FixedUpdate()
    {
        //checks the rotation of the wheels and unlocks the chest if the rotations are right
        if (RoteraLåsDelar1.rotationsDone == 2 && RoteraLåsDelar2.rotationsDone == 0 && RoteraLåsDelar3.rotationsDone == 1 && RoteraLåsDelar4.rotationsDone == 4)
        {
            chestIsUnlocked = true;          
        }
        if (chestIsUnlocked == true) { OpenChest(); }
    }


    public void OpenChest()
    {
        doorKey.SetActive(true);
        foreach(GameObject chestpart in Chest)
        {
            chestpart.SetActive(false); 
        }
    }
}
