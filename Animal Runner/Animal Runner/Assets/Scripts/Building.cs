using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Building : ScriptableObject
{

    public GameObject buildingPrefab;
    public string buildingName;
    public int buildingLevel;
    public int buildingCost;

    public Building(GameObject prefab, string name, int level, int cost)
    {
        this.buildingPrefab = prefab;
        this.buildingName = name;
        this.buildingLevel = level;
        this.buildingCost = cost;
    }

}
