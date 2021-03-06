using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationOffset : MonoBehaviour
{
    public float offset = 0.1f;
    public bool offsetFirst = false;

    public List<GameObject> gameObjectsToActiveInOrder = new List<GameObject>();

    private void Awake()
    {
        StartCoroutine(LaunchActivationInRow());
    }

    public IEnumerator LaunchActivationInRow()
    {

        foreach (GameObject obj in gameObjectsToActiveInOrder)
        {
            obj.SetActive(false);
        }
        if (offsetFirst)
            yield return new WaitForSeconds(offset);

        foreach (GameObject obj in gameObjectsToActiveInOrder)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(offset);
        }
    }

}
