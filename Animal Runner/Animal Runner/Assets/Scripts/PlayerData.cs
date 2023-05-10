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

    private int shopLevel;
    //private Building habitatBuilderData;

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

    public void AddCurrency(int amount)
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
        Debug.Log(animal);
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
        for (int i=0; i<allAnimals.Count; i++)
        {
            if (PlayerPrefs.GetInt("UnlockedAnimalID" + i) == 1)
            {
                for (int j = 0; j<allAnimals.Count; j++)
                {
                    if (allAnimals[j].myID == i)
                    {
                        AddAnimal(allAnimals[j]);
                        //obtainedAnimals.Add(allAnimals[j]);
                    }
                }
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

}
