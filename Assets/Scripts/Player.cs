using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float speed = 2.0f;
    float jump = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime; //getting x axis and using time.deltatime to make it move 2(speed) per second, 
                                                                                        //raw makes instant speed straight away
        float verticalMovement = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime; //getting y axis and using time.deltatime to make it move 2(speed) per second
        Vector3 Movement = new Vector3(horizontalMovement, 0 , verticalMovement); //creating vecter3 to use for movement, 0 on y since we are moving on one plane
        
        this.transform.Translate(Movement);

        

    }
}
