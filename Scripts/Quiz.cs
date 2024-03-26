using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Quiz : MonoBehaviour
{
    [SerializeField] QuestionSO question;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] GameObject[] answerButtons;

    int correctAnswerIndex;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Sprite defaultAnswerSprite;

    Timer timer;
    [SerializeField] Image timerImage;

    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        GetNextQuestion();
    }

    void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
    }

    public void OnAnswerSelected(int index)
    {
        correctAnswerIndex = question.GetCorrectAnswerIndex();
        if (index == correctAnswerIndex)
        {
            questionText.text = "Correct!";

            Image buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            questionText.text = "Wrong! The correct answer was "
                                + question.GetAnswer(correctAnswerIndex) 
                                + ".";

            Image buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }

        SetButtonState(false);
    }

    void SetButtonState(bool state) 
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[0].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprite()
    { 
        for (int i = 0; i < answerButtons.Length; ++i) 
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }

    void GetNextQuestion()
    {
        SetButtonState(true);
        DisplayQuestion();
        SetDefaultButtonSprite();

        
    }
}
