using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{

    int score;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0; //set as default
        scoreText.text = "Score: " + score.ToString(); //displaying score
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
}
