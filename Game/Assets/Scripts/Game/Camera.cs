using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    //public Rigidbody2D rb;
    public Transform player;
    public Player playerScript;

    public Material skybox1;
    public Material skybox2;
    public Material skybox3;
    public Material skybox4;
    public Material skybox5;
    public Material skybox6;
    public Material skybox7;
    

    // GameObject player;

    void Start()
    {
       // rb = GetComponent<Rigidbody2D>();
        RenderSettings.skybox = skybox1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((player.position.x + 12), 7, transform.position.z);
        // player = GameObject.FindWithTag("Player");
        if(playerScript.scoreAmount >= 20000){
            RenderSettings.skybox = skybox2;
        }
       /* if (playerScript.scoreAmount >= 5000 && playerScript.scoreAmount < 10000)
        {
            RenderSettings.skybox = skybox2;
        }
        if(playerScript.scoreAmount >= 10000 && playerScript.scoreAmount < 15000){
            RenderSettings.skybox = skybox3;
        }
        if(playerScript.scoreAmount >= 15000 && playerScript.scoreAmount < 20000){
            RenderSettings.skybox = skybox4;
        }
        if(playerScript.scoreAmount >= 20000 && playerScript.scoreAmount < 25000){
            RenderSettings.skybox = skybox5;
        }
        if(playerScript.scoreAmount >= 25000 && playerScript.scoreAmount < 30000){
            RenderSettings.skybox = skybox6;
        }
        if(playerScript.scoreAmount >= 30000 && playerScript.scoreAmount < 35000){
            RenderSettings.skybox = skybox7;
        }*/
    }
}
