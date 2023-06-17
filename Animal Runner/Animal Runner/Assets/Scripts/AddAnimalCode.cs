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

    [SerializeField]
    private GameObject obtainedAnimalPanel;
    [SerializeField]
    private GameObject receivedAnimalPanel;

    [SerializeField]
    private Image animalSprite;
    [SerializeField]
    private TextMeshProUGUI animalField;
    [SerializeField]
    private TextMeshProUGUI habitatField;
    [SerializeField]
    private TextMeshProUGUI rarityField;

    private bool stringMatches = false;
    [SerializeField]
    private GameObject errorPanel;

    [SerializeField]
    private GameObject youReceivedField;

    private bool shouldReloadScene = false;

    [SerializeField]
    private TMP_InputField inputFieldToReset;

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

        stringMatches = false;
        shouldReloadScene = false; 

        for (int i=0; i<_allAnimals.Count; i++)
        {
            if (_allAnimals[i].myCode == actualText)
            {
                Debug.Log("String matches");
                stringMatches = true;

                obtainedAnimalPanel.SetActive(true);


                if (_playerData.GetAnimalCount(_allAnimals[i].myID) == 0)
                {
                    _playerData.AddAnimal(_allAnimals[i]);
                    _playerData.SetAnimalCount(_allAnimals[i]);

                    //open the received animal panel
                    //set animal.text to:
                    //set habitat.text to:
                    //set rarity.text to:
                    receivedAnimalPanel.SetActive(true);
                    animalSprite.sprite = _allAnimals[i].myGameObject.GetComponent<SpriteRenderer>().sprite;
                    animalField.text = _allAnimals[i].myName;
                    habitatField.text = _allAnimals[i].myHabitat;
                    rarityField.text = _allAnimals[i].myRarity;
                    errorPanel.SetActive(false);
                    youReceivedField.SetActive(true);

                    shouldReloadScene = true;

                } else
                {
                    receivedAnimalPanel.SetActive(false);
                    errorPanel.GetComponent<TextMeshProUGUI>().text = "You already unlocked this animal!";
                    errorPanel.SetActive(true);
                    youReceivedField.SetActive(false);
                }

                //break when a string matches so it doesn't continue looping through on the list.
                break;
            }
        }

        if (stringMatches == false)
        {
            obtainedAnimalPanel.SetActive(true);
            receivedAnimalPanel.SetActive(false);
            errorPanel.GetComponent<TextMeshProUGUI>().text = "That code does not match any animals!";
            errorPanel.SetActive(true);
            youReceivedField.SetActive(false);
        }


        //debugging tool; cheat code to add gold
        if (actualText == "gold")
        {
            _playerData.ChangeCurrency(5000);

            obtainedAnimalPanel.SetActive(false);
        }
    }

    public void ReloadScene()
    {
        if (shouldReloadScene == true)
        {
            SceneManager.LoadScene(scenePicker.GetSceneName());
        }
    }

    public void ClearTextField()
    {
        inputFieldToReset.text = "";
    }

}
