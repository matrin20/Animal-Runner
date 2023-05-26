using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimalMovement : MonoBehaviour
{
    [SerializeField]
    private float xMovementSpeed;
    [SerializeField]
    private float yMovementSpeed;
    private float timer;
    private int randomNumber;
    private float turnMultiplier;
    private float xStep;
    private float yStep;
    private float randomMovementNumber;
    private float baseYIncrement;
    private float yIncrementModifier;
    private int turnInterval;

    [SerializeField]
    private GameObject leftBound;
    [SerializeField]
    private GameObject rightBound;
    private GameObject topYBound;
    private GameObject bottomYBound;
    private float verticleMultiplier;

    [SerializeField]
    private Animal animalReference;

    private float turnCooldown = 0.5f;
    private float timeSinceYTurn;
    private float timeSinceXTurn;

    // Start is called before the first frame update
    void Start()
    {
        if (animalReference.myHabitat == "Epipelagic")
        {
            leftBound = GameObject.Find("LeftXBound");
            rightBound = GameObject.Find("RightXBound");
            topYBound = GameObject.Find("TopYBound");
            bottomYBound = GameObject.Find("BottomYBound");
        } else if (animalReference.myHabitat == "Mesopelagic")
        {
            leftBound = GameObject.Find("LeftXBound2");
            rightBound = GameObject.Find("RightXBound2");
            topYBound = GameObject.Find("TopYBound2");
            bottomYBound = GameObject.Find("BottomYBound2");
        } else
        {
            leftBound = GameObject.Find("LeftXBound3");
            rightBound = GameObject.Find("RightXBound3");
            topYBound = GameObject.Find("TopYBound3");
            bottomYBound = GameObject.Find("BottomYBound3");
        }
        randomMovementNumber = Random.Range(1f, 4f);

        yIncrementModifier = 0.1f;
        baseYIncrement = yIncrementModifier;
        verticleMultiplier = 1;
        turnInterval = Random.Range(6, 10);

    }

    // Update is called once per frame
    void Update()
    {
        TurnAroundTimer();
        fishMovement();
    }

    private void TurnAroundTimer()
    {
        timeSinceXTurn += Time.deltaTime;

        if (transform.position.x < leftBound.transform.position.x || transform.position.x > rightBound.transform.position.x)
        {
            if (timeSinceXTurn > turnCooldown)
            {
                timeSinceXTurn = 0;
                turnMultiplier = -1;
                turnMultiplier *= transform.localScale.x;
                transform.localScale = new Vector2(turnMultiplier, transform.localScale.y);
            }
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = turnInterval;
            //do something

            if (timeSinceXTurn>turnCooldown)
            {
                randomNumber = Random.Range(0, 2);
                if (randomNumber == 0)
                {
                    turnMultiplier = -1;
                }
                else
                {
                    turnMultiplier = 1;
                }

                turnMultiplier *= transform.localScale.x;
                transform.localScale = new Vector2(turnMultiplier, transform.localScale.y);
            }
            
        }
    }

    private void fishMovement()
    {
        timeSinceYTurn += Time.deltaTime;

        if (transform.position.y > topYBound.transform.position.y || transform.position.y < bottomYBound.transform.position.y)
        {
            if (timeSinceYTurn > turnCooldown)
            {
                verticleMultiplier *= -1;
                timeSinceYTurn = 0;
            }
        }

        xStep = xMovementSpeed * randomMovementNumber * Time.deltaTime;
        yStep = yMovementSpeed * randomMovementNumber * verticleMultiplier * Time.deltaTime;

        if (turnMultiplier < 0)
        {
            
            xStep *= -1;
            
        }
        
        transform.position = new Vector2(transform.position.x + xStep, transform.position.y + yStep);
    }
}
