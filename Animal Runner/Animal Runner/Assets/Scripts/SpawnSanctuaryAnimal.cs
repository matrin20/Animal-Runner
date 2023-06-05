using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSanctuaryAnimal : MonoBehaviour
{
    private PlayerData _playerData;
    private List<Animal> spawnList;
    [SerializeField]
    private Transform epiSpawnPoint;
    [SerializeField]
    private Transform mesoSpawnPoint;
    [SerializeField]
    private Transform abyssoSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();
        spawnList = _playerData.GetAnimals();
        SpawnAnimal();
    }


    private void SpawnAnimal()
    {
        foreach(Animal animal in spawnList)
        {
            Transform spawnPoint;

            if (animal.myHabitat == "Epipelagic")
            {
                spawnPoint = epiSpawnPoint;
            } else if (animal.myHabitat == "Mesopelagic")
            {
                spawnPoint = mesoSpawnPoint;
            } else if (animal.myHabitat == "Abyssopelagic")
            {
                spawnPoint = abyssoSpawnPoint;
            }
            else
            {
                spawnPoint = epiSpawnPoint;
            }
            Instantiate(animal.myGameObject, spawnPoint.position, Quaternion.identity);

        }
    }
}
