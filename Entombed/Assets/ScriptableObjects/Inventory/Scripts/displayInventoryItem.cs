using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
/// <summary>
/// This is a script used to display the players inventory in the UI
/// </summary>
public class displayInventoryItem : MonoBehaviour
{
    public GameObject inventoryPrefab; //we only use one single prefab for all items, we only switch the sprite
    public InventoryObject inventory;
    [SerializeField]
    private int X_start;
    [SerializeField]
    private int Y_start;
    [SerializeField]
    private int X_SpaceBetweenItems; //the space int the x-axis that will be between the items in the inventory
    [SerializeField]
    private int Y_SpaceBetweenItems; //the space int the y-axis that will be between the items in the inventory
    [SerializeField]
    private int numberOfColoumns; //the number of colomns the inventory will have
    protected Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>(); //a dictionary to hold the items
    /*
    void Start()
    {
        CreateDisplay();
    }

 
    void Update()
    {
        UpdateDisplay();
    }
    
    public void CreateDisplay() //creates the inventory display in the begining of the game
    {
        for(int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite =
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }

    public Vector3 GetPosition(int i) //method to get the inventorys systems position
    {
        return new Vector3(X_start +(X_SpaceBetweenItems * (i % numberOfColoumns)), Y_start +(-Y_SpaceBetweenItems *(i / numberOfColoumns)), 0f);
    }
    public void UpdateDisplay() //uppdates the display
    {
        for(int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))//is used if an item already is inside the inventory
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else //is used if an item already is'nt in the inventory
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }*/
}
