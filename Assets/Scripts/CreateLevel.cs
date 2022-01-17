using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevel : MonoBehaviour
{

    public GameObject star;
    public GameObject floor;
    public GameObject wall;
   // public GameObject obstacle;


    int width;
    int depth;
    // Start is called before the first frame update
    void Start()
    {
             
    }

    private void Awake()
    {
        //using Awake so all objects have spawned before trying to access them
        //create basic floor and outer walls
        GameObject.Instantiate(floor, new Vector3(0, 0, 0), Quaternion.identity); //floor origin

        GameObject.Instantiate(wall, new Vector3(0, 0, 5), Quaternion.identity); //front
        GameObject.Instantiate(wall, new Vector3(0, 0, -5), Quaternion.identity); //back
        GameObject.Instantiate(wall, new Vector3(5, 0, 0), Quaternion.Euler(0, 90, 0)); //side
        GameObject.Instantiate(wall, new Vector3(-5, 0, 0), Quaternion.Euler(0, 90, 0)); //side

        GameObject.Instantiate(star, new Vector3(0, 0, 2), Quaternion.identity);
        GameObject.Instantiate(star, new Vector3(2, 0, 1), Quaternion.identity);
        GameObject.Instantiate(star, new Vector3(-2, 0, 1), Quaternion.identity);
        GameObject.Instantiate(star, new Vector3(-2, 0, 2), Quaternion.identity);
        GameObject.Instantiate(star, new Vector3(0, 0, -2), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
