using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

[CreateAssetMenu(fileName = "Candidat", menuName = "ScriptableObjects/Candidat", order = 1)]
public class Candidat : SerializedScriptableObject
{
    #region variables
    [Title("Needed components")]
    [SerializeField] public Questions refQuestions;

    [SerializeField] public Sprite sock;

    [Title("Texts")]
    
    [SerializeField, TextArea] public string introSpeech;
    
    [SerializeField, TextArea] public string matchReaction;

    [ShowInInspector, OdinSerialize, ListDrawerSettings(CustomAddFunction = "addAnswer", ShowIndexLabels = true)]
    public List<answer> Answers = new List<answer>();
    
    #endregion
    
    #region Methods
    void addAnswer()
    {
        List<answer> tempAnswers = Answers;

        if (refQuestions.questions.Count > Answers.Count)
        {
            answer newAns = new answer();
            newAns.question = refQuestions.questions[Answers.Count];
            tempAnswers.Add(newAns);
            Answers = tempAnswers;
        }
        else
        {
            answer newAns = new answer();
            Answers.Add(newAns);
        }
    }

    public string reponse(string question)
    {
        return Answers[refQuestions.questions.IndexOf(question)].answerText;
    }

    #endregion
}

#region Structs
[Serializable]
public struct answer
{
    [DisplayAsString] public string question;
    [TextArea] public string answerText;
}
#endregion