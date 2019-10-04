using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestruction : MonoBehaviour
{

    public GameObject explosionAsteroid;

    private GameController gameController;
    // Use this for initialization
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    //detects of what the target is and runs code depending on what tag it has
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            gameController.Lives -= 1;
            Debug.Log(gameController.Lives);
            Instantiate(explosionAsteroid, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }

        if (other.tag == "Bullet")
        {
            gameController.Score += 100;
            Debug.Log(gameController.Score);
            Instantiate(explosionAsteroid, this.transform.position, this.transform.rotation);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

}
