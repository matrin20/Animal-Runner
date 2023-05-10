using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Animal : ScriptableObject
{
    public int myID;
    public string myName;
    public string myHabitat;
    public string myCode;
    public float myDropRate;
    public GameObject myGameObject;
    public string myRarity;

    public Animal(int id, string name, string habitat, string code, float dropRate, GameObject gameObject, string rarity)
    {
        this.myID = id;
        this.myName = name;
        this.myHabitat = habitat;
        this.myCode = code;
        this.myDropRate = dropRate;
        this.myGameObject = gameObject;
        this.myRarity = rarity;
    }
}
