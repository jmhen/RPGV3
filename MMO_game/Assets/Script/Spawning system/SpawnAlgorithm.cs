using System;
using UnityEngine;

public static class SpawnAlgorithm
{
    //int areaItemCap; //max number of items at area
    static int areaBaseItems = 5; //number of items to be spawned at least
    //private int areaLastItems; //number of items during last spawn //commented because not used
    //private int areaCurrentItems; //number of items in area
    static float spawnCoefficient = 0.33f; //just check the value on a graph... 
    //int spawnCap; //max number of items to spawn
    //private int areaFinalItems;
    //private int areaMultiplier;
    //private int otherCoefficient; //probably dont need this, meant to add in front of the exp() itself, reactivate if needed

    public static int spawnNumber(int areaCurrentItems, int areaLastItems, int areaItemCap, int spawnCap)
    {

        int areaMultiplier = ((areaCurrentItems + areaLastItems) / 2 + areaBaseItems) / areaBaseItems;
        if (areaMultiplier > 2)
        {
            areaMultiplier = 2;
        }
        int areaFinalItems = areaMultiplier * ((int)Math.Exp(spawnCoefficient * areaCurrentItems) + areaBaseItems);

        if (areaFinalItems > areaItemCap)
        {
            return areaItemCap - areaCurrentItems;
        }

        else if (areaFinalItems < areaItemCap && areaFinalItems - areaCurrentItems > spawnCap)
        {
            return spawnCap;
        }
        else
        {
            return areaFinalItems - areaCurrentItems;
        }
    }
}
