using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBiomeManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> epiParallaxObjects;
    [SerializeField]
    private List<GameObject> mesoParallaxObjects;
    [SerializeField]
    private List<GameObject> abyssoParallaxObjects;
    private List<List<GameObject>> allParallaxObjects;
    private List<ParallaxElements> allParallaxElements;
    private PlayerData _playerData;
    private int currentBiome;

    // Start is called before the first frame update
    void Start()
    {
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();
        allParallaxObjects = new List<List<GameObject>>();
        allParallaxObjects.Add(epiParallaxObjects);
        allParallaxObjects.Add(mesoParallaxObjects);
        allParallaxObjects.Add(abyssoParallaxObjects);

        allParallaxElements = new List<ParallaxElements>();

        for (int i=0; i < epiParallaxObjects.Count; i++)
        {
            epiParallaxObjects[i].SetActive(false);
        }

        for (int i = 0; i < mesoParallaxObjects.Count; i++)
        {
            mesoParallaxObjects[i].SetActive(false);
        }

        for (int i = 0; i < abyssoParallaxObjects.Count; i++)
        {
            abyssoParallaxObjects[i].SetActive(false);
        }

        BiomeChecker();
        CreateParallaxList();
    }



    private void BiomeChecker()
    {
        if (_playerData.GetIsMissionRun())
        {
            if (_playerData.GetMissionRun().GetMissionAnimal().myHabitat == "Epipelagic")
            {
                currentBiome = 0;
            } else if (_playerData.GetMissionRun().GetMissionAnimal().myHabitat == "Mesopelagic")
            {
                currentBiome = 1;
            } else
            {
                currentBiome = 2;
            }
        } else
        {
            currentBiome = _playerData.GetHeadSlotItem().itemID;
        }


        for (int i=0; i<allParallaxObjects[currentBiome].Count; i++)
        {
            allParallaxObjects[currentBiome][i].SetActive(true);
        }

    }

    private void CreateParallaxList()
    {
        for (int i = 0; i < epiParallaxObjects.Count; i++)
        {
            allParallaxElements.Add(epiParallaxObjects[i].GetComponent<ParallaxElements>());
        }

        for (int j = 0; j < mesoParallaxObjects.Count; j++)
        {
            allParallaxElements.Add(mesoParallaxObjects[j].GetComponent<ParallaxElements>());
        }

        for (int k = 0; k < abyssoParallaxObjects.Count; k++)
        {
            allParallaxElements.Add(abyssoParallaxObjects[k].GetComponent<ParallaxElements>());
        }
    }



    public List<ParallaxElements> GetParallaxElements()
    {
        return allParallaxElements;
    }


}
