using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float speed = 2.0f;
    //float jump = 2.0f;
    GameObject gameManager;
    GameObject finishZone;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager"); //Finding GameManager for future references e.g. Scores
        finishZone = GameObject.FindGameObjectWithTag("FinishZone"); //uses finishzone script for pickup counts
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
           int addScore = other.GetComponent<Pickup>().GetPickedUp(); //colliding with star allows to access function for collecting star
            gameManager.GetComponent<Scores>().AddScore(addScore); //add score function
            other.gameObject.GetComponent<CapsuleCollider>().enabled = false; //disabling so we cant go over it again
            finishZone.GetComponent<FinishingZone>().CollectedOne();
            
        }

    }


}
