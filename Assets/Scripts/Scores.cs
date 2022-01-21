using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scores : MonoBehaviour
{

    int score;
    public Text scoreText;
    public Text highscoreText;

    string lScore = "score"; //for current game
    string hScore = "highscore"; //for highest score

    float timer;
    public Text timerText;
    bool gameOver;

    Scene currentScene;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene(); //seeing what scene we are in to do different things
        if (currentScene.name == "Main") //game scene
        {
            score = 0; //set as default
            scoreText.text = "Score: " + score.ToString(); //displaying score
            timer = 120.0f;
            timerText.text = timer.ToString("F0"); //displaying timer
        }
        else
            if (currentScene.name == "Scores")
        {
            DisplayScore();
        }

        gameOver = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentScene.name == "Main")
        {
            timer -= Time.deltaTime; //clock countdown
            timerText.text = timer.ToString("F0"); //displaying timer
        }

        if (timer < 0.0f && !gameOver) //time ran out so game over
        {
            gameOver = true;
            GameOver();
        }
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Score: " + score.ToString();

    }

    public int ReturnScore()
    {
        return score;
    }

    public void SaveScore(int score)
    {
        int newScore = score * (int)timer;
        PlayerPrefs.SetInt(lScore, newScore); //set current game save

        int high = PlayerPrefs.GetInt(hScore);
        if (newScore > high) //check if its higher than the highest saved score
        {
            PlayerPrefs.SetInt(hScore, newScore); //overwrite if it is
        }
    }

    void DisplayScore()
    {
        scoreText.text = PlayerPrefs.GetInt(lScore).ToString();

        highscoreText.text = PlayerPrefs.GetInt(hScore).ToString();
    }

    public void GameOver()
    {

        SaveScore(0);
        SceneManager.LoadScene("Scores");
    }
}
