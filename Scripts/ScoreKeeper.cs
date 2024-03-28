using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswer;
    int questionComplete;

    int GetCorrectAnswer()
    { 
        return correctAnswer;
    }

    int GetQuestionComplete()
    { 
        return questionComplete;
    }

    void IncrementCorrectAnswer()
    { 
        correctAnswer++;
    }

    void IncrementQuestionComplete()
    { 
        questionComplete++;
    }

    int CalculateScore()
    { 
        return Mathf.RoundToInt(correctAnswer / (float)questionComplete * 100); // 2/5
    }
}
