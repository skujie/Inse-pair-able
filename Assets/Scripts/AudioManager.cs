using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicIntro;
    public AudioSource musicLoop;

    // Start is called before the first frame update
    void Start()
    {
        musicIntro.Play();
        StartCoroutine(PlayLoop());
    }

    IEnumerator PlayLoop()
    {

        yield return new WaitWhile(() => musicIntro.isPlaying);
        Debug.Log("Now");
        musicLoop.loop = true;
        musicLoop.Play();
    }


}
