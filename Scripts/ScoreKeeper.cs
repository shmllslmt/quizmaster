using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswer;
    int questionComplete;

    public int GetCorrectAnswer()
    { 
        return correctAnswer;
    }

    public int GetQuestionComplete()
    { 
        return questionComplete;
    }

    public void IncrementCorrectAnswer()
    { 
        correctAnswer++;
    }

    public void IncrementQuestionComplete()
    { 
        questionComplete++;
    }

    public int CalculateScore()
    { 
        return Mathf.RoundToInt(correctAnswer / (float)questionComplete * 100); // 2/5
    }
}
