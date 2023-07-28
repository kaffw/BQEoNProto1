using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialToAct1RP : MonoBehaviour
{
    FadeInOut fade;

    private void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }

    private IEnumerator EntryRP()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(26);
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moveset.ActLocation = 1;
            StartCoroutine(EntryRP());
        }
    }
}
