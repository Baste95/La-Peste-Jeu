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
    public Material skybox8;
    public Material skybox9;


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
        if(playerScript.scoreAmount >= 10000 && playerScript.scoreAmount < 20000)
        {
            RenderSettings.skybox = skybox2;
        }
        if (playerScript.scoreAmount >= 20000 && playerScript.scoreAmount < 30000)
         {
             RenderSettings.skybox = skybox3;
         }
         if(playerScript.scoreAmount >= 30000 && playerScript.scoreAmount < 40000){
             RenderSettings.skybox = skybox4;
         }
         if(playerScript.scoreAmount >= 40000 && playerScript.scoreAmount < 50000){
             RenderSettings.skybox = skybox5;
         }
         if(playerScript.scoreAmount >= 50000 && playerScript.scoreAmount < 60000){
             RenderSettings.skybox = skybox6;
         }
         if(playerScript.scoreAmount >= 60000 && playerScript.scoreAmount < 70000){
             RenderSettings.skybox = skybox7;
         }
         if(playerScript.scoreAmount >= 70000 && playerScript.scoreAmount < 80000){
             RenderSettings.skybox = skybox8;
         }
        if (playerScript.scoreAmount >= 90000 )
        {
            RenderSettings.skybox = skybox9;
        }
    }
}
