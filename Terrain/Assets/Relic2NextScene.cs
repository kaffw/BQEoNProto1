using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Relic2NextScene : MonoBehaviour
{
    public float timer = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 6.1f)
        {
            //MapSequenceInitializer.act2Location++;
            //MapSequenceInitializer.counterToAct2End++;
            SceneManager.LoadScene(25);
        }
    }
}
