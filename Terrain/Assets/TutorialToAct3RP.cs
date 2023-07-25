using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialToAct3RP : MonoBehaviour
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

        SceneManager.LoadScene(27);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(EntryRP());
        }
    }
}
