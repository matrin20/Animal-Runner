using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class AddAnimalCode : MonoBehaviour
{

    private PlayerData _playerData;
    private List<Animal> _allAnimals;
    [SerializeField]
    private MenuSelectItem scenePicker;
    [SerializeField]
    private TextMeshProUGUI inputField;

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

    public void CheckAnimalCode()
    {
        string inputText = inputField.text;
        string actualText = inputText.Substring(0, inputText.Length - 1);


        for (int i=0; i<_allAnimals.Count; i++)
        {
            if (_allAnimals[i].myCode == actualText)
            {
                //do something
                Debug.Log("String matches");
                _playerData.AddAnimal(_allAnimals[i]);
                SceneManager.LoadScene(scenePicker.GetSceneName());
            }
        }
    }

}
