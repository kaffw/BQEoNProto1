using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreBossScene : MonoBehaviour
{
    public float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown("x")) timer = 17f;

        if (timer > 17f)
        {
            SceneManager.LoadScene(20);
        }
    }
}
