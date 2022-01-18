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

    string lScore = "score";
    string hScore = "highscore";

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Main")
        {
        score = 0; //set as default
        scoreText.text = "Score: " + score.ToString(); //displaying score
        }
        else 
            if( currentScene.name == "Scores")
        {
            DisplayScore();
        }



    }

    // Update is called once per frame
    void Update()
    {
        
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
        PlayerPrefs.SetInt(lScore, score);

        int high = PlayerPrefs.GetInt(hScore);
        if (score > high)
        {
            PlayerPrefs.SetInt(hScore, score);
        }
    }

    void DisplayScore()
    {
        scoreText.text = PlayerPrefs.GetInt(lScore).ToString();

        highscoreText.text = PlayerPrefs.GetInt(hScore).ToString();
    }
}
