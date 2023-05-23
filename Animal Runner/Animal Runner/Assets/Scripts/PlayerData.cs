using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //probably gonna read playerprefs from this DDOL object

    [SerializeField]
    private int currency;

    [SerializeField]
    private List<Animal> allAnimals;
    private List<Animal> obtainedAnimals;

    [SerializeField]
    private List<Item> headSlotItems;
    private Item equippedHeadSlotItem;

    [SerializeField]
    private List<Item> flipperSlotItems;
    private Item equippedFlipperSlot;

    [SerializeField]
    private int baseRunTime;

    private int shopLevel;
    //private Building habitatBuilderData;

    private int numberOfCurrentMissions;
    private List<Mission> currentMissions;

    private bool isMissionRun = false;
    private Mission currentMission;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //get from playerprefs
        currency = GetCurrency();
        obtainedAnimals = new List<Animal>();
        GetAnimals();

        currentMissions = new List<Mission>();
    }

    private void Update()
    {
        ClearPlayerPrefs();
    }

    public int GetCurrency()
    {
        currency = PlayerPrefs.GetInt("Currency");
        return currency;
    }

    public void ChangeCurrency(int amount)
    {
        if (currency + amount >= 0)
        {
            currency += amount;
            PlayerPrefs.SetInt("Currency", currency);
            Debug.Log("you currently have " + currency + " currency" );
        }
    }

    public void AddAnimal(Animal animal)
    {
        if (obtainedAnimals.Contains(animal))
        {
            Debug.Log("You already unlocked this animal");
        }
        else
        {
            obtainedAnimals.Add(animal);
            PlayerPrefs.SetInt("UnlockedAnimalID" + animal.myID, 1);
        }
    }

    public List<Animal> GetAnimals()
    {
        for (int i=0; i<allAnimals.Count + 1; i++)
        {
            if (PlayerPrefs.GetInt("UnlockedAnimalID" + i) == 1)
            {
                AddAnimal(allAnimals[i - 1]);
                //for (int j = 0; j<allAnimals.Count; j++)
                //{
                //    if (allAnimals[j].myID == i)
                //    {
                //        AddAnimal(allAnimals[j]);
                //        //obtainedAnimals.Add(allAnimals[j]);
                //    }
                //}
            }
            
        }
        return obtainedAnimals;
    }

    public int GetShopLevel()
    {
        if (PlayerPrefs.GetInt("ShopLevel") == 0)
        {
            PlayerPrefs.SetInt("ShopLevel", 1);
        }
        return PlayerPrefs.GetInt("ShopLevel");
        //return effects that buildings provide, perhaps pass in which building type as an argument
    }

    public void SetShopLevel(int value)
    {
        PlayerPrefs.SetInt("ShopLevel", value);
        //go into player prefs, enable certain variables with effects.
    }

    public int GetHabitatLevel()
    {
        if (PlayerPrefs.GetInt("HabitatLevel") == 0)
        {
            PlayerPrefs.SetInt("HabitatLevel", 1);
        }
        return PlayerPrefs.GetInt("HabitatLevel");
    }

    public void SetHabitatLevel(int value)
    {
        Debug.Log(value);
        PlayerPrefs.SetInt("HabitatLevel", value);
        //go into player prefs, enable certain variables with effects.
    }

    public void ClearPlayerPrefs()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void SetHeadSlotItem(Item item)
    {
        equippedHeadSlotItem = item;
        PlayerPrefs.SetInt("HeadSlotItem", equippedHeadSlotItem.itemID);
        Debug.Log("Set headslot item to: " + item.itemName);
    }

    public Item GetHeadSlotItem()
    {
        equippedHeadSlotItem = headSlotItems[PlayerPrefs.GetInt("HeadSlotItem")];
        return equippedHeadSlotItem;
    }

    public void SetUnlockedLocks(int index)
    {
        PlayerPrefs.SetInt("UnlockedLock" + index, 1);
    }

    public int GetUnlockedLocks(int index)
    {
        return PlayerPrefs.GetInt("UnlockedLock" + index);
    }


    public void SetAnimalCount(Animal animal)
    {
        PlayerPrefs.SetInt("AnimalCount" + animal.myID, GetAnimalCount(animal.myID) + 1);
    }

    public int GetAnimalCount(int index)
    {
        return PlayerPrefs.GetInt("AnimalCount" + index);
    }

    public List<Animal> GetAllAnimals()
    {
        return allAnimals;
    }
    public int GetBaseRunTime()
    {
        return baseRunTime;
    }

    public void SetBaseRuneTime(int value)
    {
        if (value > 0)
        {
            baseRunTime = value;
        }
    }


    public List<Mission> GetMissions()
    {
        currentMissions = new List<Mission>();
        //get data from playerprefs
        for (int i = 0; i < PlayerPrefs.GetInt("NumberOfAvailableMissions"); i++)
        {
            //this -1 at missionanimal is necessary because the fish ID's start at one while the list of allFish starts at index 0.
            Mission mission = new Mission(allAnimals[PlayerPrefs.GetInt("MissionAnimal" + i) -1], PlayerPrefs.GetInt("MissionDuration" + i), PlayerPrefs.GetFloat("MissionDifficulty" + i), i);

            currentMissions.Add(mission);
        }
        return currentMissions;
    }

    public void AddMission(Mission mission)
    {
        if (currentMissions.Count < 3)
        {
            currentMissions.Add(mission);
        }
        PlayerPrefs.SetInt("NumberOfAvailableMissions", currentMissions.Count);

        for (int j=0; j<3; j++)
        {
            PlayerPrefs.SetInt("MissionAnimal" + j, 0);
            PlayerPrefs.SetInt("MissionDuration" + j, 0);
            PlayerPrefs.SetFloat("MissionDifficulty" + j, 0);
        }

        for (int i=0; i<currentMissions.Count; i++)
        {
            PlayerPrefs.SetInt("MissionAnimal" + i, currentMissions[i].GetMissionAnimal().myID);
            PlayerPrefs.SetInt("MissionDuration" + i, currentMissions[i].GetMissionRunTime());
            PlayerPrefs.SetFloat("MissionDifficulty" + i, currentMissions[i].GetDifficultyModifier());
        }
    }

    public int GetMissionCount()
    {
        return PlayerPrefs.GetInt("NumberOfAvailableMissions");
    }


    public void SetUnseenMissionNotification(int value)
    {
        PlayerPrefs.SetInt("UnseenMissionNotifications", value);
    }

    public int GetUnseenMissionNotifications()
    {
        return PlayerPrefs.GetInt("UnseenMissionNotifications");
    }

    //mission getters and setters
    public void SetMissionRun(Mission mission)
    {
        currentMission = mission;
        isMissionRun = true;
    }

    public void EndMissionRun()
    {
        currentMission = null;
        isMissionRun = false;
    }

    public Mission GetMissionRun()
    {
        return currentMission;
    }

    public bool GetIsMissionRun()
    {
        return isMissionRun;
    }

    public void SetIsMissionRun(bool value)
    {
        isMissionRun = value;
    }

    public void RemoveMissionFromList(int index)
    {
        currentMissions.RemoveAt(index);

        for (int k = 0; k < currentMissions.Count; k++)
        {
            currentMissions[k].SetMissionIndex(k);
        }

        PlayerPrefs.SetInt("NumberOfAvailableMissions", currentMissions.Count);

        for (int j = 0; j < 3; j++)
        {
            PlayerPrefs.SetInt("MissionAnimal" + j, 0);
            PlayerPrefs.SetInt("MissionDuration" + j, 0);
            PlayerPrefs.SetFloat("MissionDifficulty" + j, 0);
        }

        for (int i = 0; i < currentMissions.Count; i++)
        {
            PlayerPrefs.SetInt("MissionAnimal" + i, currentMissions[i].GetMissionAnimal().myID);
            PlayerPrefs.SetInt("MissionDuration" + i, currentMissions[i].GetMissionRunTime());
            PlayerPrefs.SetFloat("MissionDifficulty" + i, currentMissions[i].GetDifficultyModifier());
        }

    }



    //flipper slot
    public void SetFlipperSlot(Item item)
    {
        Debug.Log("Set flipper slot to: " + item.itemName);

        PlayerPrefs.SetInt("EquippedFlipperID", item.itemID);

    }

    public Item GetFlipperSlot()
    {
        equippedFlipperSlot = flipperSlotItems[0];

        for (int i=0; i<flipperSlotItems.Count; i++)
        {
            if (flipperSlotItems[i].itemID == PlayerPrefs.GetInt("EquippedFlipperID"))
            {
                equippedFlipperSlot = flipperSlotItems[i];
            }
        }

        return equippedFlipperSlot;
    }

}
