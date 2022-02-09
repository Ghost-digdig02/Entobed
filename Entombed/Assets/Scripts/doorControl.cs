using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorControl : MonoBehaviour
{

    [SerializeField] private Animator door = null;

    [SerializeField] private bool openTrigger = false;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                door.Play("doorOpening", 0, 0.0f);
                //gameObject.SetActive(false);
            }
        }

    }

}
