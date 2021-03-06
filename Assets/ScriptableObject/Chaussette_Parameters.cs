using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

[CreateAssetMenu(fileName = "Chaussette", menuName = "ScriptableObjects/Chaussette", order = 1)]
public class Chaussette_Parameters : SerializedScriptableObject
{
    #region variables
    
    [Title("Sock's parameters")] 
    [SerializeField] public string noMatchText;

    [SerializeField] public Sprite sock;
    
    [Title("Candidats")]
    [ShowInInspector, OdinSerialize, ListDrawerSettings(ShowIndexLabels = true)]
    public List<loveCandidate> Candidats;
    
    [Title("Dialogues")]
    [SerializeField] public List<string> tellMeMore = new List<string>();
    private List<string> used;
    
    [Title("Preferences")]
    [ShowInInspector, OdinSerialize, ListDrawerSettings(ShowIndexLabels = true)] 
    public Dictionary<string, int> preferences = new Dictionary<string, int>();
    #endregion

    #region Methods
    
    public string tellME()
    {
        if (used.Count < tellMeMore.Count)
        {
            int rand = UnityEngine.Random.Range(0, tellMeMore.Count);
            while (used.Contains(tellMeMore[rand]))
            {
                rand = UnityEngine.Random.Range(0, tellMeMore.Count);
            }

            used.Add(tellMeMore[rand]);
            return tellMeMore[rand];
        }
        else
        {
            used.Clear();
            return tellME();
        }
    }
    #endregion
}

#region Structs
[Serializable]
public struct loveCandidate
{
    public Candidat chaussette;
    [Range(0,100)]public int love;
    public string matchText;
}
#endregion


