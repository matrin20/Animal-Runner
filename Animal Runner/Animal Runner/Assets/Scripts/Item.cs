using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]

public class Item : ScriptableObject
{
    public string itemName;
    public int itemID;
    public string itemSlot;
    public int itemPrice;

    public Item(string name, int id, string slot, int price)
    {
        this.itemName = name;
        this.itemID = id;
        this.itemSlot = slot;
        this.itemPrice = price;
    }



}
