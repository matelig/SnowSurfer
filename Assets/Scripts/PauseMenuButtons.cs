using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour {

    [SerializeField]
    public CanvasGroup buttonsGroup;
    [SerializeField]
    public CanvasGroup highscoresGroup;
    [SerializeField]
    public CanvasGroup gameOverGroup;
    [SerializeField]
    public CanvasGroup timeCoinsGroup;
    private GameScript gameScript;

	public void ResumeButton()
    {
        GameObject game = GameObject.Find("GameController");
        gameScript = game.GetComponent<GameScript>();
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
        GroundVariables.stop = false;
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
