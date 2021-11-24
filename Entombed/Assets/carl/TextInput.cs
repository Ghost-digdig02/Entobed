using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextInput : MonoBehaviour
{
    public int maxMessages = 1;

    public GameObject textObject;
    public InputField textBox;

    [SerializeField]
    List<Message> messageList = new List<Message>();

    void Start()
    {
        
    }

    
    void Update()
    {
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
        if (!textBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SendMessageToPuzzle("wow de funka");
                Debug.Log("Space");
            }
                
        }

        
    }

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
