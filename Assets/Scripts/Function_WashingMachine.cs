using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function_WashingMachine : MonoBehaviour
{
    private Function_Game game;
    private Master_Game master;

    private void Start()
    {
        game = GameObject.FindObjectOfType<Function_Game>();
        master = GameObject.FindObjectOfType<Master_Game>();
    }

    public void showNext()
    {
        game.setNextCandidate();
    }
}
