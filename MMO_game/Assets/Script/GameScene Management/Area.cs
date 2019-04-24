using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Area", menuName = "Area")]
public class Area : ScriptableObject
{
    [SerializeField] public int AreaID;
    Vector3 centre;
    [SerializeField] public GameObject itemToSpawn;
    [SerializeField] int radius;
    [SerializeField] int areaItemCap; //max number of items at area
    int areaLastItems = 0; //number of items during last spawn //commented because not used
    int areaCurrentItems = 0; //number of items in area
    float spawnCoefficient = 0.33f; //just check the value on a graph... 
    [SerializeField] int spawnCap = 10; //max number of items to spawn
    List<GameObject> existingItems;

    private void OnEnable()
    {
        areaLastItems = 0;
        areaCurrentItems = 0;
        existingItems = new List<GameObject>();
    }
    public void SetAreaCentre(Vector3 loc)
    {
        centre = loc;
        Debug.Log("Area "+AreaID +" Centre = "+centre);
    }

    public Transform GenerateRandomSpawnPoints()
    {

        GameObject newPoint = new GameObject();
        float angle = Random.Range(0, 2 * Mathf.PI);
        float distance = Random.Range(0, radius);
        float spawnPointX = distance * Mathf.Cos(angle);
        float spawnPointZ = distance * Mathf.Sin(angle);
        newPoint.transform.position = centre + new Vector3(spawnPointX, 10, spawnPointZ);
        //Debug.Log("new spawn location: " +newPoint.transform.position);
        return newPoint.transform;

    }

    public int GetSpawnNumber()
    {
        int spawnNumber = SpawnAlgorithm.spawnNumber(areaCurrentItems, areaLastItems, areaItemCap, spawnCap);
        Debug.Log("Area "+AreaID+" SpawnNumber Calculated:  " + spawnNumber);
        return spawnNumber;
    }
    public void UpdateArea()
    {
        areaLastItems = areaCurrentItems;
        Debug.Log("Area "+AreaID + " lastItems: " + areaLastItems);
        existingItems.RemoveAll(obj => obj == null);
        areaCurrentItems = existingItems.Count;
        Debug.Log("Area " + AreaID + " currentItems: " + areaCurrentItems);
    }
    public void AddToExistingItems(GameObject obj)
    {
        existingItems.Add(obj);
    }
}
