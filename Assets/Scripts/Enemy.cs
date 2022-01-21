using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed = 0.2f;

    int direction = 1; //used for changing direction later
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Vector3.left * Time.deltaTime * speed; //constantly moving in one direction


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            transform.Rotate(0, 180, 0);
            direction = -direction;
        }
    }
}
