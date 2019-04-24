using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatSystem : MonoBehaviour
{
    string username;
    public int maxMessages = 15;
    public GameObject chatPanel, textObject, scrollView, inputField, sendButton;
    public InputField chatBox;
    public Color playerMessage, info;
    public Button sendMessageButton;

    [SerializeField]List<Message> messageList = new List<Message>();
    // Start is called before the first frame update
    void Start()
    {
        username = StaticStats.PlayerName;

    }



    public void SendChatToGlobal()
    {
        string msg = username + ": " + chatBox.text;
        PlayerManager.instance.player.GetComponent<PlayerCommands>().SendMessageToGlobalChat(msg, Message.MessageType.playerMessage);
    }

    public void sendMessageToChat(string text, Message.MessageType messageType)
    {
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }

        Message newMessage = new Message();
        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();
        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = MessageTypeColor(messageType);

        messageList.Add(newMessage);
        newText.SetActive(true);
        Toast.toast.ShowToast("new message added!", 2);
    }





    Color MessageTypeColor(Message.MessageType messageType)
    {
        Color color = info;
        switch (messageType)
        {
            case Message.MessageType.playerMessage:
                color = playerMessage;
                break;
        }
        return color;
    }

}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
    public MessageType messageType;

    public enum MessageType
    {
        playerMessage,
        info
    }
}
