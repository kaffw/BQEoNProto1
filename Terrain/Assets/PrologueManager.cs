using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologueManager : MonoBehaviour
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
        if (Input.GetKeyDown("x")) timer = 30.3f;

        if (timer > 15.1f)
        {
            FirstVid.SetActive(false);
            SecondVid.SetActive(true);

        }
        /*if (timer > 30.1f)
        {
            FirstVid.SetActive(false);
        }*/
        if (timer > 30.3)
        {
            SceneManager.LoadScene(1);
        }
    }
}
