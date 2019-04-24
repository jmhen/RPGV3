using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawner : NetworkBehaviour
{
    public Node node;
    Area[] areas;
    GameObject[] objectsToSpawn;
    public float spawnInterval;
    float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        //make sure spawner is owned only by server 
        if(!isServer)
        {
            Debug.Log("not Server");
            Destroy(this);
            return;
        }
        Debug.Log("..........................................................................");
        Debug.Log("................................Spawn.....................................");
        areas = node.areas;
        timeLeft = spawnInterval/10;

    }


    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Debug.Log("Spawning\n");
            Spawn();
            timeLeft = spawnInterval;
        }
    }

    void Spawn()
    {
        for(int i = 0; i < areas.Length;i++)
        {
            Area area = areas[i];
            int spawnNumber = area.GetSpawnNumber(); 
            //Debug.Log("Spawning "+spawnNumber+ " items in Area "+ area.AreaID);
            for(int j = 0; j < spawnNumber; j++)
            {
                GameObject sp = Instantiate(area.itemToSpawn, area.GenerateRandomSpawnPoints(),false);
                NetworkServer.Spawn(sp);
                area.AddToExistingItems(sp);
            }
            area.UpdateArea();
        }

    }

}
