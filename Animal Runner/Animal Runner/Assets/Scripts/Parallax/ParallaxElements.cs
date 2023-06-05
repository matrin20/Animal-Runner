using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxElements : MonoBehaviour
{
    [SerializeField]
    private GameObject parallaxLeftPoint;
    [SerializeField]
    private GameObject parallaxRightPoint;
    [SerializeField]
    private float parallaxSpeed;
    private float foreGroundParallaxSpeed;

    [SerializeField]
    private bool isForeGroundElement;
    private float speedIncreaseTimer = 0;
    private float speedIncreaseInterval = 3;

    [SerializeField]
    private ObstacleManager _obstacleManager;
    private float speedIncrement;

    // Start is called before the first frame update
    void Start()
    {
        foreGroundParallaxSpeed = parallaxSpeed;
        speedIncrement = _obstacleManager.GetSpeedIncrement();
    }

    // Update is called once per frame
    void Update()
    {
        ResetParallaxElement();
        ParallaxMovement();
        SpeedIncrease();
    }

    private void ResetParallaxElement()
    {
        if (gameObject.transform.position.x <= parallaxLeftPoint.transform.position.x)
        {
            gameObject.transform.position = new Vector2(parallaxRightPoint.transform.position.x, gameObject.transform.position.y);
        }
    }

    private void ParallaxMovement()
    {
        float step;

        if (isForeGroundElement)
        {
            step = foreGroundParallaxSpeed * Time.deltaTime;
        }
        else
        {
            step = parallaxSpeed * Time.deltaTime;
        }

        gameObject.transform.position = new Vector2(gameObject.transform.position.x - step, gameObject.transform.position.y);
    }


    private void SpeedIncrease()
    {
        if (isForeGroundElement)
        {
            if (speedIncreaseTimer < speedIncreaseInterval)
            {
                speedIncreaseTimer += Time.deltaTime;
            }
            else
            {
                IncreaseParallaxSpeed(speedIncrement);
                speedIncreaseTimer = 0;
            }
        }
    }

    private void IncreaseParallaxSpeed(float value)
    {
        foreGroundParallaxSpeed = foreGroundParallaxSpeed + value;
    }



}
