using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuButtons : MonoBehaviour {

    [SerializeField]
    public CanvasGroup buttonsGroup;
    [SerializeField]
    public CanvasGroup highscoresGroup;
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

    internal void HideHighscoresMenu()
    {
        highscoresGroup.alpha = 0;
        highscoresGroup.interactable = false;
        highscoresGroup.blocksRaycasts = false;
    }

    public void QuitButton()
    {
        Application.Quit();
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

}
