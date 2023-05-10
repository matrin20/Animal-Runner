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
    [Header("Time & run related variables")]
    [SerializeField]
    private float baseTime;
    private float timeAdjustment;
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
    private TextMeshProUGUI rewardText;

    
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


    // Start is called before the first frame update
    void Start()
    {
        endScreen.SetActive(false);
        timeRemaining = CalculateRunTime();
        timerProgressing = true;
        rewardText.text = "Currency: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (timerProgressing == true)
        {
            GameTimer();
            UpdateTimer();
            AwardOceanRun();
        }
    }

    public void SetTimeAdjustment(float itemEffect)
    {
        timeAdjustment += itemEffect;
    }

    private float CalculateRunTime()
    {
        return baseTime + timeAdjustment;
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
            foundAnimal = lootManager.GetAnimalReward(0);
            GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>().AddAnimal(foundAnimal);
            foundAnimalGUI.sprite = foundAnimal.myGameObject.GetComponent<SpriteRenderer>().sprite;
            timePassedField.text = "Time passed: " + CalculateRunTime() + " seconds";
            currencyEarnedField.text = "Currency earned: " + currencyReward;
            foundAnimalNameField.text = "Name: " + foundAnimal.myName;
            foundAnimalRarityField.text = "Rarity: " + foundAnimal.myRarity;
        }


        //game states
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
            currencyReward += Mathf.FloorToInt(baseReward + timedReward);
            //this will throw an exception if the player did not start on menu select due to the DontDestroyOnLoad object being created there
            rewardText.text = "Currency: " + currencyReward;
            GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>().AddCurrency(currencyReward);
        }

    }

}
