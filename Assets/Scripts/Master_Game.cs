using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Master_Game : MonoBehaviour
{
    private Function_Game _game;
    
    [Title("Chaussettes à caser (scénarios)")]
    [SerializeField] public List<Chaussette_Parameters> levels;
    [HideInInspector] public int currentLevel;

    [Title("Elements to change")] 
    [Header("Images")]
    [SerializeField] private Image sockFrame;
    [SerializeField] private Image candidateFrame;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI tellMe;

    [SerializeField] private TextMeshProUGUI question_1;
    [SerializeField] private TextMeshProUGUI question_2;

    [SerializeField] private TextMeshProUGUI answer;
    
    private string firstQuest;
    private string secondQuest;

    private void Start()
    {
        _game = GetComponent<Function_Game>();
    }

    public void StartLevel(int levelIndex)
    {
        currentLevel = levelIndex; //Save level index
        
        sockFrame.sprite = levels[currentLevel].sock; //Set the waiting sock's sprite

        candidateFrame.enabled = true; //Enable candidate
        candidateFrame.sprite = levels[currentLevel].Candidats[0].chaussette.sock; //Set correct sprite
        
        tellMe.text = levels[levelIndex].tellME(); //set a first TellMeMore
        
        #region set_questions
        firstQuest = levels[levelIndex].Candidats[0].chaussette.refQuestions.randQuestion();
        question_1.text = firstQuest; //Set questions
        
        secondQuest = levels[levelIndex].Candidats[0].chaussette.refQuestions.randQuestion();
        question_2.text = secondQuest;
        #endregion

        IntroSpeech();

        SetPreferences();
    }

    
    public void askQuestion(int numb)
    {
        if (numb == 1)
        {
            answer.text = levels[currentLevel].Candidats[_game.arrayLength].chaussette.reponse(firstQuest);
            
            firstQuest = levels[currentLevel].Candidats[_game.arrayLength].chaussette.refQuestions.randQuestion();
            question_1.text = firstQuest; //Set questions
        }
        if (numb == 2)
        {
            answer.text = levels[currentLevel].Candidats[_game.arrayLength].chaussette.reponse(secondQuest);
            
            secondQuest = levels[currentLevel].Candidats[_game.arrayLength].chaussette.refQuestions.randQuestion();
            question_2.text = secondQuest;
        }
    }

    public void IntroSpeech()
    {
        if (_game == null) _game = GetComponent<Function_Game>();
        answer.text = levels[currentLevel].Candidats[_game.arrayLength].chaussette.introSpeech;
    }

    public void hideAnswer(bool set)
    {
        answer.transform.parent.gameObject.SetActive(set);
    }

    [Title("Prefs")]
    [SerializeField] private List<GameObject> prefabs;

    [SerializeField] private List<Transform> shelves;
    
    public void SetPreferences()
    {
        for (int i = 0; i < levels[currentLevel].preferences.Count; i++)
        {
            shelves[i].GetChild(1).GetComponent<TextMeshProUGUI>().text = levels[currentLevel].preferences.Keys.ToList()[i]; //text

            if (levels[currentLevel].preferences.Values.ToList()[i] == 0)
            {
                Instantiate(prefabs[1], shelves[i].GetChild(0));
            }
            else
            {
               for (int j = 0; j < Mathf.Abs(levels[currentLevel].preferences.Values.ToList()[i]); j++)
               {
                   Debug.Log(levels[currentLevel].preferences.Values.ToList()[i]);
                   if (levels[currentLevel].preferences.Values.ToList()[i] < 0)
                   {
                       Instantiate(prefabs[0], shelves[i].GetChild(0));
                   }

                   if (levels[currentLevel].preferences.Values.ToList()[i] > 0)
                   {
                       Instantiate(prefabs[2], shelves[i].GetChild(0));
                   }
               } 
            }
        }
    }
}
