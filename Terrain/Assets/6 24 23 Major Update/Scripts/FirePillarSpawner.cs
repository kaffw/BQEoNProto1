using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePillarSpawner : MonoBehaviour
{
    public GameObject PsuedoFirePillarSpawner;

    public GameObject player;
    public Vector2 Target;
    public float timer = 0;

    void Awake()
    {
        player = GameObject.Find("Character");
    }

    void Update()
    {
        if (timer < 10)
        {
            Target = new Vector2(player.transform.position.x, player.transform.position.y);
        }
        else
        {
            Instantiate(PsuedoFirePillarSpawner, Target, transform.rotation);

            timer = 0;
        }

        timer += Time.deltaTime;
    }
}