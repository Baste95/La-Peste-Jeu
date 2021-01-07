using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanToZombie : MonoBehaviour
{
    private SpriteRenderer spriteCharacter;

    // Animation
    private Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            playerAnimator.SetBool("Dead", true);
        }
    }
}
