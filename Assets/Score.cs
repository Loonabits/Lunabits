using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float timeOverlap = 0;
    public bool timerIsRunning = false;
    public Text scoreText;
    public float score = 0;
    public int Extra = 0;
    public int multiplier = 2;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if(timerIsRunning == true)
        {
            timeOverlap += Time.deltaTime;
            Debug.Log(timeOverlap);
            //to detect if coin got pickup
            float minutes = Mathf.FloorToInt(timeOverlap / 10);
            if (minutes == 1)
            {
                Extra += 1000;
            }
            DisplayScore(timeOverlap);
        }
    }

    void DisplayScore(float timeToDisplay)
    {
        score = Extra + timeToDisplay*10*multiplier;
        scoreText.text = score.ToString("0");
    }
}
