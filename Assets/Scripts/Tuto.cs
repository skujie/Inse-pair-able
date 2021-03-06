using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuto : MonoBehaviour
{
    public int currentTutoStepIndex = 0;

    [System.Serializable]
    public class TutoStep
    {
        public List<GameObject> gOToActive;
        public List<GameObject> gOToDeactive;
        public List<Animator> animToDeactive;
        public List<Button> buttonWhoNeedToBeTouch;
    }

    public List<TutoStep> allStep;

    public List<GameObject> toActivateIfSkip = new List<GameObject>();

    public void Skip()
    {
        TutoStep prev = null;
        if (currentTutoStepIndex >= 0)
            prev = allStep[currentTutoStepIndex];

        if (prev != null)
        {
            foreach (Button but in prev.buttonWhoNeedToBeTouch)
            {
                but.onClick.RemoveListener(Validate);
            }
            foreach (GameObject gO in prev.gOToDeactive)
            {
                gO.SetActive(false);
            }
        }

        foreach (GameObject gO in toActivateIfSkip)
        {
            gO.SetActive(true);
        }
    }

    public void Start()
    {
        foreach (TutoStep step in allStep)
        {
            foreach (GameObject gO in step.gOToActive)
                gO.SetActive(false);
        }
    }

    public void StartTuto()
    {
        currentTutoStepIndex = -1;
        ChooseNextStep();
    }

    public void ChooseNextStep()
    {

        TutoStep prev = null;
        if (currentTutoStepIndex >= 0)
            prev = allStep[currentTutoStepIndex];

        currentTutoStepIndex++;

        TutoStep next = null;
        if (currentTutoStepIndex < allStep.Count)
            next = allStep[currentTutoStepIndex];

        NextStep(prev, next);
    }


    public void NextStep(TutoStep previousStep, TutoStep nextStep)
    {
        if(previousStep != null)
        {
            foreach (Button but in previousStep.buttonWhoNeedToBeTouch)
            {
                but.onClick.RemoveListener(Validate);
            }
            foreach (Animator gO in previousStep.animToDeactive)
            {
                gO.SetBool("Visible", false);
            }
        }

        


        if (nextStep == null)
        {
            EndTutorial();
            return;
        }


        foreach (Button but in nextStep.buttonWhoNeedToBeTouch)
        {
            but.onClick.AddListener(Validate);
        }

        foreach (GameObject gO in nextStep.gOToActive)
        {
            gO.SetActive(true);
        }

    }

    public void Validate()
    {
        ChooseNextStep();
    }

    public void EndTutorial()
    {
        //nothing to do in particular ?

    }

    [Sirenix.OdinInspector.Button]

    public void Animator()
    {
        foreach (TutoStep step in allStep)
        {
            foreach (GameObject gO in step.gOToDeactive)
            {
                Animator anim = gO.GetComponentInChildren<Animator>();
                if (anim != null)
                    step.animToDeactive.Add(anim);
            }
        }
    }


}
