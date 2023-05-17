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
        biomeDepthIndex = _playerData.GetHeadSlotItem().itemID;
        AllObstaclePools = new List<List<GameObject>>();
        AllObstaclePools.Add(ObstaclePool);
        AllObstaclePools.Add(ObstaclePool2);
        AllObstaclePools.Add(ObstaclePool3);
        speedIncrement += speedIncrementModifier;
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

    private void SetSpeedIncrement()
    {
       // speedIncrement += _playerData.get
    }

}
