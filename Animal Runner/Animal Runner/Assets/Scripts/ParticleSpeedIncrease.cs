using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpeedIncrease : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem trailParticles;

    private float trailSpeed = 0;

    public void SetTrailParticlesSpeed(float value)
    {
        var mainParticleModule = trailParticles.main;
        trailSpeed += value;
        mainParticleModule.startSpeed = trailSpeed;
    }
}
