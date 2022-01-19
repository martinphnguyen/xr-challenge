using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishingZone : MonoBehaviour
{

    int pickUpCount;
    GameObject[] stars;
    GameObject gameManager;
    MeshRenderer meshRenderer;
    ParticleSystem particleSystem;
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

        meshRenderer = GetComponent<MeshRenderer>();
        
        particleSystem = gameObject.transform.GetComponentInChildren<ParticleSystem>();
        

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void CollectedOne()
    {
        pickUpCount--;
        Debug.Log(pickUpCount);

        if(pickUpCount == 0)
        {
            SetZone();
        }
    }

    private void SetZone()
    {

            particleSystem.Play();
            meshRenderer.material.color = Color.green;
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
