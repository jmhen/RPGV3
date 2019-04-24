using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PlayerCommands : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (!isServer)
        {
            Debug.Log("sending name");
 
        }

    }


    public void DestroyOnServer(GameObject spawnedObj)
    {
        if (isServer)
        {
            NetworkServer.Destroy(spawnedObj);
        }
        else {
            Debug.Log("asking server to destroy obj");
            CmdDestroyObject(spawnedObj);
        }


    }
    public void NodeMakeProgressForAll(int nodeID)
    {
        if (isServer)
        {
            Debug.Log("Make Node Progress for all");
            Node node = Map.instance.nodeList[nodeID];
            node.MakeProgress();
            RpcUpdateNode(nodeID, node.GetProgress());

        }
        else
        {
            Debug.Log("asking server to notify all clients to update node progress");
            CmdNodeMakeProgress(nodeID);
        }


    }
    public void SendMessageToServer(string msg)
    {
        if (!isServer)
        {
            CmdSendMsg(msg);
        }

    }
    public void SendMessageToGlobalChat(string msg, Message.MessageType type)
    {
        if (isServer)
        {
            Debug.Log("update chat for all!");
            RpcUpdateChatMsg("System: "+msg, type);
        }
        else
        {
            CmdSendChatMsg(msg, type);
            Toast.toast.ShowToast("Sending to globalChat!",2);
        }
    }

    [Command]
    void CmdDestroyObject(GameObject obj)
    {
        Debug.Log("sending command");
        NetworkServer.Destroy(obj);

    }



    [Command]
    void CmdSendMsg(string msg)
    {   
        Debug.Log("FROM CLIENT: "+msg);
    }




    [Command]
    void CmdNodeMakeProgress(int nodeID)
    {
        Node node = Map.instance.nodeList[nodeID];
        node.MakeProgress();
        RpcUpdateNode(nodeID,node.GetProgress());
    }

    [Command]
    void CmdSendChatMsg(string msg,Message.MessageType type)
    {
        RpcUpdateChatMsg(msg,type);
    }


    [ClientRpc]
    void RpcUpdateNode(int nodeID, float progress) {
        Map.instance.nodeList[nodeID].SetProgress(progress);
    }

    [ClientRpc]
    void RpcUpdateChatMsg(string msg, Message.MessageType type)
    {
        UIManager.UI.chatUI.GetComponent<ChatSystem>().sendMessageToChat(msg, type);
        UIManager.UI.chatUI.GetComponent<ChatSystem>().chatBox.text = "";
    }


}
