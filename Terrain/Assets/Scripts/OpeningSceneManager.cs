using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningSceneManager : MonoBehaviour
{
    public GameObject FirstVid, SecondVid, ThirdVid;
    public float timer = 0f;
    private void Start()
    {
        SecondVid.SetActive(false);
        FirstVid.SetActive(false);
        ThirdVid.SetActive(true);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 15)
        {
            ThirdVid.SetActive(false);
            FirstVid.SetActive(true);
        }
        if (timer > 22.7f)
        {
            ThirdVid.SetActive(false);
            FirstVid.SetActive(false);
            SecondVid.SetActive(true);
            
        }
        /*if(timer > 23f)
        {
            ThirdVid.SetActive(false);
            FirstVid.SetActive(false);
            SecondVid.SetActive(true);
        }*/
        if (timer > 29.5f)
        {
            SceneManager.LoadScene(21);
        }
    }
}
