using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script sets the coordinates for the guideCol
/// </summary>

public class guideColScript : MonoBehaviour
{
    public GameObject guide;

    void Start()
    {
        transform.position = guide.transform.position;
        transform.localPosition = new Vector3(8, 1, -1); 
        transform.rotation = guide.transform.rotation;
    }

}
