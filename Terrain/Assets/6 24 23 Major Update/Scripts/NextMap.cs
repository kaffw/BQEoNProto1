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
        Debug.Log("current Act location: " + moveset.ActLocation);
        fade.FadeIn();
        yield return new WaitForSeconds(1);

        if (moveset.ActLocation == 3 || MapSequenceInitializer.entryToAct3 == true)
        {
            SceneManager.LoadScene(19);
        }

        else if (moveset.ActLocation == 1 && moveset.ActLocation != 2)
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

        else if (moveset.ActLocation == 2 && moveset.ActLocation != 3)
        {
            MapSequenceInitializer.act2Location++;
            MapSequenceInitializer.counterToAct2End++;
            if (MapSequenceInitializer.counterToAct2End == 7)
            {
                MapSequenceInitializer.entryToAct3 = true;
                moveset.ActLocation = 3;
                SceneManager.LoadScene(18);
            }
            else
            {
                if (moveset.ActLocation == 2)
                SceneManager.LoadScene(MapSequenceInitializer.mapsequence2[MapSequenceInitializer.act2Location]);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ChangeScene());
        }
    }
}
