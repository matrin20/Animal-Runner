using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMission : MonoBehaviour
{
    [SerializeField]
    private float missionInterval;
    private float secondsPassed;

    private int numberOfMissions;
    private List<Mission> currentMissions;

    private List<Animal> _allAnimals;
    private PlayerData _playerData;

    private List<Animal> epipelagicAnimals;
    private List<Animal> mesopelagicAnimals;
    private List<Animal> abyssopelagicAnimals;

    private List<List<Animal>> animalLists;


    private int listIndex;

    private Animal animalReward;
    private int missionDuration;
    [SerializeField]
    private int missionDurationVariance;
    private float difficultyModifier;

    [SerializeField]
    private PopulateMissionData populator;

    // Start is called before the first frame update
    void Start()
    {
        epipelagicAnimals = new List<Animal>();
        mesopelagicAnimals = new List<Animal>();
        abyssopelagicAnimals = new List<Animal>();

        animalLists = new List<List<Animal>>();
        currentMissions = new List<Mission>();

        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();
        _allAnimals = _playerData.GetAllAnimals();

        SortAnimalsIntoHabitat();

        animalLists.Add(epipelagicAnimals);
        animalLists.Add(mesopelagicAnimals);
        animalLists.Add(abyssopelagicAnimals);

        if (_playerData.GetMissions() != null)
        {
            currentMissions = _playerData.GetMissions();
        }

    }

    // Update is called once per frame
    void Update()
    {
        ProgressTimer();
    }

    private void ProgressTimer()
    {
        if (secondsPassed > missionInterval)
        {
            secondsPassed = 0;
            if (populator.GetNumberOfMissions() < 3)
            {
                CreateMission();
                populator.IncreaseCurrentNumberOfMissions();
            }
        }
        else
        {
            secondsPassed += Time.deltaTime;
        }
    }



    private void SortAnimalsIntoHabitat()
    {
        for (int i = 0; i < _allAnimals.Count; i++)
        {
            if (_allAnimals[i].myHabitat == "Epipelagic")
            {
                epipelagicAnimals.Add(_allAnimals[i]);
            } else if (_allAnimals[i].myHabitat == "Mesopelagic")
            {
                mesopelagicAnimals.Add(_allAnimals[i]);
            } else if (_allAnimals[i].myHabitat == "Abyssopelagic")
            {
                abyssopelagicAnimals.Add(_allAnimals[i]);
            }
        }
    }

    private void CreateMission()
    {
        //animal reward
        listIndex = _playerData.GetHeadSlotItem().itemID;
        animalReward = animalLists[listIndex][Random.Range(0, animalLists[listIndex].Count)];

        //mission duration
        missionDuration = Random.Range(_playerData.GetBaseRunTime() - missionDurationVariance, _playerData.GetBaseRunTime() + missionDurationVariance);

        float difficulty = 0;

        //difficulty increase
        if (animalReward.myRarity == "Common")
        {
            difficulty = 0.3f;
        } else if (animalReward.myRarity == "Uncommon")
        {
            difficulty = 0.6f;
        }
        else if (animalReward.myRarity == "Rare")
        {
            difficulty = 1f;
        }

        difficultyModifier = difficulty;

        currentMissions.Add(new Mission(animalReward, missionDuration, difficultyModifier));
        _playerData.SetMissions(currentMissions);
    }


}
