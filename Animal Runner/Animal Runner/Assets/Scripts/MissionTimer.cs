using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionTimer : MonoBehaviour
{
    private PlayerData _playerData;
    private float secondsPassed;
    [SerializeField]
    private float missionInterval;
    public static List<GameObject> existList;

    private float secondsPassedSinceSave;
    private float saveTimerInterval;

    // Start is called before the first frame update
    private void Awake()
    {
        if (existList == null)
        {
            existList = new List<GameObject>();
            existList.Add(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();
        DontDestroyOnLoad(gameObject);

        saveTimerInterval = 3;
        secondsPassed = _playerData.GetNewMissionTimer();

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
            if (GameObject.Find("MissionManager") == null)
            {
                _playerData.IncreaseNumberOfMissionsToMake();
            } else
            {
                GameObject.Find("MissionManager").GetComponent<GenerateMission>().GlobalMissionIncrease();
            }
        }
        else
        {
            secondsPassed += Time.deltaTime;
        }

    }
}
