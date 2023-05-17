using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission
{
    private Animal animalReward;
    private int runTime;
    private float difficultyModifier;

    public Mission(Animal reward, int time, float modifier)
    {
        this.animalReward = reward;
        this.runTime = time;
        this.difficultyModifier = modifier;
    }

    public Animal GetMissionAnimal()
    {
        return animalReward;
    }

    public int GetMissionRunTime()
    {
        return runTime;
    }

    public float GetDifficultyModifier()
    {
        return difficultyModifier;
    }

}
