using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    // Declares the boundary that the player cannot cross
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{


    // Determines the player movement speed
    [Header("Movement Settings")]
    public float speed = 12.0f;
    public Boundary boundary;

    // Determines the settings for the players bullets and how often it can fire
    [Header("Attack Settings")]
    public GameObject bullet;
    public GameObject bulletSpawn;
    public float fireRate = 0.5f;
    private Rigidbody2D rBody;

    private float myTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //  Determines how fast the player can shoot
        myTime += Time.deltaTime;
        if (Input.GetButton("Fire1") && myTime > fireRate)
        {
            Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            myTime = 0.0f;
        }
    }

    void FixedUpdate()
    {
        // Reads input
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horiz, vert);

        //Moves the Player
        rBody.velocity = movement * speed;

        //Restricts the player from leaving the play area
        rBody.position = new Vector2(
            Mathf.Clamp(rBody.position.x, boundary.xMin, boundary.xMax), // Restricts on the X postition to xMin and xMax
            Mathf.Clamp(rBody.position.y, boundary.yMin, boundary.yMax)); // Restricts on the Y postition to yMin and yMax
    }
}
