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
            pickUpCount++; //seeing how many there are in the scene
        }

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
        if(pickUpCount == 0)
        {
            SetZone(); //make the zone 'look' ready
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
            int score = gameManager.GetComponent<Scores>().ReturnScore(); //taking score

            gameManager.GetComponent<Scores>().SaveScore(score); //using it to save
            SceneManager.LoadScene("Scores");
        }
 
    }
}
