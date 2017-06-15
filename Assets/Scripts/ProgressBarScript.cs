using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ProgressBarScript : MonoBehaviour {

    public Image HorizontalProgressBar;
    public float MaxTime = 10f;
    private static float currentTime = 0;


	// Use this for initialization
	void Start () {
        currentTime = 0;	
	}
	
	// Update is called once per frame
	void Update () {
		if (currentTime<= MaxTime)
        {
            currentTime = currentTime + Time.deltaTime;
            HorizontalProgressBar.fillAmount = currentTime / MaxTime;
        }
	}

    public static void ResetProgressBar()
    {
        currentTime = 0;
    }

    
}
