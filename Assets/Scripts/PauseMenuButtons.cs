using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenuButtons : MonoBehaviour
{

    [SerializeField]
    public CanvasGroup buttonsGroup;
    [SerializeField]
    public CanvasGroup highscoresGroup;
    [SerializeField]
    public CanvasGroup gameOverGroup;
    [SerializeField]
    public CanvasGroup timeCoinsGroup;
    private GameScript gameScript;
    [SerializeField]
    public Text isHighscore;
    [SerializeField]
    public Text score0;
    [SerializeField]
    public Text score1;
    [SerializeField]
    public Text score2;
    [SerializeField]
    public Text score3;
    [SerializeField]
    public Text score4;

    public void ResumeButton()
    {
        GameObject game = GameObject.Find("GameController");
        gameScript = game.GetComponent<GameScript>();
        isHighscore = GameObject.Find("Highscore").GetComponent<Text>();
        score0 = GameObject.Find("Score0").GetComponent<Text>();
        score1 = GameObject.Find("Score1").GetComponent<Text>();
        score2 = GameObject.Find("Score2").GetComponent<Text>();
        score3 = GameObject.Find("Score3").GetComponent<Text>();
        score4 = GameObject.Find("Score4").GetComponent<Text>();
        HidePauseMenu();
        GroundVariables.stop = false;
        Time.timeScale = 1;
        gameScript.visible = false;
        gameScript.isPaused = false;
    }

    public void HighscoresButton()
    {
        HidePauseMenu();
        highscoresGroup.alpha = 1;
        highscoresGroup.interactable = true;
        highscoresGroup.blocksRaycasts = true;
        SetHighscores();
    }

    private void SetHighscores()
    {
        GameObject game = GameObject.Find("GameController");
        gameScript = game.GetComponent<GameScript>();
        int[] results = gameScript.GetPreviousHighscores();
        score0.text = "1. " + results[0];
        score1.text = "2. " + results[1];
        score2.text = "3. " + results[2];
        score3.text = "4. " + results[3];
        score4.text = "5. " + results[4];

    }
    public void BackButton()
    {
        ShowPauseMenu();
        highscoresGroup.alpha = 0;
        highscoresGroup.interactable = false;
        highscoresGroup.blocksRaycasts = false;
    }

    public void HideHighscoresMenu()
    {
        highscoresGroup.alpha = 0;
        highscoresGroup.interactable = false;
        highscoresGroup.blocksRaycasts = false;
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
        GameScript.resetCoins();
        GroundVariables.coinMultipler = 1;
        GroundVariables.normalControll = true;
        GroundVariables.stop = false;
        GroundVariables.gameSpeed = 0.3f;
        Time.timeScale = 1;
        ShowTime.playTime = 0;
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowPauseMenu()
    {
        buttonsGroup.alpha = 1;
        buttonsGroup.interactable = true;
        buttonsGroup.blocksRaycasts = true;
    }

    public void HidePauseMenu()
    {
        buttonsGroup.alpha = 0;
        buttonsGroup.interactable = false;
        buttonsGroup.blocksRaycasts = false;
    }

    public void ShowGameOverMenu()
    {
        GameObject game = GameObject.Find("GameController");
        gameScript = game.GetComponent<GameScript>();
        gameScript.calculateScore();
        isHighscore.gameObject.SetActive(gameScript.SaveHighscore());
        gameOverGroup.alpha = 1;
        gameOverGroup.interactable = true;
        gameOverGroup.blocksRaycasts = true;
    }

    public void HideTimeCoinsGroup()
    {
        timeCoinsGroup.alpha = 0;
        timeCoinsGroup.interactable = false;
        timeCoinsGroup.blocksRaycasts = false;
    }
}
