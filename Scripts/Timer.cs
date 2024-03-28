using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float timerValue;
    [SerializeField] float timeToShowQuestion = 30f;
    [SerializeField] float timeToShowAnswer = 10f;

    public float fillFraction;
    public bool isAnsweringQuestion = false;
    public bool loadNextQuestion = true;


    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    { 
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestion)
        {
            if (timerValue <= 0)
            {
                timerValue = timeToShowAnswer;
                isAnsweringQuestion = false;
            }
            else 
            { 
                fillFraction = timerValue / timeToShowQuestion;
            }
        }
        else 
        {
            if (timerValue <= 0)
            {
                timerValue = timeToShowQuestion;
                isAnsweringQuestion = true;
                loadNextQuestion = true;
            }
            else
            {
                fillFraction = timerValue / timeToShowAnswer;
            }
        }
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }
}
