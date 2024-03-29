using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunLoot : MonoBehaviour
{

    public List<Animal> epipelagicLootList = new List<Animal>();
    public List<Animal> mesopelagicLootList = new List<Animal>();
    public List<Animal> abyssopelagicLootList = new List<Animal>();

    private List<List<Animal>> lootLists = new List<List<Animal>>();
    private void Start()
    {
        lootLists.Add(epipelagicLootList);
        lootLists.Add(mesopelagicLootList);
        lootLists.Add(abyssopelagicLootList);
    }

    public Animal GetAnimalReward(int index)
    {
        int randomNumber = Random.Range(1, 101);
        List<Animal> validAnimals = new List<Animal>();
        foreach (Animal animal in lootLists[index])
        {
            if (randomNumber <= animal.myDropRate)
            {
                validAnimals.Add(animal);
            }
        }
        int randomDrop = Random.Range(0, validAnimals.Count);
        return validAnimals[randomDrop];
    }
  
}
