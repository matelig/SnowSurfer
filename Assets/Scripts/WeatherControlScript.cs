using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherControlScript : MonoBehaviour {

    public GameObject snow;
    private double nextActionTime = 0.0f;
    public double period=0.001f;
    public Weather currentWeather = Weather.Snowy;
    private Weather lastWeather;
    private System.Random randomGenerator;
    public enum Weather
    {
        ClearSky,
        Snowy,
        Foggy
    }

	// Use this for initialization
	void Start () {
        lastWeather = Weather.Snowy; 
        randomGenerator = new System.Random();
	}
	
	// Update is called once per frame
	void Update () {
        updateWeather();
        if (nextActionTime > 10.0f)
        {
            changeWeather();
            nextActionTime = 0.0f;
        }
        nextActionTime += period;
	}

    private void updateWeather()
    {
        switch (lastWeather)
        {
            case Weather.ClearSky:
                break;
            case Weather.Foggy:
                if (RenderSettings.fogEndDistance < 150)
                    RenderSettings.fogEndDistance += 0.1f;
                break;
            case Weather.Snowy:
                if (snow.GetComponent<SnowControl>().turnedOn)
                    snow.GetComponent<SnowControl>().turnedOn = false;
                break;
        }

        switch(currentWeather)
        {
            case Weather.ClearSky:
                break;
            case Weather.Foggy:
                if (RenderSettings.fogEndDistance > 50)
                    RenderSettings.fogEndDistance -= 0.1f;
                break;
            case Weather.Snowy:
                if (!snow.GetComponent<SnowControl>().turnedOn)
                {
                    SnowControl flurry = snow.GetComponent<SnowControl>();
                    flurry.turnedOn = true;
                    int index = randomGenerator.Next(0, Enum.GetNames(typeof(Density)).Length - 1);
                    flurry.snowType = (Density)index;
                }
                break;
        }
    }

    void changeWeather()
    {
        int index = randomGenerator.Next(0, Enum.GetNames(typeof(Weather)).Length-1);
        lastWeather = currentWeather;
        currentWeather = (Weather)index;
    }

}
