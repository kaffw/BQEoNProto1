using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformSpawner : MonoBehaviour
{
    public GameObject hostJumpability;
    public GameObject fallingPlatforms;
    public float timer = 0f;
    public int x = 0, y = 0;

    private void Start()
    {
        hostJumpability = GameObject.Find("Bulan");
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 3)
        {
            x = UnityEngine.Random.Range(-20, 21);
            y = UnityEngine.Random.Range(3, 15);

            Instantiate(fallingPlatforms, new Vector2(x, y), transform.rotation);
            timer = 0f;
        }
    }
}
