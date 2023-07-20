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
            int xpos = (int)hostJumpability.transform.position.x;
            int ypos = (int)hostJumpability.transform.position.y;
            x = UnityEngine.Random.Range(xpos - 10, xpos + 10);
            y = UnityEngine.Random.Range(ypos + 3, ypos + 5);

            int a, b, c, d;
            a = UnityEngine.Random.Range(-5, 6); b = UnityEngine.Random.Range(-5, 6);
            c = UnityEngine.Random.Range(-5, 6); d = UnityEngine.Random.Range(-5, 6);

            Instantiate(fallingPlatforms, new Vector2(x, y), transform.rotation);
            Instantiate(fallingPlatforms, new Vector2(x + a, y + b), transform.rotation);
            Instantiate(fallingPlatforms, new Vector2(x + c, y + d), transform.rotation);
            timer = 0f;
        }
    }
}
