using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public List<GameObject> Background = new List<GameObject>();
    public static bool isReachedEnd = false;

    void Start()
    {
        Background[0].SetActive(true);
        Background[1].SetActive(false);

        if(isReachedEnd)
        {
            Background[0].SetActive(false);
            Background[1].SetActive(true);
        }
    }

}
