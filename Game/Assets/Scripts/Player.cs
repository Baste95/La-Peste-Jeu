using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update


    // Model
    public Rigidbody2D rb;
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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Collider = GetComponent<CapsuleCollider2D>();
        playerAnimator = GetComponent<Animator>();
        timeText.text = Mathf.Round(timeLeft) + "";
    }

    // Update is called once per frame
    void Update()
    {

        // Run and Jump
        if (canMove)
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
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
        if(timeLeft <= 0)
        {
            canMove = false;
        }
        else
        {
            Score();
            DecreaseTime();
        }
        
    }

    private void Score()
    {
        scoreText.text = (int)scoreAmount + "";
        scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
    }

    private void DecreaseTime()
    {
        timeLeft -= Time.deltaTime;
        timeText.text = Mathf.Round(timeLeft) + "";
    }
}


