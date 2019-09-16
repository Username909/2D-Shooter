using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Tells the bullet where to go and how fast
    //Variable Declaration
    [Header("Bullet Speed")]
    public float speed;

    // Use this for initialization
    void Start()
    {
        Rigidbody2D rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
