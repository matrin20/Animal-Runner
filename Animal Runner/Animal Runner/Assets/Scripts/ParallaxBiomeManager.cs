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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BiomeChecker()
    {
        currentBiome = _playerData.GetHeadSlotItem().itemID;

        for (int i=0; i<allParallaxObjects[currentBiome].Count; i++)
        {
            allParallaxObjects[currentBiome][i].SetActive(true);
        }

    }


}