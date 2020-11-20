using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountBeforeGame : MonoBehaviour
{
    // Start is called before the first frame update
    // Time
    public Text countText;
    private float timeLeft = 3f;
    public GameObject scoreGO;
    public GameObject timeGO;
    public Player Player;

    void Start()
    {
        //Time.timeScale = 0;
        scoreGO.SetActive(false);
        timeGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft <= 0.5)
        {
            scoreGO.SetActive(true);
            timeGO.SetActive(true);
            Destroy(countText);
            Player.isGameOver = false;
            //Time.timeScale = 1;
            Destroy(this);
        }
        DecreaseTime();
    }

    private void DecreaseTime()
    {
        timeLeft -= Time.deltaTime;
        countText.text = Mathf.Round(timeLeft) + "";
    }
}
