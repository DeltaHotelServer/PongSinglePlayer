using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimerGameoverLogic : MonoBehaviour
{
    public int countDownStartValue;
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
        if (countDownStartValue > 0)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(countDownStartValue);
<<<<<<< Updated upstream:Assets/Scripts/TimerGameoverLogic.cs
            timerUI.text = "Timer: " + timeSpan.Minutes + ":" + timeSpan.Seconds;  
            Debug.Log("Timer :" + countDownStartValue);
=======
            timerUI.text = "Timer: " + timeSpan.Minutes + ":" + timeSpan.Seconds;
            //Debug.Log("Timer :" + countDownStartValue);
>>>>>>> Stashed changes:Assets/Scripts/Manager/TimerGameoverLogic.cs
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);
        }
        else
        {
            Time.timeScale = 0;
            GameManager.GameOver();
            Debug.Log("GameOver");
        }
    }
}
