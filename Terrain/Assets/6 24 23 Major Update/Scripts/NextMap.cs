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
        //Debug.Log("current Act location: " + moveset.ActLocation);
        fade.FadeIn();
        yield return new WaitForSeconds(1);

        if (moveset.ActLocation == 0)
        {
            //In NextAct...
        }

        else if (moveset.ActLocation == 1)
        {
            MapSequenceInitializer.location++;
            MapSequenceInitializer.counterToAct1End++;
            if (MapSequenceInitializer.location == 4)
            {
                SceneManager.LoadScene(9);
                //go End act 1.. 9
            }
            else SceneManager.LoadScene(MapSequenceInitializer.location);
        }

        else if (moveset.ActLocation == 2)
        {
            MapSequenceInitializer.act2Location++;
            MapSequenceInitializer.counterToAct2End++;
            if (MapSequenceInitializer.act2Location == 7)
            {
                SceneManager.LoadScene(20);    
                //go end act 2.. 20
            }
            SceneManager.LoadScene(MapSequenceInitializer.act2Location);
        }

        else if (moveset.ActLocation == 3)
        {

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
