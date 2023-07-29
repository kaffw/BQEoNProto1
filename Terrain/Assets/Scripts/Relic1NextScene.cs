using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Relic1NextScene : MonoBehaviour
{
    public float timer = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 13.1f)
        {
            SceneManager.LoadScene(27); //27
        }
    }
}
