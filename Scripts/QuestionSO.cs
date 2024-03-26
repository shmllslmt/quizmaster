using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(minLines:2, maxLines:7)]
    [SerializeField] string question = "Have you eaten breakfast yet?";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex = 0;

    public string GetQuestion()
    { 
        return question;
    }

    public string GetAnswer(int index)
    { 
        return answers[index];
    }

    public int GetCorrectAnswerIndex()
    { 
        return correctAnswerIndex; 
    }
}
