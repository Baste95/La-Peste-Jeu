using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D rb;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    private Animator playerAnimator;
    private CapsuleCollider2D Collider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Collider = GetComponent<CapsuleCollider2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(5, rb.velocity.y);
        onGround = Physics2D.IsTouchingLayers(Collider, whatIsGround);
        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            //Debug.Log("Space");
            rb.velocity = new Vector2(rb.velocity.x, 6);
        }

        playerAnimator.SetBool("Grounded", onGround);
    }
}
