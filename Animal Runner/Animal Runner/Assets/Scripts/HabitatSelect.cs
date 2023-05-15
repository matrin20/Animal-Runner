using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabitatSelect : MonoBehaviour
{
    [SerializeField]
    private MenuSelectItem habitatSelector;
    [SerializeField]
    private PlayerData _playerData;
    [SerializeField]
    private List<string> habitats;


    // Start is called before the first frame update
    void Start()
    {
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();
        habitatSelector.SetSceneName(habitats[_playerData.GetHabitatLevel() - 1]);
        //get-function in playerdata that returns the building level for each habitat. 
        //habitatSelector.SetSceneName("Ocean Habitat 1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
