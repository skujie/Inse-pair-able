using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Function_Game : MonoBehaviour
{
    #region Variables
    [Title("Objects")]
    [SerializeField] GameObject MainMenu;
    [SerializeField] AudioSource buttonSoundSource;
    public int arrayLength = 0;
    private Master_Game masterGame;
    [SerializeField] private Animator washing;
    
    [Title("Modifications")]
    [SerializeField] Image currentCandidate;
    [SerializeField] private Image preview;
    
    [SerializeField] private TextMeshProUGUI dialogTellMeMore;
    
    #endregion
    
    #region Methods

    private void Start()
    {
        masterGame = GetComponent<Master_Game>();
    }
    
    public void swipe()
    {
        arrayLength++;
        currentCandidate.enabled = false;
        //preview.enabled = false;
        masterGame.hideAnswer(false);
        if (arrayLength >= masterGame.levels[masterGame.currentLevel].Candidats.Count)
        {
            dialogTellMeMore.text = masterGame.levels[masterGame.currentLevel].noMatchText;
        }
        else
        {
            washing.SetTrigger("Wash");
        }
        
    }

    public void match()
    {
        
    }

    public void TellMeMore()
    {
        dialogTellMeMore.text = masterGame.levels[masterGame.currentLevel].tellME();
    }

    #endregion
    
    #region internMethods
    public void setNextCandidate()
    {
        currentCandidate.enabled = true;
        masterGame.hideAnswer(true);
        if (arrayLength < masterGame.levels[masterGame.currentLevel].Candidats.Count-1) //One preview left
        {
            //preview.enabled = true;
            preview.sprite = masterGame.levels[masterGame.currentLevel].Candidats[arrayLength+1].chaussette.sock;
        }
        else
        {
            //preview.enabled = false;
        }
        currentCandidate.sprite = masterGame.levels[masterGame.currentLevel].Candidats[arrayLength].chaussette.sock;
        masterGame.IntroSpeech();
    }
    
    #endregion
}
