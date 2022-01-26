using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockChestScript : MonoBehaviour
{
    public static bool chestIsUnlocked = false;
    public GameObject[] lockParts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lockParts[0].transform.rotation.z == 504 && lockParts[1].transform.rotation.z == 0 && 
            lockParts[2].transform.rotation.z == 72 && lockParts[3].transform.rotation.z == 72)
        {
            chestIsUnlocked = true;
        }

        if(chestIsUnlocked == true) { OpenChest(); }
    }

    public void OpenChest()
    {

    }
}
