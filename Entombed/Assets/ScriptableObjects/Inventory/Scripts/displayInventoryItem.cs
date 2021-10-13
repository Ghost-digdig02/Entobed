using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class displayInventoryItem : MonoBehaviour
{
    public InventoryObject inventory;

    public int X_start;
    public int Y_start;
    public int X_SpaceBetweenItems; //the space int the x-axis that will be between the items in the inventory
    public int Y_SpaceBetweenItems; //the space int the y-axis that will be between the items in the inventory
    public int numberOfColoumns; //the number of colomns the inventory will have
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>(); //a dictionary to hold the items

    void Start()
    {
        CreateDisplay();
    }

 
    void Update()
    {
        UpdateDisplay();
    }

    public void CreateDisplay()
    {
        for(int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
        }
    }

    public Vector3 GetPosition(int i) //method to get the inventorys systems position
    {
        return new Vector3(X_start +(X_SpaceBetweenItems * (i % numberOfColoumns)), Y_start +(-Y_SpaceBetweenItems *(i / numberOfColoumns)), 0f);
    }
    public void UpdateDisplay()
    {

    }
}
