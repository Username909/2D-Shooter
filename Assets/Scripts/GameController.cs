using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameController : MonoBehaviour
{
    public GameObject Player;
    [Header("Wave Setting")]
    public GameObject hazard;   // Determines spawns
    public Vector2 spawn;       // Where to spawn hazards
    public int hazardcount;     // How many hazards per wave
    public float startwait;     // How long until first wave
    public float spawnwait;     // The wait between each hazard in each wave
    public float wavewait;      // How long between each wave

    [Header("UI Settings")] // used to manipulate the texts
    public Text scoreLabel; 
    public Text livesLabel;
    public Text GameOverLabel;
    public Text RestartLabel;

    private int score;
    private int lives;
    private bool gameOver;
    private bool restart;

    public int Lives
    {
        get
        {
            return lives;
        }

        set
        {
            lives = value;  
            //finds if the player has no lives and show it 
            if (lives < 1)
            {
                Destroy(Player);
                restart = true;
                livesLabel.text = "Lives: " + lives.ToString();
            }
            else
            {
                livesLabel.text = "Lives: " + lives.ToString();
            }

        }
    }

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;

            // show the players score
            scoreLabel.text = "Score: " + score.ToString();
        }
    }

    // Use this for initialization
    void Start()
    {
        score = 0;
        lives = 5;
        StartCoroutine(spawnwaves());
        gameOver = false;
        restart = false;
        RestartLabel.enabled = false;
        GameOverLabel.enabled = false;
    }

    void Update()
    {
        //Check if your restarting
        if (restart == true)
        {
            GameOverLabel.enabled = true; // turns on the game over and restart texts
            RestartLabel.enabled = true;
            if (Input.GetKeyDown(KeyCode.R))
            {
                //Reloads the scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    IEnumerator spawnwaves()
    {
        yield return new WaitForSeconds(startwait);
        while (true)
        {
            // Spawning our hazards
            for (int i = 0; i < hazardcount; i++)
            {
                Vector2 spawnPosition = new Vector2(spawn.x, Random.Range(-spawn.y, spawn.y));
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnwait);
            }
            yield return new WaitForSeconds(wavewait);

            //Restart logic
            if (gameOver == true)
            {
                restart = true;
                break;
            }
        }
    }
}