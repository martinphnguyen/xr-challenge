using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevel : MonoBehaviour
{

    public GameObject star;
    public GameObject floor;
    public GameObject wall;
    public GameObject finishZone;


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

        GameObject.Instantiate(floor, new Vector3(0, 0, 0), Quaternion.identity);

        GameObject.Instantiate(star, new Vector3(0, 0, 13), Quaternion.identity);
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
