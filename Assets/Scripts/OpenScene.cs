using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void GoBackToMenu()
    {
        SceneManager.LoadScene("Menus");
    } 
    public void OpenScores()
    {
        SceneManager.LoadScene("Scores");
    }
    public void OpenCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void OpenHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
