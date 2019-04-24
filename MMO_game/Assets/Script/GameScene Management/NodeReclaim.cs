using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class NodeReclaim : Interactable
{
    GameObject nodeUI;
    private void Start()
    {
        nodeUI = UIManager.UI.nodeReclaimUI;
        nodeUI.SetActive(false);
    }
    public override void Interact()
    {
        base.Interact();
        nodeUI.SetActive(true);
        PlayerManager.instance.player.GetComponent<PlayerCommands>().SendMessageToServer("Trying to Open NodeUI. NodeUI:" + nodeUI.activeSelf);
        nodeUI.GetComponent<NodeReclaimUI>().UpdateNodeProgress();
        nodeUI.GetComponent<NodeReclaimUI>().UpdateNodeInfo();
    }
}