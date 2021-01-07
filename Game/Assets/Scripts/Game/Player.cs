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
    private BoxCollider2D ColliderGround;

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
    public float scoreAmount = 0f;
    private float pointIncreasedPerSecond = 20f;

    // Time
    public Text timeText;
    private float timeLeft = 30f;

    // Canvas
    public GameObject gameOverCanvas;
    public GameObject HUDCanvas;

    // Gameover
    public bool isGameOver = true;
    private string reasonOfDeath = "";
    public Text historyText;
    public Text scoreDeadText;
    public Text gameOverText;

    // Triger Enter
    private float bonusScore = 500f;
    private float bonusTime = 5f;
    private float malusTime = 15f;

    // Audio Clip
    public GameObject soundEffectsGO;
    private AudioSource [] soundEffectsAS;
    private AudioSource bonusEffect;
    private AudioSource malusEffect;
    private AudioSource gameOverEffect;

    // Skybox
    // public Material skybox2;
    // public Material skybox3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Collider = GetComponent<CapsuleCollider2D>();
        ColliderGround = GetComponent<BoxCollider2D>();
        playerAnimator = GetComponent<Animator>();
        timeText.text = Mathf.Round(timeLeft) + "";
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1;
        soundEffectsAS = soundEffectsGO.GetComponents<AudioSource>();
        bonusEffect = soundEffectsAS[0];
        malusEffect = soundEffectsAS[1];
        gameOverEffect = soundEffectsAS[2];

    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            // Run and Jump
            if (canMove)
            {
                rb.AddForce(transform.right * 10);
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, 10);
                onGround = Physics2D.IsTouchingLayers(ColliderGround, whatIsGround);
                if (Input.GetKey(KeyCode.Space) && onGround)
                {
                    //Debug.Log("Space");
                    rb.velocity = new Vector2(rb.velocity.x, 6);
                }

                
                    
            }

            if (Input.GetKey(KeyCode.A))
            {
                scoreAmount += 1000;
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
        // switch ((int)scoreAmount)
        // {
        //     case 1000:
        //         RenderSettings.skybox = skybox2;
        //         break;
        // }
        
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
        gameOverEffect.Play();
        Time.timeScale = 0;
        scoreDeadText.text = "Score : " + (int)scoreAmount;
        chooseSentence();
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

    // Function MainMenu to return to the main menu when the game is over
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }


    // Function for all collider enter
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bonus Score")
        {
            scoreAmount += bonusScore;
            bonusEffect.Play();
            Destroy(col.gameObject);
        }

        if (col.tag == "Bonus Time")
        {
            timeLeft += bonusTime;
            bonusEffect.Play();
            Destroy(col.gameObject);
        }

        if (col.tag == "Bonus Time Score")
        {
            timeLeft += (bonusTime/2);
            scoreAmount += (bonusScore/2);
            bonusEffect.Play();
            Destroy(col.gameObject);
        }

        if (col.tag == "Malus Time")
        {
            timeLeft -= malusTime;
            malusEffect.Play();
            Destroy(col.gameObject);
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
            bonusEffect.Play();
        }


        
    }


    //Function to choose the right sentence at death / end of the game.
    void chooseSentence()
    {
        
        if (scoreAmount < 10000)
            historyText.text = "Le saviez-vous ? 202  c'est le nombre de mort par les épédimies à Madagascar.";

        else if(scoreAmount >= 10000 && scoreAmount < 20000)
            historyText.text = "Le saviez-vous ? Entre 1900 et 1904, il y a eu une épidémie de peste à San Francisco ayant fait une centaine de décès.";

        else if (scoreAmount >= 20000 && scoreAmount < 30000)
            historyText.text = "Le saviez-vous ? La peste de Marseille de 1720 a causé la perte de 30 à 50 000 habitants.";

        else if (scoreAmount >= 30000 && scoreAmount < 40000)
            historyText.text = "Le saviez-vous ? La peste d’Athènes est apparue en -430 avant Jésus-Christ à Athènes";

        else if (scoreAmount >= 40000 && scoreAmount < 50000)
            historyText.text = "Le saviez-vous ? La peste de 1665 à Londres fut dévastatrice avec environ 100 000 morts.";

        else if (scoreAmount >= 50000 && scoreAmount < 60000)
            historyText.text = "Le saviez-vous ? La peste Antonine à durer 23 ans de 166 jusqu’à 189, c’était l’une des origines de la chute de l’Empire Romain.";

        else if (scoreAmount >= 60000 && scoreAmount < 70000)
            historyText.text = "Le saviez-vous ? Durant la peste chinoise il y a eu 15 millions de morts entre 1855 date de la première épidémie et 1945 en chine lié à la peste.";

        else if (scoreAmount >= 70000 && scoreAmount < 80000)
            historyText.text = "Le saviez-vous ? La peste justinienne a frappé l’Empire Byzantin entre 541 et 542.";

        else if (scoreAmount >= 80000)
            historyText.text = "Le saviez-vous ? La peste noire a duré de 1347 à 1351 a totalement « dévasté l’Europe ».";
    }

    


}


