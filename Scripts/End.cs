using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class End : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreKeeper scoreKeeper;

    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        ShowFinalScore();
    }

    void ShowFinalScore()
    {
        finalScoreText.text = "Congratulations!\n" +
                              "You scored " + scoreKeeper.CalculateScore() +
                              "%";
    }
}
