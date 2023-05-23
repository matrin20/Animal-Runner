using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeBuilding : MonoBehaviour
{
    private PlayerData _playerData;
    private int _currency;
    private int currentShopLevel;
    private int currentHabitatLevel;
    private GameObject currentShopBuilding;
    private GameObject currentHabitatBuilding;
    private int shopUpgradePrice;
    private int habitatUpgradePrice;
    [SerializeField]
    private TextMeshProUGUI shopPriceField;
    [SerializeField]
    private TextMeshProUGUI habitatPriceField;

    public List<Building> shopBuildings;
    public List<Building> habitatBuildings;

    [SerializeField]
    private GameObject upgradeButton;

    // Start is called before the first frame update
    void Start()
    {
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();
        //currentShopLevel = _playerData.GetShopLevel();
        //if (currentShopLevel < 3)
        //{
        //    shopUpgradePrice = shopBuildings[currentShopLevel].buildingCost;
        //    shopPriceField.text = "Upgrade Cost: " + shopUpgradePrice;
        //} else
        //{
        //    shopPriceField.text = "Max Level";
        //}
        //currentShopBuilding = Instantiate(shopBuildings[currentShopLevel-1].buildingPrefab);


        currentHabitatLevel = _playerData.GetHabitatLevel();
        if (currentHabitatLevel < 3)
        {
            habitatUpgradePrice = habitatBuildings[currentHabitatLevel].buildingCost;
            habitatPriceField.text = "Upgrade Cost: " + habitatUpgradePrice;
        }
        else
        {
            habitatPriceField.text = "Max Level";
            upgradeButton.SetActive(false);
        }
        //currentHabitatBuilding = Instantiate(habitatBuildings[currentHabitatLevel - 1].buildingPrefab);


        //shopBuildings = _playerData.GetBuildingData();
    }



    public void IncreaseShopLevel()
    {
        _currency = _playerData.GetCurrency();
        if (currentShopLevel < 3 && _currency > shopUpgradePrice)
        {
            _playerData.ChangeCurrency(shopUpgradePrice * -1);
            currentShopLevel += 1;
            _playerData.SetShopLevel(currentShopLevel);
            Destroy(currentShopBuilding);
            currentShopBuilding = Instantiate(shopBuildings[currentShopLevel-1].buildingPrefab);
            if (currentShopLevel < 3)
            {
                shopUpgradePrice = shopBuildings[currentShopLevel].buildingCost;
                shopPriceField.text = "Upgrade Cost: " + shopUpgradePrice;

            } else
            {
                shopPriceField.text = "Max Level";
            }
        } else if (_currency < shopUpgradePrice)
        {
            Debug.Log("You don't have enough currency.");
        }
    }

    public void IncreaseHabitatLevel()
    {
        _currency = _playerData.GetCurrency();
        if (currentHabitatLevel < 3 && _currency > habitatUpgradePrice)
        {
            _playerData.ChangeCurrency(habitatUpgradePrice * -1);
            currentHabitatLevel += 1;
            _playerData.SetHabitatLevel(currentHabitatLevel);
            //Destroy(currentHabitatBuilding);
            //currentHabitatBuilding = Instantiate(habitatBuildings[currentHabitatLevel - 1].buildingPrefab);
            if (currentHabitatLevel < 3)
            {
                habitatUpgradePrice = habitatBuildings[currentHabitatLevel].buildingCost;
                habitatPriceField.text = "Upgrade Cost: " + habitatUpgradePrice;

            }
            else
            {
                habitatPriceField.text = "Max Level";
                upgradeButton.SetActive(false);
            }
        }
        else if (_currency < habitatUpgradePrice)
        {
            Debug.Log("You don't have enough currency.");
        }

        //update UI to buildingData.cost[buildingData.level[x]+1]
        //
    }


}
