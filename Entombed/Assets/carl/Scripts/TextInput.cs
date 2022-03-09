using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextInput : MonoBehaviour
{ 
    Rigidbody rb;

    public TextInput ti;

    public int maxMessages = 1;

    public GameObject door;
    public GameObject textObject;
    public InputField textBox;

    [SerializeField]
    List<Message> messageList = new List<Message>();
    GameObject closeddoor, openeddoor;

    public static bool isdooropen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        closeddoor.SetActive (true);
        openeddoor.SetActive (false);
    }

    
    void Update()
    {
        // Gör så att spelaren kan klicka på enter för att börja skriva
        if(textBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToPuzzle(textBox.text);
                textBox.text = "";
            }
        }
        else
        {
            if (!textBox.isFocused && Input.GetKeyDown(KeyCode.Return))
                textBox.ActivateInputField();
        }
        //if (textBox.text == "123")
      //  {
           ////// if (Input.GetKeyDown(KeyCode.Space))
            //{
             //   isdooropen = true;
           //     SendMessageToPuzzle("wow de funka");
         //       Debug.Log(":)");
                
       //     }
            
                
     //   }
        if (textBox.text == "123")
        {
            FindObjectOfType<PusselEnd>().DuVann();
        }
        
    }

    //tror inte detta behövs men jag vågar inte ta bort det
    public void SendMessageToPuzzle(string text)
    {
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }
            

        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText = Instantiate(textObject);

        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = newMessage.text;

        messageList.Add(newMessage);
    }

    [System.Serializable]
    public class Message
    {
        public string text;
        public Text textObject;
    }
}
