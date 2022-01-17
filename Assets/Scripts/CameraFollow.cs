using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x - 2.3f, player.transform.position.y + 4.0f, player.transform.position.z - 3); //can improvise with values to make it  
                                                                                                                                                  //look better if wanted
    }
}
