using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Node", menuName = "Node")]
public class Node : ScriptableObject
{
    [SerializeField] public int itemID;
    Vector3 centre;
    static int radius = 50;
    [SerializeField] public bool isReclaimed;
    float progress = 0;
    [SerializeField] float healthLevel = 100;
    [SerializeField] public Vector3 location;
    [SerializeField] public Item[] requiredMaterials;
    [SerializeField] public Item[] spawnableMaterials;
    [SerializeField] public Area[] areas;

    
    public void SetCentreLocation(Vector3 loc)
    {
        float distance = 25;
        float angle = 0;
        float interval = 2 * Mathf.PI / areas.Length;
        centre = loc;

        foreach (Area area in areas)
        {

            float spawnPointX = distance * Mathf.Cos(angle);
            float spawnPointZ = distance * Mathf.Sin(angle);
            Vector3 newCentre = centre + new Vector3(spawnPointX, 0, spawnPointZ);
            area.SetAreaCentre(newCentre);
            angle += interval;
            Debug.Log("Angle Set to: " + angle);

        }
    }
    public Vector3 GetCentreLocation()
    {
        return centre;
    }

    public void MakeProgress()
    {
        Debug.Log("New Progress to node");
        if(progress<100) progress += 0.5f;
    }
    public void SetProgress(float newProgress)
    {
        progress = newProgress;

    }
    public float GetProgress()
    {
        return progress;
    }



}
