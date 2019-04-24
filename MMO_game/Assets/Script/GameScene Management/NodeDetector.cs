using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeDetector : MonoBehaviour
{
    public int NodeID;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Server" || other.gameObject.name == "Local")
        {
            //TODO: print on screen to inform entering new node : reclaimed/not reclaimed
            Debug.Log("Entering Node: " + NodeID);
            Map.instance.SetCurrentNode(NodeID);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Server" || other.gameObject.name == "Local")
        {
            //TODO: print on screen to inform entering  : reclaimed/not reclaimed
            Debug.Log("Exiting Node: " + NodeID);
            Map.instance.SetCurrentNode(0);
        }
    }


}
