using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddAnimalCode : MonoBehaviour
{

    private PlayerData _playerData;
    private List<Animal> _allAnimals;
    [SerializeField]
    private MenuSelectItem scenePicker;

    // Start is called before the first frame update
    void Start()
    {
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();
        _allAnimals = _playerData.GetAllAnimals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckAnimalCode(string code)
    {
        for (int i=0; i<_allAnimals.Count; i++)
        {
            if (_allAnimals[i].myCode == code)
            {
                //do something
                _playerData.AddAnimal(_allAnimals[i]);
                SceneManager.LoadScene(scenePicker.GetSceneName());
            }
        }
    }

}
