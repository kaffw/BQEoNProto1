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
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        MapSequenceInitializer.location++;
        MapSequenceInitializer.counterToAct1End++;

        if (MapSequenceInitializer.counterToAct1End == 4)
        {
            SceneManager.LoadScene(MapSequenceInitializer.mapsequence[7]);
            MapSequenceInitializer.entryToAct3 = true;
        }

        else if (MapSequenceInitializer.entryToAct3 == true) SceneManager.LoadScene(9);

        else SceneManager.LoadScene(MapSequenceInitializer.mapsequence[MapSequenceInitializer.location]);

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ChangeScene());
        }
    }
}
