using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float speed = 2.0f;
    float jumpSpeed = 250.0f;
    bool canJump = true;
    GameObject gameManager;
    GameObject finishZone;
    Rigidbody playerRigid;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager"); //Finding GameManager for future references e.g. Scores
        finishZone = GameObject.FindGameObjectWithTag("FinishZone"); //uses finishzone script for pickup counts
        playerRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {                                                                                       //using the input manager
        float horizontalMovement = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime; //getting x axis input and using time.deltatime to make it move 2(speed) per second, 
                                                                                        //raw makes instant speed straight away
        float verticalMovement = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime; //getting y axis input and using time.deltatime to make it move 2(speed) per second

        if ((Input.GetAxisRaw("Jump") == 1) && canJump) //checking if player can jump
        {
            playerRigid.AddForce(jumpSpeed * transform.up);
            canJump = false; //stops from jumping more than once in one go
        }

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
            finishZone.GetComponent<FinishingZone>().CollectedOne(); //used to keep count of how many is left on the level on the FinishedZone script
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor") //making sure the player can only jump one at a time
        {
            canJump = true; 
        }
    }
}
