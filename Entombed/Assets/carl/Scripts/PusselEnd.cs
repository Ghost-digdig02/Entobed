using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PusselEnd : MonoBehaviour
{
    bool pusselVann = false;
    public void DuVann()
    {
        if (pusselVann == false)
        {
            pusselVann = true;
            Debug.Log("wow du vann");
            Hejdå();
        }
        
        void Hejdå()
        {
            
        }

    }
}
