using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPromtsScript : MonoBehaviour
{
    public GameObject chestPromt;
    public GameObject paintingPromt1;
    public GameObject paintingPromt2;
    public GameObject doorPromt;

    private bool showPaintingPromt2 = false;
    
    public static bool chestHasBeenClickedOn = false;
    public static bool paintingHasBeenClickedOn = false;
    public static bool doorHasBeenClickedOn = false;

    void Update()
    {
        if(chestHasBeenClickedOn== true) { ShowChestPromt(); }
        if(paintingHasBeenClickedOn == true) { ShowPaintingPromt(); }
        if(doorHasBeenClickedOn == true) { ShowDoorPromt(); }
    }

    //Methods that shows and hides the chest promt
    private void ShowChestPromt() { 
        HidePaintingPromt();
        HideDoorPromt();

        chestPromt.SetActive(true); 
        Invoke("HideChestPromt", 7);
        Invoke("ReseBoolsToFalse", 1);
    }
    private void HideChestPromt() { chestPromt.SetActive(false); }

    //methods that shows and hides the painting promts
    private void ShowPaintingPromt() {
        HideChestPromt();
        HideDoorPromt();

        if(showPaintingPromt2 == false) 
        {   paintingPromt1.SetActive(true); 
            Invoke("HidePaintingPromt", 7);
            Invoke("ReseBoolsToFalse", 1);
        }
        if(showPaintingPromt2 == true) 
        {   paintingPromt2.SetActive(true); 
            Invoke("HidePaintingPromt", 7);
            Invoke("ReseBoolsToFalse", 1);
        } 
    }
    private void HidePaintingPromt() { if(showPaintingPromt2 == false) 
        { paintingPromt1.SetActive(false); 
        }
    if(showPaintingPromt2 == true) 
        { paintingPromt2.SetActive(false); 
        }
    }

    //methods that shows and hides the door promt
    private void ShowDoorPromt() { doorPromt.SetActive(true); 
        Invoke("HideDoorPromt", 7);
        Invoke("ReseBoolsToFalse", 1);
    }
    private void HideDoorPromt() { doorPromt.SetActive(false); }

    //this method is used to reset all bools to the false sate
    private void ReseBoolsToFalse() { chestHasBeenClickedOn = false;
        paintingHasBeenClickedOn = false;
        doorHasBeenClickedOn = false;
    }
}
