using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionHolder : MonoBehaviour
{

    private Mission myMission;

    private PlayerData _playerData;
    [SerializeField]
    private PopulateMissionData _populator;


    [SerializeField]
    private List<GameObject> icons;
    [SerializeField]
    private List<GameObject> rarityIcons;
    private GameObject currentRarityIcon;

    private void Start()
    {
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();
    }

    public void SetMyMission(Mission mission)
    {
        myMission = mission;
    }

    public void RemoveMyMission()
    {
        myMission = null;
    }

    public Mission GetMyMission()
    {
        return myMission;
    }

    public void SetPlayerDataMission()
    {
        _playerData.SetMissionRun(myMission);
    }

    public void DeleteMyMission()
    {
        _playerData.RemoveMissionFromList(myMission.GetMissionIndex());
        _populator.DecreaseCurrentNumberOfMissions();
        DeactivateIcons();
    }

    public void ActivateIcons()
    {
        if (myMission.GetMissionAnimal().myRarity == "Common")
        {
            currentRarityIcon = rarityIcons[0];
        } else if (myMission.GetMissionAnimal().myRarity == "Uncommon")
        {
            currentRarityIcon = rarityIcons[1];
        }
        else if (myMission.GetMissionAnimal().myRarity == "Rare")
        {
            currentRarityIcon = rarityIcons[2];
        }
        icons.Add(currentRarityIcon);

        for (int i =0; i<icons.Count; i++)
        {
            icons[i].SetActive(true);
        }
    }

    public void DeactivateIcons()
    {
        for (int i = 0; i < icons.Count; i++)
        {
            icons[i].SetActive(false);
        }

        for (int j = 0; j< rarityIcons.Count; j++)
        {
            rarityIcons[j].SetActive(false);
        }

        if (icons.Contains(currentRarityIcon))
        {
            icons.Remove(currentRarityIcon);
            currentRarityIcon = null;
            Debug.Log("Contained rarity icon removed");
        }
    }

}
