using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnimalClick : MonoBehaviour
{
    private TextMeshProUGUI nameField;
    private TextMeshProUGUI habitatField;
    private TextMeshProUGUI rarityField;
    private TextMeshProUGUI codeField;
    private Image animalSpriteField;
    private GameObject animalInformationField;

    [SerializeField]
    private Animal animalReference;

    private GameObject animalInformation;

    [SerializeField]
    private GameObject habitat1AnimalInfo;
    [SerializeField]
    private GameObject habitat2AnimalInfo;

    private PlayerData _playerData;

    void Start()
    {
        animalInformationField = GameObject.Find("AnimalInformation");
        nameField = GameObject.Find("Name").GetComponent<TextMeshProUGUI>();
        habitatField = GameObject.Find("Habitat").GetComponent<TextMeshProUGUI>();
        rarityField = GameObject.Find("Rarity").GetComponent<TextMeshProUGUI>();
        codeField = GameObject.Find("ShareCode").GetComponent<TextMeshProUGUI>();
        animalSpriteField = GameObject.Find("AnimalSprite").GetComponent<Image>();

        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();

        if (_playerData.GetHeadSlotItem().itemID == 0)
        {
            animalInformation = habitat1AnimalInfo;
        } else
        {
            animalInformation = habitat2AnimalInfo;
        }
        animalInformation.SetActive(false);

    }



    private void OnMouseDown()
    {
        animalInformation.SetActive(true);

        nameField.text = "Name: " + animalReference.myName;
        habitatField.text = "Habitat: " + animalReference.myHabitat;
        rarityField.text = "Rarity: " + animalReference.myRarity;
        codeField.text = "Code: " + animalReference.myCode;
        animalSpriteField.sprite = GetComponent<SpriteRenderer>().sprite;


    }

}
