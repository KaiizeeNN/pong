using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float timeLeft = 30f;
    public bool timerOn;

    public TMP_Text timerText;


    private void Start()
    {
        timerText.text = timeLeft.ToString();
        timerOn = true;
    }

    private void Update()
    {

        if (timerOn) 
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else
            {
                Debug.Log("Time is up!");
                timeLeft = 0;
                timerOn = false;
            }
        }

    }

    void updateTimer(float timer)
    {
        timer += 1;

        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

}
