using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

    [SerializeField]
    public CanvasGroup highscoresGroup;
    [SerializeField]
    public CanvasGroup menuGroup;

    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }

    public void TutorialButton()
    {

    }

    public void HighScoresButton()
    {
        menuGroup.alpha = 0;
        menuGroup.interactable = false;
        menuGroup.blocksRaycasts = false;
        highscoresGroup.alpha = 1;
        highscoresGroup.interactable = true;
        highscoresGroup.blocksRaycasts = true;
    }

    public void BackButton()
    {
        menuGroup.alpha = 1;
        menuGroup.interactable = true;
        menuGroup.blocksRaycasts = true;
        highscoresGroup.alpha = 0;
        highscoresGroup.interactable = false;
        highscoresGroup.blocksRaycasts = false;
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
