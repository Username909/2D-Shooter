using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoController : MonoBehaviour
{

    //Variable Declaration
    public float speed;

    // Use this for initialization
    void Start()
    {
        //moves the ufo left
        Rigidbody2D rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = -transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

