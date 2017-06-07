using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {
    public bool isPaused = false;
    public bool visible = false;
    public static int score = 0;
    public static Text coinsText;
    public static Text pointsText;
    public static int points = 0;
    private PauseMenuButtons pmbScript;
    private CharacterControlScript controlScript;
    // Use this for initialization
    void Start () {
        coinsText = GameObject.Find("Coins").GetComponent<Text>();
        pointsText = GameObject.Find("ActualScore").GetComponent<Text>();
        GameObject thePlayer = GameObject.Find("model1");
        controlScript = thePlayer.GetComponent<CharacterControlScript>();
        GameObject buttonsPanel = GameObject.Find("pauseMenu");
        pmbScript = buttonsPanel.GetComponent<PauseMenuButtons>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!controlScript.collided)
            {
                if (!visible)
                {
                    pmbScript.ShowPauseMenu();
                    GroundVariables.stop = true;
                    Time.timeScale = 0;
                    visible = true;
                    isPaused = true;
                }
                else
                {
                    pmbScript.HidePauseMenu();
                    GroundVariables.stop = false;
                    Time.timeScale = 1;
                    visible = false;
                    isPaused = false;
                }
            }
        }
    }

    public void calculateScore()
    {
        score = ShowTime.playTime + 2 * int.Parse(coinsText.text);
        pointsText.text = score.ToString();
    }

    public static void actualizeCoins() {
        points++;
        coinsText.text = points.ToString();
    }

}
