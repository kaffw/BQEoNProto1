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

        if (timer > 6f)
        {
            SceneManager.LoadScene(1);
        }
    }
}
