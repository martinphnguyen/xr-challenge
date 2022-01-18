using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) //checking if any movement key is pressed
        {
            animator.SetBool("isRunning", true); //set our bool to true to allow animation
        }
        else 
            animator.SetBool("isRunning", false); //set it back to false if no movement input

        if (Input.GetAxis("Jump") != 0)
        {
            animator.SetBool("isJumping", true);
        }
        else 
            animator.SetBool("isJumping", false);

    }
}
