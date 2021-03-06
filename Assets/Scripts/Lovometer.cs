using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lovometer : MonoBehaviour
{
    private int coeff;
    public float fill;

    [SerializeField]private Master_Game _master;
    [SerializeField]private Function_Game _game;
    private Image image;

    [Title("Match")] 
    [SerializeField] private Animator canv;

    [SerializeField] private GameObject aiguille;

    [SerializeField] private Image matchFill;
    [SerializeField] private Image sock;
    [SerializeField] private Image candid;

    [SerializeField] private TextMeshProUGUI dialog;

    private void Start()
    {
        coeff = _master.levels.Count*100;
        image = transform.GetChild(0).GetComponent<Image>();
    }

    private void Update()
    {
        image.fillAmount = fill / coeff;
    }

    public void Matched()
    {
        matchFill.fillAmount = (float)_master.levels[_master.currentLevel].Candidats[_game.arrayLength].love/100;
        canv.SetTrigger("Open");

        sock.sprite = _master.levels[_master.currentLevel].sock;
        candid.sprite = _master.levels[_master.currentLevel].Candidats[_game.arrayLength].chaussette.sock;
        
        aiguille.transform.rotation = Quaternion.Euler(0,0,90-(_master.levels[_master.currentLevel].Candidats[_game.arrayLength].love*1.8f));

        dialog.text = _master.levels[_master.currentLevel].Candidats[_game.arrayLength].matchText;
    }

    public void NextLevel()
    {
        if(_master.currentLevel < _master.levels.Count-1)
            _master.StartLevel(_master.currentLevel+1);
        else
            Application.Quit();
    }
}
