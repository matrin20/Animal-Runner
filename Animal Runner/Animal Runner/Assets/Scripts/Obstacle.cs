using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float xSpawnpoint;
    private float xDistanceTravelled;

    private float obstacleDeletePoint;
    private float _obstacleSpeed;
    private ObstacleManager obstacleManager;


    //private RunManager runManagerReference;

    // Start is called before the first frame update
    void Start()
    {
        //perhaps more efficient to predefine ObstacleManager in the editor itself?
        obstacleManager = GameObject.Find("ObstacleManager").GetComponent<ObstacleManager>();
        obstacleDeletePoint = GameObject.Find("ObstacleDeletePoint").transform.position.x;
        xSpawnpoint = obstacleManager.transform.position.x;
        SetObstacleSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DeleteGameObject();
    }

    void Move()
    {
        //incrementally decrease the x value.
        gameObject.transform.position = new Vector2(gameObject.transform.position.x - _obstacleSpeed * Time.deltaTime, 0) ;
    }

    public float GetDistanceTravelled()
    {
        xDistanceTravelled = gameObject.transform.position.x - xSpawnpoint;
        xDistanceTravelled *= -1;
        return xDistanceTravelled;
    }

    void DeleteGameObject()
    {
        if (gameObject.transform.position.x < obstacleDeletePoint)
        {
            obstacleManager.RemoveObjectFromObstacles(gameObject);
            Destroy(gameObject);
        }
    }
    public void SetObstacleSpeed()
    {
        _obstacleSpeed = obstacleManager.GetObstacleSpeed();
    }


}
