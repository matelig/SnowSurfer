using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Density
{
    LightSnow,
    MediumSnow,
    SnowStorm
}

public class SnowControl : MonoBehaviour {
    public float characterSpeed = 5;
    public bool turnedOn = true;
    public Density snowType = Density.LightSnow;

    ParticleSystem pSystem
    {
        get
        {
            if (_CachedSystem == null)
                _CachedSystem = GetComponent<ParticleSystem>();
            return _CachedSystem;
        }
    }

    private float currentSpeed;
    private float currentEmission;
    private ParticleSystem _CachedSystem;

	void Start ()
    {
        currentSpeed = characterSpeed;
        currentEmission = pSystem.emission.rateOverTime.constant;
        var emission = pSystem.emission.rateOverTime;
        emission.mode = ParticleSystemCurveMode.Constant;
    }
	
	void Update ()
    {
        if (turnedOn)
        {
            if (!pSystem.isPlaying)
                pSystem.Play();
            if (currentSpeed != characterSpeed)
                updateCharactersSpeed();
            if (currentEmission != getEmissionFromDensity(snowType))
            {
                updateSnowType();
            }
                
        }
        else
            if (pSystem.isPlaying)
                pSystem.Stop();
	}

    private void updateCharactersSpeed()
    {
        var velocity = pSystem.velocityOverLifetime;
        velocity.y = new ParticleSystem.MinMaxCurve(-characterSpeed, -characterSpeed * 1.5f);
        currentSpeed = characterSpeed;
    }

    private void updateSnowType()
    {
        currentEmission = getEmissionFromDensity(snowType);
        var emission = pSystem.emission;
        emission.rateOverTime = currentEmission;
    }

    private float getEmissionFromDensity(Density d)
    {
        switch(d)
        {
            case Density.LightSnow:
                return 50f;
            case Density.SnowStorm:
                return 1500f;
            case Density.MediumSnow:
                return 500f;
            default:
                return 0;
        }
    }
}
