using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextMap : MonoBehaviour
{
    FadeInOut fade;
    
    private void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }

    public IEnumerator ChangeScene()
    {
        //Debug.Log(MapSequenceInitializer.location);
        //Debug.Log("current Act location: " + moveset.ActLocation);
        fade.FadeIn();
        yield return new WaitForSeconds(1);

        if (moveset.ActLocation == 0) SceneManager.LoadScene(1);

        if (MapSequenceInitializer.NagasLairEntry) SceneManager.LoadScene(20);

        if (moveset.ActLocation == 3 || MapSequenceInitializer.entryToAct3 == true)
        {
            if (MapSequenceInitializer.NagasLairEntry == false)
            {
                SceneManager.LoadScene(19);
                //MapSequenceInitializer.NagasLairEntry = true;
            }
        }

        else if (moveset.ActLocation == 1 && moveset.ActLocation != 2)
        {
            MapSequenceInitializer.location++;
            MapSequenceInitializer.counterToAct1End++;
            if (MapSequenceInitializer.counterToAct1End == 7)
            {
                MapSequenceInitializer.entryToAct2 = true;
                moveset.ActLocation = 2;
                SceneManager.LoadScene(18);
            }
            else
            {
                if (moveset.ActLocation == 1)
                    SceneManager.LoadScene(MapSequenceInitializer.mapsequence[MapSequenceInitializer.location]);
            }

        }

        else if (moveset.ActLocation == 2 && moveset.ActLocation != 3)
        {
            MapSequenceInitializer.act2Location++;
            MapSequenceInitializer.counterToAct2End++;
            if (MapSequenceInitializer.counterToAct2End == 4)
            {
                //Debug.Log(MapSequenceInitializer.entryToAct3);
                MapSequenceInitializer.entryToAct3 = true;
                moveset.ActLocation = 3;
                SceneManager.LoadScene(8);
                //Debug.Log(moveset.ActLocation);
            }
            else
            {
                if (moveset.ActLocation == 2)
                    SceneManager.LoadScene(MapSequenceInitializer.mapsequence2[MapSequenceInitializer.act2Location]);
            }
        }

        //Debug.Log(MapSequenceInitializer.location);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ChangeScene());
        }
    }
}
/*
         else if (moveset.ActLocation == 1 && moveset.ActLocation != 2)
        {
            MapSequenceInitializer.act2Location++;
            MapSequenceInitializer.counterToAct2End++;
            if (MapSequenceInitializer.counterToAct2End == 7)
            {
                Debug.Log(MapSequenceInitializer.entryToAct3);
                MapSequenceInitializer.entryToAct3 = true;
                moveset.ActLocation = 3;
                SceneManager.LoadScene(18);
                Debug.Log(moveset.ActLocation);
            }
            else
            {
                if (moveset.ActLocation == 2)
                SceneManager.LoadScene(MapSequenceInitializer.mapsequence2[MapSequenceInitializer.act2Location]);
            }

        }

        else if (moveset.ActLocation == 2 && moveset.ActLocation != 3)
        {
            MapSequenceInitializer.location++;
            MapSequenceInitializer.counterToAct1End++;
            if (MapSequenceInitializer.counterToAct1End == 4)
            {
                MapSequenceInitializer.entryToAct2 = true;
                moveset.ActLocation = 2;
                SceneManager.LoadScene(8);
            }
            else
            {
                if (moveset.ActLocation == 1)
                SceneManager.LoadScene(MapSequenceInitializer.mapsequence[MapSequenceInitializer.location]);
            }
        }
 */