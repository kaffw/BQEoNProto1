using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorSpawn;
    public float timer = 0f;
    public float spawnInterval = 0f;
    
    void Update()
    {
        if (timer <= 10)
        {
            timer += Time.deltaTime;
            spawnInterval += Time.deltaTime;
        }

        if (spawnInterval > 0.5f)
        {
            Instantiate(meteorSpawn, new Vector2(UnityEngine.Random.Range(40, 101), 50), transform.rotation);
            spawnInterval = 0f;
        }

        else timer = 0f;
    }
}
