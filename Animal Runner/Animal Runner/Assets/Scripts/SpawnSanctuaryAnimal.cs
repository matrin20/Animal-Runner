using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSanctuaryAnimal : MonoBehaviour
{
    private PlayerData _playerData;
    private List<Animal> spawnList;
    [SerializeField]
    private Transform spawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();
        spawnList = _playerData.GetAnimals();
        SpawnAnimal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnAnimal()
    {
        foreach(Animal animal in spawnList)
        {
            //adding a random x pos to spawnpoint within a range
            Instantiate(animal.myGameObject, spawnPoint.position, Quaternion.identity);
        }
    }
}
