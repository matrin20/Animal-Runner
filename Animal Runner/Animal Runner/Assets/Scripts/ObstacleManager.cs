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

    private float speedIncreaseTimer;
    [SerializeField]
    private float speedIncrement;
    //this value would be driven by equipped items
    private float speedIncrementModifier;

    // Start is called before the first frame update
    void Start()
    {
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
        Obstacles.Add(Instantiate(ObstaclePool[Random.Range(0, ObstaclePool.Count)],transform));
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

}
