using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextAct : MonoBehaviour
{
    FadeInOut fade;
    
    private void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }

    public IEnumerator ChangeAct()
    {
        Debug.Log("current Act location: " + moveset.ActLocation);
        fade.FadeIn();
        yield return new WaitForSeconds(1);

        if(moveset.ActLocation == 1)
        {
            SceneManager.LoadScene(8);
        }
        if(moveset.ActLocation == 2)
        {
            SceneManager.LoadScene(18);
        }
        if(moveset.ActLocation == 3)
        {
            //SceneManager.LoadScene(18);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ChangeAct());
        }
    }
}
