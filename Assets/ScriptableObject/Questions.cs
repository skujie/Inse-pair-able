using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

[CreateAssetMenu(fileName = "Questions", menuName = "ScriptableObjects/Questions", order = 1)]
public class Questions : SerializedScriptableObject
{
    public List<string> questions;

    private List<string> usedQuestions;
    

    public string randQuestion()
    {
        if (usedQuestions.Count != questions.Count)
        {
            int rand = Random.Range(0, questions.Count);
            while (usedQuestions.Contains(questions[rand]))
            {
                rand = Random.Range(0, questions.Count);
            }

            usedQuestions.Add(questions[rand]);
            return questions[rand];
        }
        else
        {
            usedQuestions.Clear();
            return randQuestion();
        }
    }
}
