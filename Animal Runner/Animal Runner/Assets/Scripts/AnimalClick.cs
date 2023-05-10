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


    void Start()
    {
        animalInformationField = GameObject.Find("AnimalInformation");
        nameField = GameObject.Find("Name").GetComponent<TextMeshProUGUI>();
        habitatField = GameObject.Find("Habitat").GetComponent<TextMeshProUGUI>();
        rarityField = GameObject.Find("Rarity").GetComponent<TextMeshProUGUI>();
        codeField = GameObject.Find("ShareCode").GetComponent<TextMeshProUGUI>();
        animalSpriteField = GameObject.Find("AnimalSprite").GetComponent<Image>();

    }



    private void OnMouseDown()
    {
        nameField.text = "Name: " + animalReference.myName;
        habitatField.text = "Habitat: " + animalReference.myHabitat;
        rarityField.text = "Rarity: " + animalReference.myRarity;
        codeField.text = "Code: " + animalReference.myCode;
        animalSpriteField.sprite = GetComponent<SpriteRenderer>().sprite;

        
    }

}
