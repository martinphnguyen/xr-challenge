using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float speed = 2.0f;
    //float jump = 2.0f;
    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager"); //Finding GameManager for future references e.g. Scores
    }

    // Update is called once per frame
    void Update()
    {                                                                                       //using the input manager
        float horizontalMovement = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime; //getting x axis input and using time.deltatime to make it move 2(speed) per second, 
                                                                                        //raw makes instant speed straight away
        float verticalMovement = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime; //getting y axis input and using time.deltatime to make it move 2(speed) per second
        Vector3 Movement = new Vector3(horizontalMovement, 0 , verticalMovement); //creating vecter3 to use for movement, 0 on y since we are moving on one plane
        
        this.transform.Translate(Movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
           int addScore = other.GetComponent<Pickup>().GetPickedUp(); //colliding with star allows to access function 
            gameManager.GetComponent<Scores>().AddScore(addScore); //add score function
        }

        if (other.tag == "FinishZone")
        {
            //check score to compare
            int checkScore = gameManager.GetComponent<Scores>().ReturnScore();

            if (checkScore == 500)
            {
                Debug.Log("Score right");
            }
            else
            {
                //Tell player to collect all stars
                Debug.Log("collect all the stars");

            }
        }
    }
}
