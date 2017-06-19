using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour {

    [SerializeField]
    public CanvasGroup highscoresGroup;
    [SerializeField]
    public CanvasGroup menuGroup;
    [SerializeField]
    public CanvasGroup tutorialGroup;
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

    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
        GroundVariables.stop = false;
        GroundVariables.gameSpeed = 0.3f;
        GameScript.resetCoins();
        GroundVariables.coinMultipler = 1;
        GroundVariables.normalControll = true;
        Time.timeScale = 1;
        ShowTime.playTime = 0;
    }

    public void TutorialButton()
    {
        menuGroup.alpha = 0;
        menuGroup.interactable = false;
        menuGroup.blocksRaycasts = false;
        tutorialGroup.alpha = 1;
        tutorialGroup.interactable = true;
        tutorialGroup.blocksRaycasts = true;
    }

    public void HighScoresButton()
    {
        menuGroup.alpha = 0;
        menuGroup.interactable = false;
        menuGroup.blocksRaycasts = false;
        highscoresGroup.alpha = 1;
        highscoresGroup.interactable = true;
        highscoresGroup.blocksRaycasts = true;
        ShowHighscores();
    }

    public void ShowHighscores()
    {

        int[] results =GetPreviousHighscores();
        score0.text = "1. " + results[0];
        score1.text = "2. " + results[1];
        score2.text = "3. " + results[2];
        score3.text = "4. " + results[3];
        score4.text = "5. " + results[4];
    }

    private int[] GetPreviousHighscores()
    {
        int[] result = new int[5];

        result[0] = PlayerPrefs.GetInt("Score0");
        result[1] = PlayerPrefs.GetInt("Score1");
        result[2] = PlayerPrefs.GetInt("Score2");
        result[3] = PlayerPrefs.GetInt("Score3");
        result[4] = PlayerPrefs.GetInt("Score4");

        return result;
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

    public void TutorialBackButton()
    {
        menuGroup.alpha = 1;
        menuGroup.interactable = true;
        menuGroup.blocksRaycasts = true;
        tutorialGroup.alpha = 0;
        tutorialGroup.interactable = false;
        tutorialGroup.blocksRaycasts = false;
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
