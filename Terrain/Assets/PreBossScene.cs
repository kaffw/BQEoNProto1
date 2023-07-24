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

        if (timer > 17f)
        {
            SceneManager.LoadScene(20);
        }
    }
}
