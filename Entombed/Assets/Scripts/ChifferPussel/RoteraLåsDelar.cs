using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoteraLåsDelar : MonoBehaviour
{
    [SerializeField]
    private GameObject lockPart;
    public float lockPartRotaion;
    private int rotationsDone = 0;
    private bool resetRotationsDone;


    private void Update()
    {
        if (rotationsDone == 5) { resetRotationsDone = true; }
        
        if(resetRotationsDone == true)
        {
            rotationsDone = 0;
            resetRotationsDone = false;
        }

        lockPartRotaion = lockPart.transform.rotation.z;
        if( rotationsDone < 5) { lockPartRotaion = 72;}
    }

    private void OnMouseUp()
    {
        if (UnlockChestScript.chestIsUnlocked == false) { Rotate(); }
    }

    void Rotate() //method to rotate the object
    {
        lockPart.transform.Rotate(0, 0, lockPartRotaion);
        rotationsDone += 1;
    }
}
