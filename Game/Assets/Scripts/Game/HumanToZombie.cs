using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanToZombie : MonoBehaviour
{
    private SpriteRenderer spriteCharacter;

    private void Start()
    {
        spriteCharacter = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            spriteCharacter.sprite = Resources.Load<Sprite>("Sprites/Characters/zombie_stand");
        }
    }
}
