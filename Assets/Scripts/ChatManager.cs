using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public int maxMessages;

    public bool keepChatOpen;

    public TMP_InputField chatInput;

    public GameObject textObject;
    public GameObject chatBox;

    //string userName;
    [SerializeField] private List<Message> messageList = new List<Message>();

    // Start is called before the first frame update
    void Start()
    {
        //userName = Environment.UserName;
    }

    // Update is called once per frame
    void Update()
    {
        if (chatInput.text.Trim() != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //SendMessageToChat(userName + ": " + chatInput.text);
                SendMessageToChat(chatInput.text);
                chatInput.text = "";
                if (keepChatOpen)
                {
                    chatInput.ActivateInputField();
                }
            }
        }
        else if (!chatInput.isFocused && Input.GetKeyDown(KeyCode.Return))
        {
            chatInput.ActivateInputField();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            chatInput.DeactivateInputField();
        }
    }

    public void SendMessageToChat(string text)
    {
        if (messageList.Count > maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }

        Message newMessage = new Message();
        newMessage.text = text;

        GameObject newTextObject = Instantiate(textObject, chatBox.transform);

        newMessage.textObject = newTextObject.GetComponent<TextMeshProUGUI>();

        newMessage.textObject.text = newMessage.text;

        messageList.Add(newMessage);
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public TextMeshProUGUI textObject;
}
