using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function_Pause : MonoBehaviour
{
    public GameObject Game;
    public GameObject MainMenu;
    public AudioSource buttonSoundSource;


    public void pause()
    {
        buttonSoundSource.Play();
        Game.SetActive(false);
        gameObject.SetActive(true);
    }

    public void unPause()
    {
        buttonSoundSource.Play();
        gameObject.SetActive(false);
        Game.SetActive(true);
    }

    public void leaveGame()
    {
        buttonSoundSource.Play();
        gameObject.SetActive(false);
        MainMenu.SetActive(true);
    }
}
