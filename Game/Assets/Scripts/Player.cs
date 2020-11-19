using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    // Start is called before the first frame update


    // Model
    private Rigidbody2D rb;
    private CapsuleCollider2D Collider;

    // Jump
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;

    // Mouvement
    private bool canMove = true;

    // Animation
    private Animator playerAnimator;

    // Score
    public Text scoreText;
    private float scoreAmount = 0f;
    private float pointIncreasedPerSecond = 20f;

    // Time
    public Text timeText;
    private float timeLeft = 30f;

    // Canvas
    public GameObject gameOverCanvas;
    public GameObject HUDCanvas;

    // Gameover
    private bool isGameOver = false;
    private string reasonOfDeath = "";
    public Text historyText;
    public Text scoreDeadText;
    public Text gameOverText;

    // Triger Enter
    private float bonusScore = 1000f;
    private float bonusTime = 10f;
    private float malusTime = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Collider = GetComponent<CapsuleCollider2D>();
        playerAnimator = GetComponent<Animator>();
        timeText.text = Mathf.Round(timeLeft) + "";
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            // Run and Jump
            if (canMove)
            {
                //rb.velocity = new Vector2(5, rb.velocity.y);
                rb.AddForce(transform.right * 5);
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, 8);
                onGround = Physics2D.IsTouchingLayers(Collider, whatIsGround);
                if (Input.GetKey(KeyCode.Space) && onGround)
                {
                    //Debug.Log("Space");
                    rb.velocity = new Vector2(rb.velocity.x, 6);
                }

                
                    
            }



            // Animation 
            playerAnimator.SetBool("Grounded", onGround);


            //Score and Time
            if (timeLeft <= 0)
            {
                reasonOfDeath = "Temps Ecoulé";
                GameOver();
                canMove = false;
            }
            else if (transform.position.y < -10)
            {
                reasonOfDeath = "Mort";
                GameOver();
            }
            else
            {
                Score();
                DecreaseTime();
            }
        }
        
    }

    // Function to show the score
    private void Score()
    {
        scoreText.text = "Score : " + (int)scoreAmount;
        scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
    }

    // Function to decrease the time
    private void DecreaseTime()
    {
        timeLeft -= Time.deltaTime;
        timeText.text = "Temps : " + Mathf.Round(timeLeft);
    }

    // Function Game over to change canvas
    public void GameOver()
    {
        Time.timeScale = 0;
        scoreDeadText.text = "Score : " + (int)scoreAmount;
        historyText.text = "Ceci est un cours d'histoire.";
        gameOverText.text = reasonOfDeath;
        gameOverCanvas.SetActive(true);
        HUDCanvas.SetActive(false);
        isGameOver = true;

    }

    // Function Replay to reload the scene
    public void Replay()
    {
        SceneManager.LoadScene("Game");
    }


    // Function for all collider enter
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bonus Score")
        {
            scoreAmount += bonusScore;
        }

        if (col.tag == "Bonus Time")
        {
            timeLeft += bonusTime;
        }

        if (col.tag == "Malus Time")
        {
            timeLeft -= malusTime;
        }

        if (col.tag == "Dead")
        {
            reasonOfDeath = "Mort";
            GameOver();
        }

        if (col.tag == "Human")
        {
            scoreAmount += bonusScore;
            timeLeft += bonusTime;
        }


        Destroy(col.gameObject);
    }


    //Function when the player is dead
    

}


