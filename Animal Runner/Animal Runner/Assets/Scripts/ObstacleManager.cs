using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField]
    private float obstacleSpeed;

    private float distanceUntilNextSpawn;
    private List<GameObject> Obstacles;

    [SerializeField]
    private List<GameObject> ObstaclePool;
    [SerializeField]
    private List<GameObject> ObstaclePool2;
    [SerializeField]
    private List<GameObject> ObstaclePool3;
    private List<List<GameObject>> AllObstaclePools;

    private float speedIncreaseTimer;
    [SerializeField]
    private float speedIncrement;
    //this value would be driven by equipped items
    private float speedIncrementModifier;
    private PlayerData _playerData;
    private int biomeDepthIndex;

    private bool isMissionRun;

    // Start is called before the first frame update
    void Start()
    {
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();
        isMissionRun = _playerData.GetIsMissionRun();

        if (isMissionRun)
        {
            if (_playerData.GetMissionRun().GetMissionAnimal().myHabitat == "Mesopelagic")
            {
                biomeDepthIndex = 1;
            }
            else if (_playerData.GetMissionRun().GetMissionAnimal().myHabitat == "Abyssopelagic")
            {
                biomeDepthIndex = 2;
            }
            else
            {
                biomeDepthIndex = 0;
            }

            speedIncrement = _playerData.GetMissionRun().GetDifficultyModifier();
        } else
        {
            biomeDepthIndex = _playerData.GetHeadSlotItem().itemID;
        }

        AllObstaclePools = new List<List<GameObject>>();
        AllObstaclePools.Add(ObstaclePool);
        AllObstaclePools.Add(ObstaclePool2);
        AllObstaclePools.Add(ObstaclePool3);

        SpeedModifierCalculation();
        speedIncrement -= speedIncrementModifier;

        Obstacles = new List<GameObject>();
        distanceUntilNextSpawn = 19.20f;
        SpawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnDistanceCheck();
        IncreaseSpeed();
    }

    public void SpawnObstacle()
    {
        Obstacles.Add(Instantiate(AllObstaclePools[biomeDepthIndex][Random.Range(0, AllObstaclePools[biomeDepthIndex].Count)],transform));
    }

    public float GetObstacleSpeed()
    {
        return obstacleSpeed;
    }

    public void SetGlobalObstacleSpeed(float speed)
    {
        obstacleSpeed = speed;
        UpdateObstacleSpeed();
    }

    void SpawnDistanceCheck()
    {
        if (Obstacles[Obstacles.Count - 1].GetComponent<Obstacle>().GetDistanceTravelled() > distanceUntilNextSpawn) {
            SpawnObstacle();
        }
    }

    public void RemoveObjectFromObstacles(GameObject obstacle)
    {
        Obstacles.Remove(obstacle);
    }

    private void UpdateObstacleSpeed()
    {
        for (int i = 0; i<Obstacles.Count; i++)
        {
            Obstacles[i].GetComponent<Obstacle>().SetObstacleSpeed();
        }
    }

    private void IncreaseSpeed()
    {
        if (speedIncreaseTimer < 3)
        {
            speedIncreaseTimer += Time.deltaTime;
        } else
        {
            speedIncreaseTimer = 0;
            SetGlobalObstacleSpeed(obstacleSpeed + speedIncrement);
        }
    }

    public float GetSpeedIncrement()
    {
        return speedIncrement;
    }

    private void SpeedModifierCalculation()
    {
        Item flipperslot = _playerData.GetFlipperSlot();

        if (flipperslot.itemID == 3)
        {
            speedIncrementModifier = speedIncrement / 2;

        } else if (flipperslot.itemID == 4)
        {
            speedIncrementModifier = speedIncrement / 4;
        } else if (flipperslot.itemID == 5)
        {
            speedIncrementModifier = 0;
        }


    }

}
