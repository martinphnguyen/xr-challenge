using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * speed;
    }
}
