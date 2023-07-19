using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmicFirePillarSpawner : MonoBehaviour
{
    public GameObject CosmicFirePillar;

    public GameObject player;
    public Vector2 Target;
    public float timer = 0;
    void Awake()
    {
        player = GameObject.Find("Bulan");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 10)
        {
            Target = new Vector2(player.transform.position.x, 3);
            timer += Time.deltaTime;
        }
        else
        {
            Instantiate(CosmicFirePillar, Target, transform.rotation);

            timer = 0;
        }
    }
}
