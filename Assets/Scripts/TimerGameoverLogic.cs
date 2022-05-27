using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimerGameoverLogic : MonoBehaviour
{
    public int countDownStartValue = 60;
    public Text timerUI;
    public GameManager GameManager;
    public GameObject GameObject;
    public Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        countDownTimer();
    }

    public void countDownTimer()
    {
        if(countDownStartValue > 0)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(countDownStartValue);
            timerUI.text = "Timer: " + timeSpan.Minutes + ":" + timeSpan.Seconds;  
            Debug.Log("Timer :" + countDownStartValue);
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);
        }
        else
        {
            Destroy(ball);
            Time.timeScale = 0;
            GameManager.GameOver();
            Debug.Log("GameOver");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
