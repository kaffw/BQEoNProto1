using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneDisabler : MonoBehaviour
{
    public GameObject disableCutscene;

    void Start()
    {
        Destroy(gameObject, 7f);
    }

}
/*
 timer += Time.deltaTime;
        if (timer > 6f)
        {
            disableCutscene.SetActive(false);
        }
 */