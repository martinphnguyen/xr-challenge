using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishingZone : MonoBehaviour
{

    int pickUpCount;
    GameObject[] stars;
    GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        pickUpCount = 0;

        //check how many pick ups there are on the level
        stars = GameObject.FindGameObjectsWithTag("Pickup");
        foreach(GameObject star in stars)
        {
            pickUpCount++;
        }
        Debug.Log(pickUpCount);

        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectedOne()
    {
        pickUpCount--;
        Debug.Log(pickUpCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && pickUpCount == 0)
        {
            int score = gameManager.GetComponent<Scores>().ReturnScore();
            Debug.Log(score);
            gameManager.GetComponent<Scores>().SaveScore(score);
            SceneManager.LoadScene("Scores");
        }
        else
        {
            Debug.Log("Not finished yet");
        }
    }
}
