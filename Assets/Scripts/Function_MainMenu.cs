using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function_MainMenu : MonoBehaviour
{
    public GameObject canvasOptions;
    public GameObject Game;
    public AudioSource buttonSoundSource;
    public Animator menuAnim;
    public CanvasGroup cavasGroup;

    public void Start()
    {
        menuAnim.SetBool("Visible", true);
        cavasGroup.interactable = true;
        cavasGroup.blocksRaycasts = true;
        gameObject.SetActive(true);
        Game.SetActive(true);
    }

    public void quit()
    {
        playSound();
        Application.Quit();    
    }

    public void play()
    {
        menuAnim.SetBool("Visible", false);
        cavasGroup.interactable = false;
        cavasGroup.blocksRaycasts = false;
        TransitionSmoothlyToGame();

            return;

        /*playSound();
        gameObject.SetActive(false);
        Game.SetActive(true);*/
    }

    public void option()
    {
        playSound();
        canvasOptions.SetActive(true);
        gameObject.SetActive(false);  
    }

    public void parameter() 
    {

    }

    public void TransitionSmoothlyToGame()
    {
        playSound();

        //Launch animation in
        foreach (UnityEngine.UI.Image im in imageToMakeDisappear)
            StartCoroutine(OpacityDown(im));
    }

    [Header("Transition setting")]
    public float transitionSpeed = 0.5f;
    public AnimationCurve transitionCurve;
    public List<UnityEngine.UI.Image> imageToMakeDisappear = new List<UnityEngine.UI.Image>();
    public Tuto tut;

    public IEnumerator OpacityDown(UnityEngine.UI.Image sR)
    {
        float startValue = sR.color.a;
        float lerp = 0;
        while(lerp < 1)
        {
            lerp += Time.deltaTime * transitionSpeed;
            if (lerp > 1) lerp = 1;
            Color col = sR.color;
            col.a = Mathf.Lerp(startValue, 0, transitionCurve.Evaluate(lerp));
            sR.color = col;
            yield return new WaitForSeconds(0.01f);
        }

        tut.StartTuto();
    }


    private void playSound()
    {
        Debug.Log("sa marche");
        buttonSoundSource.Play();
    }
}
