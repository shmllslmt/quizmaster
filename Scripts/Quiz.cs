using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] List<QuestionSO> questionList = new List<QuestionSO>();
    QuestionSO question;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] GameObject[] answerButtons;

    int correctAnswerIndex;
    bool hasAnsweredEarly = true;
    bool isComplete = false;

    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Sprite defaultAnswerSprite;

    Timer timer;
    [SerializeField] Image timerImage;

    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [SerializeField] Slider progressSlider;
    

    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

        progressSlider.minValue = 0;
        progressSlider.maxValue = questionList.Count;
        progressSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;

        if (timer.loadNextQuestion)
        {
            if (progressSlider.value == progressSlider.maxValue)
            {
                isComplete = true;
                return;
            }

            GetNextQuestion();
            hasAnsweredEarly = false;
            timer.loadNextQuestion = false;
        }
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
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
        if (questionList.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprite();
            GetRandomQuestion();
            DisplayQuestion();

            scoreKeeper.IncrementQuestionComplete();
            progressSlider.value++;
        }
    }

    void GetRandomQuestion()
    {
        int randomIndex = Random.Range(0, questionList.Count);
        question = questionList[randomIndex];

        if (questionList.Contains(question))
        {
            questionList.RemoveAt(randomIndex);
        }
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

    public void OnAnswerSelected(int index)
    {        
        hasAnsweredEarly = true;
        DisplayAnswer(index);

        SetButtonState(false);
        timer.CancelTimer();

        scoreText.text = "Score: " + scoreKeeper.CalculateScore() + "%";
    }

    void DisplayAnswer(int index)
    {
        correctAnswerIndex = question.GetCorrectAnswerIndex();
        if (index == correctAnswerIndex)
        {
            questionText.text = "Correct!";

            Image buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;

            scoreKeeper.IncrementCorrectAnswer();
        }
        else
        {
            questionText.text = "Wrong! The correct answer was "
                                + question.GetAnswer(correctAnswerIndex)
                                + ".";

            Image buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }
}
