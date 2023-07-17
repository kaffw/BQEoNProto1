using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform1 : MonoBehaviour
{
    public GameObject DP1;
    public int spawnDistance = 3;
    public int spawnRate = 3;
    public float timer=0;

    void start()
    {
        Instantiate(DP1, new Vector3(-3, 0, 0), transform.rotation);
    }

    void Update()
    {

        if(timer < spawnRate)
        {
            timer+=Time.deltaTime;
        }
        else
        {
            Instantiate(DP1, new Vector3(spawnDistance, 0, 0), transform.rotation);
            spawnDistance+=6;
            timer = 0;
        }
    }
}
