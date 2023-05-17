using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission
{
    private Animal animalReward;
    private int runTime;
    private float difficultyModifier;
    private int missionIndex;
    public Mission(Animal reward, int time, float modifier, int index)
    {
        this.animalReward = reward;
        this.runTime = time;
        this.difficultyModifier = modifier;
        this.missionIndex = index;
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

    public int GetMissionIndex()
    {
        return missionIndex;
    }

    public void SetMissionIndex(int value)
    {
        missionIndex = value;
    }
}
