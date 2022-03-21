using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideForThePickUpSystemScript : MonoBehaviour
{
    public float distanceFromtheCamera;
    private float actualDistance;

    private void Start()
    {
        Vector3 toObjectVector = transform.position - Camera.main.transform.position; //the distance between the object and the camera
        Vector3 toLinearPosition = Vector3.Project(toObjectVector, Camera.main.transform.forward); //calculates the actual distance between the camera and object we want (if it is a diagonal line it will be too long if we don't dp this)

        actualDistance = toLinearPosition.magnitude; //the length of the distance

        distanceFromtheCamera = actualDistance;
    
    }

    private void Update()
    {
        //sets the transform position of "this" to were the camera is with an offset on the z axis
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = distanceFromtheCamera;
        
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);

        //the offset for the items is decided in the picUpObjects script by changing the local position there
    }

}
