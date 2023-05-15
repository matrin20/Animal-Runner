using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogBookFishSelect : MonoBehaviour
{
    [SerializeField]
    private Animal myFish;
    [SerializeField]
    private Image bigLogBookSprite;
    [SerializeField]
    private TextMeshProUGUI nameField;
    [SerializeField]
    private TextMeshProUGUI habitatField;
    [SerializeField]
    private TextMeshProUGUI rarityField;
    [SerializeField]
    private TextMeshProUGUI codeField;

    private PlayerData _playerData;

    // Start is called before the first frame update
    void Start()
    {
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAnimalSprite()
    {
        if (_playerData.GetAnimals().Contains(myFish)) {
            bigLogBookSprite.sprite = myFish.myGameObject.GetComponent<SpriteRenderer>().sprite;
            nameField.text = myFish.myName;
            habitatField.text = myFish.myHabitat;
            rarityField.text = myFish.myRarity;
            codeField.text = myFish.myCode;
        } else
        {
            Debug.Log("You have not unlocked that animal yet!");
        }
   
    }

}
