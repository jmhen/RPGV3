using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafter : Interactable
{
    public override void Interact()
    {
        base.Interact();
        UIManager.UI.craftingUI.SetActive(true);
        PlayerManager.instance.player.GetComponent<PlayerCommands>().SendMessageToServer("Trying to Open NodeUI. CraftingUI:" + UIManager.UI.craftingUI.activeSelf);

    }
}
