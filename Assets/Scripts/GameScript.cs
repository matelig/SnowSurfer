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
    void Start() {
        coinsText = GameObject.Find("Coins").GetComponent<Text>();
        pointsText = GameObject.Find("ActualScore").GetComponent<Text>();
        GameObject thePlayer = GameObject.Find("model1");
        controlScript = thePlayer.GetComponent<CharacterControlScript>();
        GameObject buttonsPanel = GameObject.Find("pauseMenu");
        pmbScript = buttonsPanel.GetComponent<PauseMenuButtons>();
    }

    // Update is called once per frame
    void Update() {
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

    public Boolean saveHighscore()
    {
        Boolean isNewHighscore = false;
        int[] previousHighscores = getPreviousHighscores();
        int[] temp = new int[6];


        for (int i = 0; i < 5; i++)
        {
            temp[i] = previousHighscores[i];
        }
        temp[5] = score;
        Array.Sort(temp);
        Array.Reverse(temp);

        for (int i = 0; i < 5; i++)
            if (temp[i] == score)
                isNewHighscore = true;
      
        saveUpdatedHighscores(temp);
  
    
        

        return isNewHighscore;
    }
    private void saveUpdatedHighscores(int[] results)
    {
       PlayerPrefs.SetInt("Score0", results[0]);
        PlayerPrefs.SetInt("Score1", results[1]);
        PlayerPrefs.SetInt("Score2", results[2]);
        PlayerPrefs.SetInt("Score3", results[3]);
        PlayerPrefs.SetInt("Score4", results[4]);
    }

    private int[] updateHighscores(int score, int i, int[]previousHighscores)
    {
        int[] result = new int[5];
        for (int j = 0; j < 5; j++)
            result[j] = previousHighscores[j];
        result[i] = score;
        for (int k = i + 1; k < 5; k++, i++)
            result[k] = previousHighscores[i];

        return result;

    }

    private int[] getPreviousHighscores()
    {
        int[] result = new int[5];
       
        result[0] = PlayerPrefs.GetInt("Score0");
        result[1]= PlayerPrefs.GetInt("Score1");
        result[2] = PlayerPrefs.GetInt("Score2");
        result[3] = PlayerPrefs.GetInt("Score3");
        result[4] = PlayerPrefs.GetInt("Score4");

        return result;
    }

    public static void actualizeCoins() {
        points++;
        coinsText.text = points.ToString();
    }

}
