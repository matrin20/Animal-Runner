using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionHolder : MonoBehaviour
{

    private Mission myMission;

    private PlayerData _playerData;
    [SerializeField]
    private PopulateMissionData _populator;

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
    }



}
