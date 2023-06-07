using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RunManager : MonoBehaviour
{
    //needs a timer that ticks down
    //needs an event on timer = 0
    //needs variables that can be adjusted using items
    private float baseTime;
    private float timeAdjustment;
    [Header("Time & run related variables")]
    [SerializeField]
    private float timeRemaining;
    private bool timerProgressing = false;
    [SerializeField]
    private GameObject endScreen;
    [SerializeField]
    private TextMeshProUGUI timerText;

    [Header("Dependent game objects")]
    [SerializeField]
    private CharacterMovementOcean _playerCharacter;
    [SerializeField]
    private ObstacleManager _obstacleManager;
    [SerializeField]
    private TextMeshProUGUI gameOverText;
    [SerializeField]
    private RunLoot lootManager;

    private int currencyReward;

    [Header("Reward variables")]

    [SerializeField]
    private float baseReward;
    private float timedReward;
    private float rewardTimer;
    [SerializeField]
    private float rewardInterval;
    [SerializeField]
    private float rewardModifier;
    [SerializeField]
    private DisplayCurrency currencyDisplay;
    private int intermediateReward;
    
    private Animal foundAnimal;
    [Header("End Screen objects")]
    [SerializeField]
    private Image foundAnimalGUI;
    [SerializeField]
    private TextMeshProUGUI timePassedField;
    [SerializeField]
    private TextMeshProUGUI currencyEarnedField;
    [SerializeField]
    private TextMeshProUGUI foundAnimalNameField;
    [SerializeField]
    private TextMeshProUGUI foundAnimalRarityField;

    [Header("Depth switching")]
    [SerializeField]
    private List<GameObject> oceanBackgrounds;
    private PlayerData _playerData;
    private Item _equippedHeadSlot;

    private bool isMissionRun = false;
    private Mission currentMission;

    private List<ParallaxElements> _parallaxElements;
    [SerializeField]
    private ParallaxBiomeManager _parallaxBiomeManager;

    // Start is called before the first frame update
    void Start()
    {
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();
        isMissionRun = _playerData.GetIsMissionRun();
        currentMission = _playerData.GetMissionRun();
        baseTime = _playerData.GetBaseRunTime();
        _equippedHeadSlot = _playerData.GetHeadSlotItem();

        SetTimeAdjustment();

        endScreen.SetActive(false);
        timeRemaining = CalculateRunTime();
        timerProgressing = true;
        //rewardText.text = "Currency: 0";
        ConfigureBiomeDepth();


        _parallaxElements = new List<ParallaxElements>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerProgressing == true)
        {
            UpdateTimer();
            AwardOceanRun();
            GameTimer();
        }
    }

    private void SetTimeAdjustment()
    {
        timeAdjustment = 0;

        if (_playerData.GetFlipperSlot().itemID == 3)
        {
            timeAdjustment = 0;
        } else if (_playerData.GetFlipperSlot().itemID == 4)
        {
            timeAdjustment = _playerData.GetBaseRunTime() / 10 * 2;
        } else if (_playerData.GetFlipperSlot().itemID == 5)
        {
            timeAdjustment = _playerData.GetBaseRunTime() / 10 * 3;
        }
    }

    private float CalculateRunTime()
    {
        if (isMissionRun)
        {
            return currentMission.GetMissionRunTime() - timeAdjustment;
        } else
        {
            return baseTime - timeAdjustment;
        }
    }

    private void GameTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        } else
        {
            //do something
            EndRun("Good Job!");
        }

    }

    public void EndRun(string stringText)
    {
        //open interface panel that shows run results (distance, coins, time), rolls whether there is an animal found and/or completes a mission if relevant
        //animal loot
        if (timeRemaining <= 0)
        {
            //award animal
            if (isMissionRun)
            {
                foundAnimal = currentMission.GetMissionAnimal();
                _playerData.RemoveMissionFromList(_playerData.GetMissionRun().GetMissionIndex());
            } else
            {
                foundAnimal = lootManager.GetAnimalReward(_equippedHeadSlot.itemID);
            }
            _playerData.EndMissionRun();
            _playerData.AddAnimal(foundAnimal);
            _playerData.SetAnimalCount(foundAnimal);
            foundAnimalGUI.sprite = foundAnimal.myGameObject.GetComponent<SpriteRenderer>().sprite;

            foundAnimalNameField.text = "Name: " + foundAnimal.myName;
            foundAnimalRarityField.text = "Rarity: " + foundAnimal.myRarity;
        }
        int passedTime = Mathf.FloorToInt( CalculateRunTime() - timeRemaining);

        timePassedField.text = "Time passed: " + passedTime + " seconds";
        currencyEarnedField.text = "Currency earned: " + currencyReward;


        //_playerData.ChangeCurrency(currencyReward);

        DisableParallaxMovement();

        //gameobject states
        endScreen.SetActive(true);
        _obstacleManager.SetGlobalObstacleSpeed(0f);
        _obstacleManager.enabled = false;
        _playerCharacter.enabled = false;
        timerProgressing = false;
        gameOverText.text = stringText;
    }

    public bool GetRunProgressing()
    {
        return timerProgressing;
    }

    private void UpdateTimer()
    {
        timerText.text = "Time Left: " + Mathf.RoundToInt(timeRemaining);
    }

    public void RestartRun()
    {
        SceneManager.LoadScene(gameObject.GetComponent<MenuSelectItem>().GetSceneName());
    }

    public void BackToMapSelect()
    {
        _playerData.EndMissionRun();
        SceneManager.LoadScene("MenuScreen");
    }

    private void AwardOceanRun()
    {
        if (rewardTimer < rewardInterval)
        {
            rewardTimer += Time.deltaTime;
        } else
        {
            rewardTimer = 0;
            timedReward = CalculateRunTime() - timeRemaining;
            timedReward *= rewardModifier;
            intermediateReward = Mathf.FloorToInt(baseReward + timedReward);
            _playerData.ChangeCurrency(intermediateReward);
            //currencyReward is only used to show the sum of the reward at the endscreen
            currencyReward += intermediateReward;
            //this will throw an exception if the player did not start on menu select due to the DontDestroyOnLoad object being created there
            //rewardText.text = "Currency: " + currencyReward;
            currencyDisplay.SetDisplayCurrency();
        }

    }

    private void ConfigureBiomeDepth()
    {
        int biomeIndex;

        if (_playerData.GetIsMissionRun())
        {
            if (_playerData.GetMissionRun().GetMissionAnimal().myHabitat == "Mesopelagic")
            {
                biomeIndex = 1;
            } else if (_playerData.GetMissionRun().GetMissionAnimal().myHabitat == "Abyssopelagic")
            {
                biomeIndex = 2;
            } else
            {
                biomeIndex = 0;
            }
            
        } else
        {
            biomeIndex = _equippedHeadSlot.itemID;
        }

        oceanBackgrounds[biomeIndex].SetActive(true);
    }

    private void DisableParallaxMovement()
    {
        _parallaxElements = _parallaxBiomeManager.GetParallaxElements();

        for (int i=0; i< _parallaxElements.Count; i++)
        {
            _parallaxElements[i].enabled = false;
        }
    }


}
