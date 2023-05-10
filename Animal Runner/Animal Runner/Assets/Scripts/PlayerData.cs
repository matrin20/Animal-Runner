using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //probably gonna read playerprefs from this DDOL object

    [SerializeField]
    private int currency;

    private List<Animal> obtainedAnimals;

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
        }

    }

    public List<Animal> GetAnimals()
    {
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

    public void SetHeadSlotItem(int value)
    {
        PlayerPrefs.SetInt("HeadSlotItem", value);
    }

    public int GetHeadSlotItem()
    {
        return PlayerPrefs.GetInt("HeadSlotItem");
    }

}
