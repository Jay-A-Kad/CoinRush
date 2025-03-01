using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 30f;
    public TMP_Text timerText;
    private bool timerIsRunning = false;

    public GameObject loserPanel;

    void Start()
    {
        timerIsRunning = true;

        if (loserPanel)
        {
            loserPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                Debug.Log("Time Run Out");

                CheckGameOver();
            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(timeToDisplay, 0);
        int seconds = Mathf.FloorToInt(timeToDisplay);
        timerText.text = seconds.ToString();
    }

    void CheckGameOver()
    {
        if (CoinBehavior.coins < 10)
        {
            if (loserPanel)
            {
                loserPanel.SetActive(true);
                Debug.Log("Player loose womp womp!");
            }
        }
    }
}
