using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
/// <summary>
/// This is a script used to display the players inventory in the UI
/// </summary>
public class DisplayInventoryItem : MonoBehaviour
{
    public MouseItem mouseItem = new MouseItem();

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
    protected Dictionary<GameObject, InventorySlot> itemsDisplayed = new Dictionary<GameObject, InventorySlot>(); //a dictionary to hold the items
    
    void Start()
    {
        CreateSlots();
    }
 
    void Update()
    {
        UpdateSlots();
    }

    public void UpdateSlots()
    {
        foreach (KeyValuePair<GameObject, InventorySlot> _slot in itemsDisplayed)
        {
            if(_slot.Value.ID >= 0)
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[_slot.Value.item.Id].UiDispaly;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = _slot.Value.amount == 1 ? "" : _slot.Value.amount.ToString("n0"); // displays the number of a specific item in the inventory, but if there only is one item of a specific sort it willl not display a number.
            }
            else
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }
    
    public void CreateSlots() //creates the inventory display in the begining of the game
    {
        itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < inventory.Container.Items.Length; i++)
        {
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });

            itemsDisplayed.Add(obj, inventory.Container.Items[i]);

        }
    }

    private void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }

    public void OnEnter(GameObject obj)
    {
        mouseItem.hoverobj = obj;
        if (itemsDisplayed.ContainsKey(obj))
        {
            mouseItem.hoverItem = itemsDisplayed[obj];
        }
    }
    public void OnExit(GameObject obj)
    {
        mouseItem.hoverobj = null;
        mouseItem.hoverItem = null;
    }
    public void OnDragStart(GameObject obj)
    {
        var mouseObject = new GameObject();
        var rt = mouseObject.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(50, 50);
        mouseObject.transform.SetParent(transform.parent);
        if(itemsDisplayed[obj].ID >= 0)
        {
            var img = mouseObject.AddComponent<Image>();
            img.sprite = inventory.database.GetItem[itemsDisplayed[obj].ID].UiDispaly;
            img.raycastTarget = false;
        }
        mouseItem.obj = mouseObject;
        mouseItem.item = itemsDisplayed[obj];
    }
    public void OnDragEnd(GameObject obj)
    {
        if (mouseItem.hoverobj)
        {
            inventory.MoveItem(itemsDisplayed[obj], itemsDisplayed[mouseItem.hoverobj]);
        }
        else
        {

        }
        Destroy(mouseItem.obj);
        mouseItem.item = null;
    }
    public void OnDrag(GameObject obj)
    {
        if(mouseItem.obj != null)
        {
            mouseItem.obj.GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }


    public Vector3 GetPosition(int i) //method to get the inventorys systems position
    {
        return new Vector3(X_start +(X_SpaceBetweenItems * (i % numberOfColoumns)), Y_start +(-Y_SpaceBetweenItems *(i / numberOfColoumns)), 0f);
    }
   
    public class MouseItem
    {
        public GameObject obj;
        public InventorySlot item;
        public InventorySlot hoverItem;
        public GameObject hoverobj;
    }
        
}
