using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkSetup : NetworkBehaviour
{
    public override void OnStartLocalPlayer()
    {
        Renderer[] rens = GetComponentsInChildren<Renderer>();
        foreach (Renderer ren in rens)
        {
            ren.enabled = false;
        }
        GetComponent<NetworkAnimator>().SetParameterAutoSend(0, true);
        Debug.Log(GetComponent<NetworkAnimator>().GetParameterAutoSend(0));

    }

    public override void OnStartClient()
    {
        GetComponent<NetworkAnimator>().SetParameterAutoSend(0, true);
    }
}
