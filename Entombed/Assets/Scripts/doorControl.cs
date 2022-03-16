using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorControl : MonoBehaviour
{

    private Camera mainCamera;

    [SerializeField] private Animator door = null;

    [SerializeField] private bool openTrigger = false;

    /*  private void ()
      {

          if (other.CompareTag("Player"))
          {
              if (openTrigger)
              {
                  door.Play("doorOpening", 0, 0.0f);
                  //gameObject.SetActive(false);
              }
          }

      }*/

    private void Awake()//?
    {

        mainCamera = Camera.main;

    }


    private void DetectObject()
    {

        Ray ray= mainCamera.ScreenPointToRay

    }

}
