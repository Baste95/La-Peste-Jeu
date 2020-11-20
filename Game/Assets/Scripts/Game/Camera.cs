using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    //public Rigidbody2D rb;
    public Transform player;
    void Start()
    {
       // rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((player.position.x + 12), 7, transform.position.z);
    }
}
