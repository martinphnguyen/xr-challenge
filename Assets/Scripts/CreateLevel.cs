using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevel : MonoBehaviour
{

    public GameObject star;
    public GameObject floor;
    public GameObject wall;
    public GameObject finishZone;
    public GameObject alien;

    private Vector3 centre;
    private Vector3 radius;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    private void Awake()
    {
        //using Awake so all objects have spawned before trying to access them
        centre = new Vector3(0, 0, 13); //centre of our main floor
        radius = new Vector3(4, 2, 4);

        CreateLevel1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateLevel1()
    {
        //create basic floor and outer walls
        GameObject.Instantiate(floor, new Vector3(0, 0, 0), Quaternion.identity);

        //randomise number of stars and where they are placed
        int numberOfStars = Random.Range(5, 10);

        for(int i = numberOfStars; i > 0; i--)
        {
        Vector3 coor = centre + new Vector3(Random.Range(-radius.x, radius.x), 0, Random.Range(-radius.z, radius.z));
        GameObject.Instantiate(star, coor, Quaternion.identity);
        }    
        
        
        int numberOfEnemies = Random.Range(2, 5);
        for(int i = numberOfEnemies; i > 0; i--)
        {
        Vector3 coor = centre + new Vector3(Random.Range(-radius.x, radius.x), 0, Random.Range(-radius.z, radius.z));
        GameObject.Instantiate(alien, coor, Quaternion.Euler(0, -90, 0));
        }



    }

    void OnDrawGizmosSelected() //used to visualise the area of spawning
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(centre, radius * 2);
    }
}
