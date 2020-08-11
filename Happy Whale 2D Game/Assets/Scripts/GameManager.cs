using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public delegate void GameDelegate();
    public static event GameDelegate OnGameStarted;
    public static event GameDelegate OnGameOverConfirmed;

    public static GameManager Instance;

    //public GameObject SplashScreen;
    //public GameObject CreditScene;
    public GameObject StartScreen;
    public GameObject GameOverScreen;
    public GameObject CountdownScreen;
    public Text ScoreText;

    enum ScreenState
    {
        None,
        Start,
        GameOver,
        Countdown
    }

    int score = 0;
    bool gameOver = true;
    public int Score
    {
        get { return score; }
    }

    public bool GameOver
    {
        get { return gameOver; }
    }

    void Awake ()
    {
        Instance = this;
    }

    void OnEnable()
    {
        CountDownText.OnCountdownFinished += OnCountdownFinished;
        TapController.OnPlayerDied += OnPlayerDied;
        TapController.OnPlayerScored += OnPlayerScored;
    }

    void OnDisable()
    {
        CountDownText.OnCountdownFinished -= OnCountdownFinished;
        TapController.OnPlayerDied -= OnPlayerDied;
        TapController.OnPlayerScored -= OnPlayerScored;
    }

    void OnCountdownFinished()
    {
        SetScreenState(ScreenState.None);
        OnGameStarted();
        score = 0;
        gameOver = false;

    }

    void OnPlayerDied()
    {
        gameOver = true;
        int savedScore = PlayerPrefs.GetInt("HighScore");
        if (score > savedScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        SetScreenState(ScreenState.GameOver);
    }

    void OnPlayerScored()
    {
        score++;
        ScoreText.text = score.ToString();
    }
    void SetScreenState(ScreenState state)
    {
        switch(state)
        {
            case ScreenState.None:
                StartScreen.SetActive(false);
                GameOverScreen.SetActive(false);
                CountdownScreen.SetActive(false);
                break;

            case ScreenState.Start:
                StartScreen.SetActive(true);
                GameOverScreen.SetActive(false);
                CountdownScreen.SetActive(false);
                break;

            case ScreenState.GameOver:
                StartScreen.SetActive(false);
                GameOverScreen.SetActive(true);
                CountdownScreen.SetActive(false);
                break;

            case ScreenState.Countdown:
                StartScreen.SetActive(false);
                GameOverScreen.SetActive(false);
                CountdownScreen.SetActive(true);
                break;
        }
    }

    public void ConfirmGameOver()
    {
        //activated when replay button is hit
        OnGameOverConfirmed(); //event sent to tap controller
        ScoreText.text = "0";
        SetScreenState(ScreenState.Start);
    }

    public void StartGame()
    {
        //activated when play button is hit
        SetScreenState(ScreenState.Countdown);
    }
}
