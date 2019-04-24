using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeReclaimUI : MonoBehaviour
{
    Map map;
    Node node;
   
    [SerializeField]public GameObject nodeInfo;
    [SerializeField] public InventorySlot[] materialSlots;

    Slider slider;
    Text progressText, nodeNumberText;


    void Start()
    {
        map = Map.instance;
    }


    void Update()
    {

        if (gameObject.activeSelf)
        {
            UpdateNodeProgress();
        }
    }





    public void UpdateNodeProgress()
    {
        if(map == null)
        {
            map = Map.instance;
        }
        node = map.GetCurrentNode();
        if (node.isReclaimed)
        {
            Toast.toast.ShowToast("This Node has already been reclaimed!",2);
        }
        slider = gameObject.GetComponentInChildren<Slider>();
        progressText = slider.GetComponentInChildren<Text>();

        float progress = Mathf.Clamp01(node.GetProgress() / 100);
        slider.value = progress;
        progressText.text = progress * 100f + "%";


    }





    public void UpdateNodeInfo()
    {
        node = map.GetCurrentNode();
        //update Node Number and info
        Text[] texts = gameObject.GetComponentsInChildren<Text>();
        foreach (Text t in texts)
        {
            if (t.name.Equals("nodeNumber"))
            {
                nodeNumberText = t;
            }
        }

        nodeNumberText.text = node.itemID.ToString();
        string materialInfo = "";
        for (int i = 0; i < node.spawnableMaterials.Length; i++)
        {
            string materialname = node.spawnableMaterials[i].name + "\n\n";
            materialInfo += materialname;
        }

        Text infoText = nodeInfo.GetComponentInChildren<Text>();
        infoText.text = materialInfo;


        //TODO: need to set the materials for all nodes!
        for (int i = 0; i < node.requiredMaterials.Length; i++)
        {
            if (node.requiredMaterials[i] != null)
            {
                if (i < materialSlots.Length)
                {
                    materialSlots[i].AddItem(node.requiredMaterials[i]);
                }
            }
        }

    }
}
