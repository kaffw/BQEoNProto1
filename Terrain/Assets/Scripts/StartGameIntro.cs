using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameIntro : MonoBehaviour
{
    public float timer = 0f;
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown("x")) timer = 38.1f;

        if (timer > 38.1f)
        {
            SceneManager.LoadScene(31);
        }
    }
}
