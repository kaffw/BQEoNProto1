using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningSceneManager : MonoBehaviour
{
    public GameObject FirstVid, SecondVid;
    public float timer = 0f;
    private void Start()
    {
        SecondVid.SetActive(false);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 7.7f)
        {
            SecondVid.SetActive(true);
            
        }
        if(timer > 8f)
        {
            FirstVid.SetActive(false);
        }
        if (timer > 43f)
        {
            SceneManager.LoadScene(21);
        }
    }
}
